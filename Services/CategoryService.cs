using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class CategoryService
    {
        private readonly ICategory<Category> _category;
        private readonly ISubCategory<SubCategoryL1> _subCategory;
        private readonly ISubcategoryL2<SubCategoryL2> _subCategoryL2;

        public CategoryService(ICategory<Category> category,ISubCategory<SubCategoryL1> subCategory,ISubcategoryL2<SubCategoryL2> subCategoryL2)
        {
            _category = category;
            _subCategory = subCategory;
            _subCategoryL2 = subCategoryL2;
        }
        public async Task<List<Category>> GetCateList()
        {
            return await _category.GetAll();
        }

        public async Task<List<SubCategoryL1>> GetSubcateL1()
        {
            return await _subCategory.GetSubL1All();
        }
        public async Task<List<SubCategoryL1>> GetSubcateByCate(long id)
        {
            var subs = await _subCategory.GetSubL1All();
            var ss = subs.Where(p => p.Cate_Id == id).ToList();
            return ss;
        }
        public async Task<List<SubCategoryL2>> GetSubcateL2()
        {
            return await _subCategoryL2.GetSubL2All();
        }
        public async Task<List<SubCategoryL1>> GetSubCateL1ALL()
        {
            return await _subCategory.GetSubL1All();
        }
    }
}