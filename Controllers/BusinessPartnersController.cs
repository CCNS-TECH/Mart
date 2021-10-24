using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.BusinessPartners;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class BusinessPartnersController : Controller
    {
        private readonly IPriceList<PriceList> _priceList;
        private readonly IBusinessPartner _partner;
        public BusinessPartnersController(IPriceList<PriceList> priceList,IBusinessPartner partner)
        {
            _priceList = priceList;
            _partner = partner;
        }
        [HttpGet("/BPN/Lists")]
        public async Task<IActionResult> BPN_List()
        {
            var partner = await _partner.GetBusinessPartners();
            return View(partner);
        }
        [HttpGet("/BPN/Create")]
        public async Task<IActionResult> BPN_Add()
        {
            ViewBag.ListPrice = await _priceList.GetPriceListAll();
            return View();
        }
        [HttpPost("/BPN/Add")]
        public async Task<IActionResult> Add_New(BusinessPartner partner)
        {
            var part = new BusinessPartner
            {
                Address = partner.Address,
                CreateById = int.Parse(HttpContext.Session.GetString("OwnnerId")),
                CreateByName = HttpContext.Session.GetString("OwnnerName"),
                CreateDate = DateTime.Now,
                Email = partner.Email,
                Gender = partner.Gender,
                Phone1 = partner.Phone1,
                Phone2 = partner.Phone2,
                PriceListId = partner.PriceListId,
                VendorName = partner.VendorName,
                Type = partner.Type,
                Status = "A",
                Delete = "N"
            };
        
            await _partner.Add_New(part);            
            return RedirectToAction("BPN_List");
        }
        [HttpGet("/BPN/Edit/{id}")]
        public async Task<IActionResult> BPN_Edit(long id)
        {
            ViewBag.ListPrice = await _priceList.GetPriceListAll();
            var partner = await _partner.GetBusinessPartners();
            var part = partner.FirstOrDefault(p=>p.VendorId == id);

            return View(part);
        }
        [HttpPost("/BPN/Edit")]
        public async Task<IActionResult> Edit_BPN(BusinessPartner partner)
        {
            var bpn = new BusinessPartner
            {
                Address = partner.Address,
                Email = partner.Email,
                Gender = partner.Gender,
                Phone1 = partner.Phone1,
                Phone2 = partner.Phone2,
                PriceListId = partner.PriceListId,
                VendorName = partner.VendorName,
                UpdateById = long.Parse(HttpContext.Session.GetString("OwnnerId")),
                UpdateByName = HttpContext.Session.GetString("OwnnerName"),
                UpdateDate = DateTime.Now,
                VendorId = partner.VendorId
            };

            await _partner.Edit_BPN(bpn);
            return RedirectToAction("BPN_List");
        }
        [HttpGet("/BPN/Delete/{id}")]
        public async Task<IActionResult> Delete_BPN(long id)
        {
            await _partner.Delete_BPN(id);
            return Ok();
        }
    }
}
