using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class UoMsController : Controller
    {
        private readonly IUoM<UoM> _uom;
        private readonly IGroupUoM<GroupUoM> _groupUoM;

        public UoMsController(IUoM<UoM> uom,IGroupUoM<GroupUoM> groupUoM)
        {
            _uom = uom;
            _groupUoM = groupUoM;
        }
        [HttpGet("/uom/list")]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost("/uom/list")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddNew(UoM uoM)
        {
            if (ModelState.IsValid)
            {
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                uoM.Created_By_Id = usId;
                uoM.Created_By_Name = usName;
                uoM.Created_Date=DateTime.Now;
                uoM.Deleted = "N";

                await  _uom.InsertUoM(uoM);
                return Redirect("/uom/list");
            }
            return View();
        }
        [HttpGet("/uom/edit/{id}")]
        public async Task<IActionResult> EditUoM(long id)
        {
            if (id != 0)
                return View(await _uom.GetUoM(id));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditsUoM(UoM uoM)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            uoM.Updated_By_Id = usId;
            uoM.Updated_By_Name = usName;
            uoM.Updated_Date=DateTime.Now;
            var id = uoM.UoM_Id;
            var eff= await _uom.UpdateUoM(id,uoM);
            if(eff>0)
                return Redirect("/uom/list");
            else
                return View(nameof(EditUoM));
            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUoM(long id)
        {
            var uoM = new UoM();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            uoM.Deleted_By_Id = usId;
            uoM.Deleted_By_Name = usName;
            uoM.Deleted_Date=DateTime.Now;
            uoM.Deleted = "Y";
            
            var eff= await _uom.DeleteUoM(id,uoM);
            
            if(eff>0)
                return new JsonResult(Ok());
            else
                return new JsonResult(BadRequest());
            
        }
        
        [HttpGet("/uom/group/list")]
        public IActionResult AddNewGroup()
        {
            return View();
        }
        [HttpPost("/uom/group/list")]
        public async Task<IActionResult> AddNewGroup(GroupUoM groupUoM)
        {
            if (ModelState.IsValid)
            {
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                groupUoM.Created_By_Id = usId;
                groupUoM.Created_By_Name = usName;
                groupUoM.Created_Date=DateTime.Now;
                groupUoM.Deleted = "N";

                await  _groupUoM.InsertGroupUoM(groupUoM);
                return Redirect("/uom/group/list");
            }
            return View();
        }
        [HttpGet("/uom/group/edit/")]
        public async Task<IActionResult> EditGroupUoM(long id)
        {
            if (id != 0)
                return View(await _groupUoM.GetGroupUoM(id));
            return View();
        }
        [HttpPost("/uom/group/edit/")]
        public async Task<IActionResult> EditsGroupUoM([FromForm] GroupUoM guoM)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            guoM.Updated_By_Id = usId;
            guoM.Updated_By_Name = usName;
            guoM.Updated_Date=DateTime.Now;
            var id = guoM.GUoM_Id;
            var eff= await _groupUoM.UpdateGroupUoM(id,guoM);
            if(eff>0)
                return Redirect("/uom/group/list");
            else
                return View(nameof(EditGroupUoM));
            
        }
        [HttpPost("/uom/group/delete/{id}")]
        public async Task<JsonResult> DeleteGroupUoM(long id)
        {
            var guoM = new GroupUoM();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            guoM.Deleted_By_Id = usId;
            guoM.Deleted_By_Name = usName;
            guoM.Deleted_Date=DateTime.Now;
            guoM.Deleted = "Y";

            var eff= await _groupUoM.DeleteGroupUoM(id,guoM);
            
            if(eff>0)
                return new JsonResult(Ok());
            else
                return new JsonResult(BadRequest());
            
        }

        [HttpPost]
        public async Task<IActionResult> Add_DefineUoM(DefineUoM duom)
        {
            duom.Created_Date = DateTime.Now;
            duom.Created_By_Id=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            duom.Created_By_Name=HttpContext.Session.GetString("OwnnerName");
            duom.Deleted = "N";
            await _uom.Add_DefineUoM(duom);

            return Ok();
        }

        [HttpGet("/uom/define/{id}")]
        public async Task<IActionResult> Get_DefineUoM(int id)
        {
            var define =await _uom.Get_DefineUoM(id);
            return Ok(define);
        }
        [HttpPost("/uom/define/delete/{id}")]
        public async Task<IActionResult> Delete_DefineUoM(int id)
        {
            var duom = new DefineUoM();
            duom.Deleted_By_Id = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            duom.Deleted_By_Name = HttpContext.Session.GetString("OwnnerName");
            duom.Deleted_Date = DateTime.Now;
            await _uom.Delete_DefineUoM(id, duom);
            return Ok();
        }
    }
}