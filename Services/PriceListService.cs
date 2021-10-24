using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class PriceListService
    {
        private readonly IPriceList<PriceList> _priceList;

        public PriceListService(IPriceList<PriceList> priceList)
        {
            _priceList = priceList;
        }
        public async Task<List<PriceList>> GetPricelists()
        {
            var pls = await _priceList.GetPriceListAll();
            return pls;
        }
    }
}