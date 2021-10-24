using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class KDSsController : Controller
    {
        [HttpGet("/kds/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}