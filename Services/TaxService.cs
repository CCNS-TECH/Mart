using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class TaxService
    {
        private readonly ITax<Tax> _tax;

        public TaxService(ITax<Tax> tax)
        {
            _tax = tax;
        }
        public async Task<List<Tax>> GetTaxs()
        {
            return await _tax.GetTaxs();
        }
    }
}