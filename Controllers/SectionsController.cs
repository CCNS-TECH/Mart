using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class SectionsController : Controller
    {
        private readonly IGroupSection<GroupSection> _groupSection;
        private readonly ISection<Section> _section;
        public SectionsController(IGroupSection<GroupSection> groupSection,ISection<Section> section)
        {
            _groupSection = groupSection;
            _section = section;
        }
        
        [HttpGet("/section/list")]
        public IActionResult AddSection()
        {
            return View();
        }
        [HttpPost("/section/list")]
        public async Task<IActionResult> AddSection(Section section)
        {
            if (ModelState.IsValid)
            {   
                
                var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName = HttpContext.Session.GetString("OwnnerName");
                section.Deleted = "N";
                section.BookingStatus = "N";
                section.LineStatus = "N";
                section.CreatedDate=DateTime.Now;
                section.CreatedById = usId;
                section.CreateByStr = usName;
                
                await _section.InsertSection(section);
                return  Redirect("/section/list");
            }
            return View();
        }
        
        [HttpGet("/section/edit")]
        public async Task<IActionResult> EditSection(long id)
        {
            return View(await _section.GetSection(id));
        }
        [HttpPost("/section/edit")]
        public async Task<IActionResult> EditSection(long id,Section section)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                section.UpdatedDate=DateTime.Now;
                section.UpdatedById = usId;
                section.UpdatedByStr = usName;
                id = section.Id;
                
                await _section.UpdateSection(id, section);
                return Redirect("/section/list");
            }
            return View();
        }
        [HttpPost("/section/delete/{id}")]
        public async Task<JsonResult> DeleteSection(long id)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            var section = new Section();
            
            section.DeletedById = usId;
            section.DeletedByStr = usName;
            section.DeletedDate=DateTime.Now;
            
            var eff= await _section.DeleteSection(id, section);
            if(eff>0)
                return new JsonResult(Response.StatusCode);
            else
                return new JsonResult(500);
            
        }
        
        [HttpGet("/group/section/create")]
        public IActionResult AddGroupSection()
        {
            return View();
        }
        [HttpPost("/group/section/create")]
        public async Task<IActionResult> AddGroupSection(GroupSection groupSection)
        {
            if (ModelState.IsValid)
            {
                groupSection.Status = "Y";
                groupSection.Deleted = "N";
                groupSection.Type = "O";
                
               await _groupSection.InsertGroupSection(groupSection);
                return Redirect("/group/section/create");
            }
            return View();
        }
        [HttpGet("/group/section/edit")]
        public async Task<IActionResult> EditGroupSection(long id)
        {
            var gsection = await _groupSection.GetGroupSection(id);
            return View(gsection);
        }
        [HttpPost("/group/section/edit")]
        public async Task<IActionResult> EditGroupSection(long id,GroupSection groupSection)
        {
            if (ModelState.IsValid)
            {
                id = groupSection.Id;
                await _groupSection.UpdateGroupSection(id,groupSection);
                return Redirect("/group/section/create");
            }
            return View();
        }
        [HttpPost("/group/section/delete/{id}")]
        public async Task<JsonResult> GroupSectionList(long id)
        {
            var eff = await _groupSection.DeleteGroupSection(id);
            if(eff>0)
                return new JsonResult(Response.StatusCode);
            else
                return new JsonResult(500);
        }

        [HttpGet("/section/type/{id}")]
        public async Task<JsonResult> GetSectionByTypeId(long id)
        {
            return new JsonResult(await _section.GetSectionByTypeId(id));
        }

        [HttpGet("/section/all")]
        public async Task<JsonResult> GetSections()
        {
            var sections = await _section.GetSections();
            var sectViewModel = new SectionViewModel
            {
                CountAvailable = sections.Count(p=>p.LineStatus=="N"),
                CountBooking = sections.Count(p=>p.LineStatus=="R"),
                CountBill = sections.Count(p=>p.LineStatus=="C"),
                CountBusy = sections.Count(p=>p.LineStatus=="B")
            };
            return new JsonResult(sectViewModel);
        }
    }
}