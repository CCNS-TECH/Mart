using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int menu)
        {
            HttpContext.Session.SetString("menu", menu.ToString());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Dashboard() => View();

        [HttpGet("/dashboard/report/")]
        public IActionResult ReportDashboard(int menu)
        {
            HttpContext.Session.SetString("menu", menu.ToString());
            return View();
        }
    }
}
