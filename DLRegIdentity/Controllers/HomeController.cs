using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLRegIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace DLRegIdentity.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Superadmin, Admin, User")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Superadmin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        [Authorize(Roles = "Superadmin, Admin")]
        public IActionResult Import()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
