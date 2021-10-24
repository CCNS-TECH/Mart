using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Commissions;

namespace resm_app.Models.IBusinessObject
{
    public interface ICommission
    {
        Task<int> InsertCommission(Commission commission);
        Task<int> EditCommission(Commission commission);
        Task<int> DeletedCommission(long id);
        Task<Commission> GetCommissionById(long id);
        Task<List<Commission>> GetCommissions(DateTime from,DateTime to);
        Task<int> ConfirmCommission(Commission commission);

    }
}
