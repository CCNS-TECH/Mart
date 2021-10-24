using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class EmployeeController : Controller
    {
        private readonly IUser _user;
        private readonly IDept _dept;
        private readonly IShift<Shift> _shift;
        private readonly IAccount _account;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IUser user,IDept dept,IShift<Shift> shift, IWebHostEnvironment hostingEnvironment,IAccount account)
        {
            _user = user;
            _dept = dept;
            _shift = shift;
            _hostingEnvironment = hostingEnvironment;
            _account = account;
        }
        [HttpGet("/user/create")]
        public async Task<IActionResult> AddNew()
        {
            ViewBag.Dept = await _dept.GetDepts();
            ViewBag.Shift = await _shift.GetShifts();
            return View();
        }

        [HttpPost("/user/create")]
        public async Task<IActionResult> AddNew(Employee employee)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    if (employee.Img == null) 
                        employee.Img = "user-200.png";
                    
                    employee.Created_Date = DateTime.Now;
                    employee.Created_By_Id = usId;
                    employee.Created_By_Name = usName;
                    employee.Deleted = "N";
                    employee.Status = "Y";
            
                    var eff = await _user.InsetUser(employee);
                    return Ok(eff);
                }
                else
                {
                    if (employee.Img == null)
                        employee.Img = employee.Old_Img;
                    
                    employee.Updated_Date = DateTime.Now;
                    employee.Updated_By_Id = usId;
                    employee.Updated_By_Name = usName;
                    employee.Deleted = "N";
                    employee.Status = "Y";
            
                    var eff = await _user.UpdateUser(employee);
                    return RedirectToAction("EmployeeList","Employee");
                }
            }
            return View(nameof(AddNew));
        }
        [HttpPost("/profile/upload")]
        public async Task<JsonResult>UploadFile()
        {
            var files = Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    try
                    {
                        var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/profiles");
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        return new JsonResult(fileName);
                    }
                    catch
                    {
                        Response.StatusCode = 400;
                        return null;

                    }
                }
            }
            
            return new JsonResult("");
        }
        async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/profiles");
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch
            {
                Response.StatusCode = 400;
                return null;

            }
        }
        [HttpGet("/position/dept/{id}")]
        public async Task<JsonResult> GetPositionByDeptId(long id)
        {
            return new JsonResult(await _dept.GetPositionByDeptId(id));
        }
        [HttpGet("/user/list")]
        public async Task<IActionResult> EmployeeList()
        {
            ViewBag.Users = await _user.GetEmployees();
            return View();
        }
        [HttpGet("/user/edit")]
        public async Task<IActionResult> EditUser(long id)
        {
            ViewBag.Dept = await _dept.GetDepts();
            ViewBag.Shift = await _shift.GetShifts();
            var usrs = await _user.GetEmployee(id);
            
            return View(usrs);
        }
        [HttpGet("/user/deleted/{id}")]
        public async Task<JsonResult> DeleteUser(long id)
        {
            var emp=new Employee();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            
            emp.Deleted_By_Id = usId;
            emp.Deleted_By_Name = usName;
            emp.Deleted_Date=DateTime.Now;
            
            var eff = await _user.DeleteUser(id,emp);
            return new JsonResult(eff);
        }
        [HttpGet("/user/shift/list")]
        public async Task<IActionResult> AddNewShift()
        {
            ViewBag.ShiftList = await _shift.GetShifts();
            return View();
        }
        [HttpPost("/user/shift/list")]
        public async Task<IActionResult> AddNewShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                shift.Deleted = "N";
                await _shift.InsertShift(shift);
                return Redirect("/user/shift/list");
            }
            return View();
        }

        [HttpGet("user/shift/edit")]
        public async Task<IActionResult> EditShift(long id)
        {
            var shft = await _shift.GetShift(id);
            return View(shft);
        }
        [HttpPost("/user/shift/edit")]
        public async Task<IActionResult> EditShift(long id,Shift shift)
        {
            if (ModelState.IsValid)
            {
                id = shift.Id;
                
                await _shift.UpdateShift(id,shift);
                return Redirect("/user/shift/list");
            }
            return View();
        }
        [HttpPost("/user/shift/delete/{id}")]
        public async Task<IActionResult> DeleteShift(long id)
        {
            await  _shift.DeleteShift(id);
            return Ok();
        }
        [HttpGet("/user/profile/{id}")]
        public async Task<IActionResult> Profile(long id)
        {
            if(id !=0)
                ViewBag.Profile = await _user.GetEmployee(id);
            return View();
        }
    }
}