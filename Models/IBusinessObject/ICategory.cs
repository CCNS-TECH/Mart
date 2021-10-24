using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Categories;

namespace resm_app.Models.IBusinessObject
{
    public interface ICategory<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<int> InsertCate(Category category);
        Task<int> UpdateCate(long Id, Category category);
        Task<int> DeleteCate(long Id,Category category);
        Task<Category> GetCategory(long Id);
        Task<List<Category>> GetCateList();
        Task<List<SubCategoryL1>> GetSubCateL1ByCate(long id);
    }
}