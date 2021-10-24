using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class CompanyController:Controller
    {
        private readonly ICompany<Company> _company;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CompanyController(ICompany<Company> company, IWebHostEnvironment hostingEnvironment)
        {
            _company = company;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("/company/list")]
        public async Task<IActionResult> Add()
        {
            ViewBag.Company = await _company.GetListCompany();
            return View();
        }

        [HttpPost("/company/list")]
        public async Task<IActionResult> Add([FromForm] Company company,IFormFile Img)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            
            if (ModelState.IsValid)
            {
                if (Img != null)
                    company.Img = await SaveFile(Img);
                else
                    company.Img = "logo.png";
                
                company.Created_By_Id = usId;
                company.Created_By_Name = usName;
                company.City = company.Province;
                company.Description = "Thank for come here.";
                
                await _company.InsertCompany(company);
                return Redirect("/company/list");
            }
            return View();
        }
        [HttpGet("/company/edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var cpn = await _company.GetCompany(id);
            return View(cpn);
        }

        [HttpPost("/company/edit")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(long id, Company company,IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img == null)
                    company.Img = company.Old_Img;
                else
                    company.Img =await SaveFile(Img);
                
                
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                company.Updated_By_Id = usId;
                company.Updated_By_Name = usName; 
                
                await _company.UpdateCompany(id, company);
                return Redirect("/company/list");
            }
            return View();
        }

        [HttpPost("/company/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        { 
            var cpn=new Company();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            cpn.Deleted_By_Id = usId;
            cpn.Deleted_By_Name = usName;    
           
            await _company.DeleteCompany(id,cpn);
            return Ok();
        }
        [HttpPost("/company/set/{id}")]
        public async Task<IActionResult> SetDefault(long id)
        { 
            var cpn=new Company();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            cpn.Deleted_By_Id = usId;
            cpn.Deleted_By_Name = usName;    
           
            await _company.SetCompany(id,cpn);
            return Ok();
        }
        
        async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/logo");
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
    }
}