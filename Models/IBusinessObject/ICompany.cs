using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Companys;

namespace resm_app.Models.IBusinessObject
{
    public interface ICompany<TEntity>
    {
        Task<int> InsertCompany(Company company);
        Task<int> UpdateCompany(long id,Company company);
        Task<int> SetCompany(long id,Company company);
        Task<int> DeleteCompany(long id,Company company);

        Task<TEntity> GetCompanyDefault();
        Task<TEntity> GetCompany(long id);
        Task<List<TEntity>> GetListCompany();
    }
}