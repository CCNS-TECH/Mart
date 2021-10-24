using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.BusinessPartners;

namespace resm_app.Models.IBusinessObject
{
    public interface IBusinessPartner
    {
        Task<int> Add_New(BusinessPartner partner);
        Task<List<BusinessPartner>> GetBusinessPartners();
        Task<int> Edit_BPN(BusinessPartner partner);
        Task<int> Delete_BPN(long id);

    }
}
