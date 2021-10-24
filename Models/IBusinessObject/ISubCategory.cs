using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Categories;

namespace resm_app.Models.IBusinessObject
{
    public interface ISubCategory<TEntity>
    {
        Task<int> InsertSubCateL1(SubCategoryL1 subCategoryL1);
        Task<int> UpdateSubCateL1(long id, SubCategoryL1 subCategoryL1);
        Task<int> DeleteSubCateL1(long id, SubCategoryL1 subCategoryL1);

        Task<List<SubCategoryL1>> GetSubCategoryByCategory(long id);
        Task<TEntity> GetSubCateL1(long id);
        Task<List<TEntity>> GetSubL1All();
    }
}