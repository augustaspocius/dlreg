using System;
using System.Collections.Generic;

namespace DLRegIdentity.Models
{
    public partial class Workers
    {
        public Workers()
        {
            //Monthreg = new HashSet<Monthreg>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int? Shiftid { get; set; }
        public int? Departmentid { get; set; }
        public string Workplace { get; set; }
           
        //public ICollection<Monthreg> Monthreg { get; set; }
    }
}
