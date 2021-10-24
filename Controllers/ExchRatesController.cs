using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class ExchRatesController : Controller
    {
        private readonly IExchRate<Exchange> _exch;

        public ExchRatesController(IExchRate<Exchange> exch)
        {
            _exch = exch;
        }
        [HttpGet("exch/add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet("/exch/list")]
        public async Task<IActionResult> List()
        {
            ViewBag.Exchagne = await _exch.GetExchRates();
            return View();
        }
        [HttpPost("/exch/add")]
        public async Task<IActionResult> Add(Exchange exchange)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                exchange.Created_By_Id = usId;
                exchange.Created_By_Name = usName;
                exchange.Created_Date = DateTime.Now;
                exchange.Deleted = "N";
                
                await _exch.InsertExchRate(exchange);
                return Redirect("/exch/list");
            }
            return View();
        }
        [HttpGet("/exch/edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var ex = await _exch.GetExchRate(id);
            return View(ex);
        }
        [HttpPost("/exch/edit")]
        public async Task<IActionResult> Edit(long id,Exchange ex)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                ex.Updated_By_Id = usId;
                ex.Updated_By_Name = usName;
                ex.Updated_Date = DateTime.Now;
                id = ex.Id;
                await _exch.UpdateExchRate(id,ex);
                
                return Redirect("/exch/list");
            }
            return View();
        }
        [HttpPost("/exch/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ex=new Exchange();
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                ex.Deleted_By_Id = usId;
                ex.Deleted_By_Name = usName;
                ex.Deleted_Date = DateTime.Now;
                
                await _exch.DeleteExch(id,ex);
            }
            return Ok();
        }
        [HttpPost("/exch/set/{id}")]
        public async Task<IActionResult> SetDefault(long id)
        { 
            var ex=new Exchange();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            ex.Updated_By_Id = usId;
            ex.Updated_By_Name = usName;    
            ex.Updated_Date=DateTime.Now;
           
            await _exch.SetExchRate(id,ex);
            return Ok();
        }
    }
}