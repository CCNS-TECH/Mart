using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Taxs;

namespace resm_app.Models.IBusinessObject
{
    public interface ITax<TEntity>
    {
        Task<int> InsertTax(Tax tax);
        Task<int> UpdateTax(long id, Tax tax);
        Task<int> DeleteTax(long id, Tax tax);

        Task<List<TEntity>> GetTaxs();
        Task<TEntity> GetTax(long id);
    }
}