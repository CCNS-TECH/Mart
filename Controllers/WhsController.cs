using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class WhsController : Controller
    {
        private readonly IWhs<Whs> _whs;
        private readonly IWhsDetail<Whs01> _whsDetail;

        public WhsController(IWhs<Whs> whs,IWhsDetail<Whs01> whsDetail)
        {
            _whs = whs;
            _whsDetail = whsDetail;
        }
        [HttpGet("/whs/list")]
        public async Task<IActionResult> Add()
        {
            ViewBag.Whs = await _whs.GetWhss();
            return View();
        }
        [HttpPost("/whs/list")]
        public async Task<IActionResult> Add(Whs whs)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                whs.Created_By_Id = usId;
                whs.Created_By_Name = usName;
                whs.Created_Date=DateTime.Now;
                whs.Deleted = "N";
                await _whs.InsertWhs(whs);
                return Redirect("/whs/list");
            }
            return View();
        }
        [HttpGet("/whs/edit")]
        public async Task<IActionResult> Edit(long id)
        {
           var whs = await _whs.GetWhsById(id);
            return View(whs);
        }
        [HttpPost("/whs/edit")]
        public async Task<IActionResult> Edit(long id,Whs whss)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                whss.Updated_By_Id = usId;
                whss.Updated_By_Name = usName;
                whss.Updated_Date=DateTime.Now;
                id = whss.Id;
                
                await _whs.UpdateWhs(id,whss);
                return Redirect("/whs/list");
            }
            return View();
        }
        [HttpPost("/whs/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var whs = new Whs();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                whs.Deleted_By_Id = usId;
                whs.Deleted_By_Name = usName;
                whs.Deleted_Date=DateTime.Now;
                
                await _whs.DeleteWhs(id,whs);
                return Redirect("/whs/list");
            }
            return Ok();
        }
        [HttpPost("/whs/set/{id}")]
        public async Task<IActionResult> SetDefault(long id)
        { 
            var whs=new Whs();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            whs.Updated_By_Id = usId;
            whs.Updated_By_Name = usName;    
           whs.Updated_Date=DateTime.Now;
           
            await _whs.SetWhs(id,whs);
            return Ok();
        }
    }
}