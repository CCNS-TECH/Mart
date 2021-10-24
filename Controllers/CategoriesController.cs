using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class CategoriesController : Controller
    {
        private readonly ICategory<Category> _category;
        private readonly ISubCategory<SubCategoryL1> _subCategory;
        private readonly ISubcategoryL2<SubCategoryL2> _subcategoryL2;

        public CategoriesController(ICategory<Category> category,
                                    ISubCategory<SubCategoryL1> subCategory,
                                    ISubcategoryL2<SubCategoryL2> subcategoryL2)
        {
            _category = category;
            _subCategory = subCategory;
            _subcategoryL2 = subcategoryL2;
        }
        [HttpGet("/cate/create")]
        public async Task<IActionResult> AddNew()
        {
            ViewBag.CateList = await _category.GetCateList();
            return View();
        }

        [HttpPost("/cate/create")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNew(Category category)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            category.Created_By_Id = usId;
            category.Created_By_Name = usName;
            
            if (ModelState.IsValid)
            {
                category.Status = "Y";
                category.Deleted = "N";
                category.Color = Color.Coral.Name;
                
                await _category.InsertCate(category);
                return View();
            }

            return View();
        }
        [HttpGet("/cate/edit/")]
        public async Task<IActionResult> EditCate(long id)
        {
            var Cate = await _category.GetCategory(id);
            return View(Cate);
        }
        [HttpPost("/cate/edit/")]
        public async Task<IActionResult> EditCate(long id, Category category)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            category.Updated_By_Id = usId;
            category.Updated_By_Name = usName;
            id = category.CateId;
            await _category.UpdateCate(id, category);
            
            return Redirect("/cate/create");
        }
        [HttpPost("/cate/delete/{id}")]
        public async Task<IActionResult> DeleteCate(long id)
        {
            var category=new Category();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            category.Deleted_By_Id = usId;
            category.Deleted_By_Name = usName;
            
            await _category.DeleteCate(id, category);
            
            return Ok();
        }
        [HttpGet("/cate/sub/l1/create")]
        public IActionResult CreateSubCateL1()
        {
            return View();
        }
        [HttpPost("/cate/sub/l1/create")]
        public async Task<IActionResult> CreateSubCateL1(SubCategoryL1 subCategoryL1)
        {
            if (ModelState.IsValid)
            {
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                subCategoryL1.Created_By_Id = usId;
                subCategoryL1.Created_By_Name = usName;
                subCategoryL1.Created_Date=DateTime.Now;
                subCategoryL1.Deleted = "N";
                subCategoryL1.Status = "Y";

                await _subCategory.InsertSubCateL1(subCategoryL1);
                return Redirect("/cate/sub/l1/create");
            }
            return View();
        }
        [HttpGet("/cate/sub/l1/edit/")]
        public async Task<IActionResult> EditSubCate(long id)
        {
            if (id != 0)
                return View(await _subCategory.GetSubCateL1(id));
            else
                return View();
        }
        [HttpPost("/cate/sub/l1/edit/")]
        public async Task<IActionResult> EditSubCate(long id,SubCategoryL1 subCategoryL1)
        {
           
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                subCategoryL1.Updated_By_Id = usId;
                subCategoryL1.Updated_By_Name = usName;
                subCategoryL1.Created_Date=DateTime.Now;
                id = subCategoryL1.SubCateL1_Id;

                await _subCategory.UpdateSubCateL1(id, subCategoryL1);
          
            return Redirect("/cate/sub/l1/create");
        }
        [HttpPost("/subcate/l1/delete/{id}")]
        public async Task<IActionResult> DeleteSubCate(long id)
        {
            var subcategory=new SubCategoryL1();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            subcategory.Deleted_By_Id = usId;
            subcategory.Deleted_By_Name = usName;
            
            await _subCategory.DeleteSubCateL1(id, subcategory);
            
            return Ok();
        }
        [HttpGet("/cate/sub/l2/create")]
        public IActionResult CreateSubCateL2()
        {
            return View();
        }
        [HttpPost("/cate/sub/l2/create")]
        public async Task<IActionResult> CreateSubCateL2(SubCategoryL2 subCategoryL2)
        {
            ModelState.Remove("SubCategoryL1.SubCateL1_En");
            if (ModelState.IsValid)
            {
                var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName=HttpContext.Session.GetString("OwnnerName");
                subCategoryL2.Created_By_Id = usId;
                subCategoryL2.Created_By_Name = usName;
                subCategoryL2.Created_Date=DateTime.Now;
                subCategoryL2.Deleted = "N";
                subCategoryL2.Status = "Y";

                await _subcategoryL2.InsertSubCateL2(subCategoryL2);
                return Redirect("/cate/sub/l2/create");
            }
            return View();
        }
        [HttpGet("/cate/sub/l2/edit/")]
        public async Task<IActionResult> EditSubCateL2(long id)
        {
            if (id != 0)
                return View(await _subcategoryL2.GetSubCateL2(id));
            else
                return View();
        }
        [HttpPost("/subcate/l2/delete/{id}")]
        public async Task<IActionResult> DeleteSubCateL2(long id)
        {
            var subcategoryl2=new SubCategoryL2();
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            subcategoryl2.Deleted_By_Id = usId;
            subcategoryl2.Deleted_By_Name = usName;
            subcategoryl2.Deleted_Date=DateTime.Now;

            await _subcategoryL2.DeleteSubCateL2(id, subcategoryl2);
            
            return Ok();
        }
        [HttpGet("/sub/l1/cate/{id}")]
        public async Task<JsonResult> GetSubCateById(long id)
        {
            if (id != 0)
                return new JsonResult(await _subCategory.GetSubCateL1(id));
            else
                return new JsonResult(BadRequest());
        }
        [HttpGet("/sub/l1/cate/id/{id}")]
        public async Task<JsonResult> GetSubCateByCategoryId(long id)
        {
            if (id != 0)
                return new JsonResult(await _subCategory.GetSubCategoryByCategory(id));
            else
                return new JsonResult(BadRequest());
        }
      
    }
}