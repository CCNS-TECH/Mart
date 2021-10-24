using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace resm_app.Controllers
{
    public class ErrorPageController:Controller
    {
        [HttpGet("page/authorize")]
        public IActionResult AuthorizationPage()
        {
            return View();
        }
    }
}