using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Categories;

namespace resm_app.Models.IBusinessObject
{
    public interface ISubcategoryL2<TEntity>
    {
        Task<int> InsertSubCateL2(SubCategoryL2 subCategoryL1);
        Task<int> UpdateSubCateL2(long id, SubCategoryL2 subCategoryL1);
        Task<int> DeleteSubCateL2(long id, SubCategoryL2 subCategoryL1);

        Task<TEntity> GetSubCateL2(long id);
        Task<List<TEntity>> GetSubL2All();
    }
}