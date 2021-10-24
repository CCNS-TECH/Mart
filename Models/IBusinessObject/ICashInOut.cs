using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.CashInOuts;
using resm_app.Models.BusinessObjects.Prefixs;

namespace resm_app.Models.IBusinessObject
{
    public interface ICashInOut
    {
        Task<long> InsertCashInAsync(CashIn cashIn);
        Task<int> UpdateCashInAsync(CashIn cashIn);
        Task<CashIn> GetCashInAsync(long id);
        Task<IEnumerable<CashIn>> GetCashInListAsync();
        
        Task<int> InsertCashOutAsync(CashOut cashOut);
        Task<int> UpdateCashOutAsync(CashOut cashOut);
        Task<CashOut> GetCashOutAsync(long id);
        Task<IEnumerable<CashOut>> GetCashOutListAsync();
        Task<List<CashIn>> GetCashInAsync();

        Task<List<AutoNumber>> GetAutoNumbers();
        Task<List<CashOut>> GetCashOuts();
    }
}