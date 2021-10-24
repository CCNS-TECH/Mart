using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Exchanges;

namespace resm_app.Models.IBusinessObject
{
    public interface IExchange
    {
        Task<int> InsertExchange(Exchange exchange);
        Task<int> UpdateExchange(Exchange exchange);
        Task<int> DeleteExchange(long Id);
        
        Task<Exchange> GetExchange();
        Task<List<Exchange>> GetListExchange();
    }
}