using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DLRegIdentity.Controllers
{
    public class FB2SQLController : Controller
    {
        public IActionResult ExecuteFB2SQL()
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\FB2SQL\\FB2SQL.exe",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (result == "")
            {
                result = "Importo procedūra atlikta sėkmingai";
            }
            else
            {
                result = "Įvyko klaida: " + result;
            }
            return new JsonResult(result);
        }
    }
}