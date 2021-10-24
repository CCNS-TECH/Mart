using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Exchanges;

namespace resm_app.Models.IBusinessObject
{
    public interface IExchRate<TEntity>
    {
        Task<int> InsertExchRate(Exchange ex);
        Task<int>UpdateExchRate(long id,Exchange ex);
        Task<int> DeleteExch(long id,Exchange ex);
        Task<int> SetExchRate(long id, Exchange exchange);
        Task<Exchange> GetDefaultExchagne();
        Task<TEntity> GetExchRate(long id);
        Task<List<TEntity>> GetExchRates();

    }
}