using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class PriceListsController:Controller
    {
        private readonly IPriceListDetail<PriceList01> _priceList01;

        public PriceListsController(IPriceListDetail<PriceList01> priceList01)
        {
            _priceList01 = priceList01;
        }

        [HttpGet("/pricelist/all")]
        public async Task<IActionResult> PriceList()
        {
            var prls = await _priceList01.GetPriceList01All();
            return View(prls);
        }
        [HttpGet("/pricelist/find/{id}")]
        public async Task<JsonResult> GetPriceListByGroupPrice(long id)
        {
            var prls = await _priceList01.GetPriceList01All();
            var pricelists = prls.Where(p => p.PriceList_Id == id).ToList();
            
            return new JsonResult(pricelists);
        }
        
        [HttpPost("/pricelist/set")]
        public async Task<IActionResult> GetPriceListsByGroupPrice(long id,PriceList01 priceList01)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            
            priceList01.Updated_By_Id = usId;
            priceList01.Updated_By_Name = usName;
            priceList01.Updated_Date = DateTime.Now;
            
            var eff= await _priceList01.SetPriceListItem(id, priceList01);
            
            return Ok(eff);
        }
    }
}