using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DLRegIdentity.Models;
using DLRegIdentity.Data;
using Microsoft.AspNetCore.Authorization;

namespace DLRegIdentity.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MonthregsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonthregsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Monthregs
        [HttpGet]
        public IEnumerable<Monthreg> GetMonthregs()
        {
            var date = _context.Monthreg.GroupBy(m => m.Monthid).Select(d => new { Monthid = d.Key }).OrderByDescending(m => m.Monthid).ToList().Take(1);
            //suapvalint monthrego
            //_context.Monthreg.Where(m => m.Monthid == 123 || )
            //_context.Monthreg.Where()
            
            var Worker = _context.Monthreg.Include(m => m.Worker).ToList();
            var filteredlist = _context.Monthreg.Where(x => date.Any(d => x.Monthid == d.Monthid));
            return filteredlist;
        }

        // GET: api/Monthregs/201902
        [HttpGet("{passedDate}")]
        public IEnumerable<Monthreg> GetMonthreg([FromRoute] int passedDate)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var monthreg = await _context.Monthreg.FindAsync(id);
            //var Worker = _context.Monthreg.Include(m => m.Worker).ToList();

            //if (monthreg == null)
            //{
            //    return NotFound();
            //}

            //return Ok(monthreg);

            var date = _context.Monthreg.GroupBy(m => m.Monthid).Select(d => new { Monthid = d.Key }).OrderByDescending(m => m.Monthid).ToList().Take(3);
            //suapvalint monthrego
            //_context.Monthreg.Where(m => m.Monthid == 123 || )
            //_context.Monthreg.Where()

            var Worker = _context.Monthreg.Include(m => m.Worker).ToList();
            var filteredlist = _context.Monthreg.Where(x => x.Monthid == passedDate);
            return filteredlist;
        }

        // PUT: api/Monthregs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthreg([FromRoute] int id, [FromBody] Monthreg monthreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monthreg.Rowid)
            {
                return BadRequest();
            }

            _context.Entry(monthreg).State = EntityState.Modified;
            //_context.SaveChanges();
            //JsonConvert.PopulateObject(values,monthreg);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthregExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(monthreg);
        }

        // POST: api/Monthregs
        [HttpPost]
        [ExactQueryParam("monthreg")]
        public async Task<IActionResult> PostMonthreg([FromBody] Monthreg monthreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Monthreg.Add(monthreg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthreg", new { id = monthreg.Rowid }, monthreg);
        }

        /// <summary>
        /// Method to convert Devicereg data to Monthreg
        /// </summary>
        /// <param name="lastid"></param>
        /// <returns></returns>
        [HttpPost]
        [ExactQueryParam("lastid")]
        public async Task<IActionResult> PostMonthreg(int lastid)
        {
            try
            {
                var deviceregs = _context.Devicereg.Where(c => c.Id > lastid);
                List<Monthreg> newmonthregs = new List<Monthreg>();
                var workers_ = _context.Workers.Select(d => d.Id);
                //Select all distinct workers
                //var workers = deviceregs.Select(d => d.Workerid).Distinct();
                foreach (int workerid in workers_)
                {
                    //Select all distinct worker days
                    var days = deviceregs.Where(d => d.Workerid == workerid).Select(d => d.Time.Value.Date).Distinct();
                    foreach (DateTime date in days)
                    {
                        char daystatus = ' ';
                        double minutes = 0;
                        //Select all times when worker registered in exact date
                        var times = _context.Devicereg.Where(d => d.Time.Value.Date.Equals(date) && d.Workerid == workerid).OrderBy(d => d.Time).ToList();
                        for (int i = 0; i < times.Count(); i++)
                        {
                            if (times[i].Inout == 0)
                            {
                                if (i + 1 != times.Count() && times[i + 1].Inout == 1)
                                {
                                    minutes += times[i + 1].Time.Value.Subtract(times[i].Time.Value).TotalMinutes;
                                    
                                    i++; //Skip next registration cause it's already subtracted

                                }
                                else 
                                {
                                    if (date.Date != DateTime.Today)
                                    {
                                        daystatus = 'X';
                                    }      
                                }
                            }
                            else if (daystatus != 'X')
                            {
                                daystatus = 'E';
                            }
                        }

                        int yearandmonth = Int32.Parse(date.ToString("yyyyMM"));
                        Monthreg monthreg = _context.Monthreg.Concat(newmonthregs).FirstOrDefault(m => m.Monthid == yearandmonth && m.Worker.Id == workerid);
                        if (monthreg == null)
                        {
                            monthreg = new Monthreg();
                            monthreg.Monthid = yearandmonth;
                            monthreg.Worker = _context.Workers.First(w => w.Id == workerid);
                            _context.Monthreg.Add(monthreg);
                            newmonthregs.Add(monthreg);
                        }
                        if (minutes > 0)
                        {
                            monthreg.GetType().GetProperty("D" + date.Day).SetValue(monthreg, Math.Round((decimal)(minutes / 60), 1));
                            monthreg.GetType().GetProperty("Dp" + date.Day).SetValue(monthreg, "");
                        }
                        else if(daystatus != ' ')
                        {
                            monthreg.GetType().GetProperty("Dp" + date.Day).SetValue(monthreg, daystatus.ToString());
                        }
                    }
                }

                await _context.SaveChangesAsync();
                SetWeekendStatus();

            }
            catch (Exception e)
            {
                //TODO: error logging
                return StatusCode(500);
            }
            return Ok();
        }

        private void SetWeekendStatus()
        {
            int monthid = Int32.Parse(DateTime.Now.ToString("yyyyMM"));
            var monthregs = _context.Monthreg.Where(c => c.Monthid == monthid);
            DateTime startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime enddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            List<DateTime> weekenddates = GetWeekendDates(startdate, enddate);
            foreach (Monthreg monthreg in monthregs)
            {
                foreach (DateTime date in weekenddates)
                {
                    decimal? hours = (decimal?)monthreg.GetType().GetProperty("D" + date.Day).GetValue(monthreg);
                    string status = (string)monthreg.GetType().GetProperty("Dp" + date.Day).GetValue(monthreg);
                    if ((hours == null || hours == 0) && (status == null || status == " "))
                    {
                        monthreg.GetType().GetProperty("Dp" + date.Day).SetValue(monthreg, "P");
                    }
                }
            }
            _context.SaveChanges();
        }

        private List<DateTime> GetWeekendDates(DateTime start_date, DateTime end_date)
        {
            List<DateTime> days_list = new List<DateTime>();
            for (DateTime date = start_date; date <= end_date; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    days_list.Add(date);
            }
            return days_list;
        }

        // DELETE: api/Monthregs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthreg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monthreg = await _context.Monthreg.FindAsync(id);
            if (monthreg == null)
            {
                return NotFound();
            }

            _context.Monthreg.Remove(monthreg);
            await _context.SaveChangesAsync();

            return Ok(monthreg);
        }

        private bool MonthregExists(int id)
        {
            return _context.Monthreg.Any(e => e.Rowid == id);
        }
    }
}