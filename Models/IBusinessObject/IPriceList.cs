using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Products;

namespace resm_app.Models.IBusinessObject
{
    public interface IPriceList<TEntity>
    {
        Task<int> InsertPriceList(PriceList priceList);
        Task<int> UpdatePriceList(long id, PriceList priceList);
        Task<int> DeletePriceList(long id, PriceList priceList);
        Task<int> SetPriceList(long id, PriceList priceList);
        Task<TEntity> GetPriceList(long id);
        Task<List<TEntity>> GetPriceListAll();
    }
    public interface IPriceListDetail<TEntity>
    {
        Task<int> InsertPriceList01(PriceList01 priceList01);
        Task<int> UpdatePriceList01(long id,PriceList01 priceList01);
        Task<int> DeletePriceList01(long id,PriceList01 priceList01);
        Task<TEntity> GetPriceList01(long id);
        Task<List<TEntity>> GetPriceList01All();
        Task<int> DeletePriceListRang(long id, PriceList01 list01);

        Task<int> SetPriceListItem(long id, PriceList01 pricelist);
    }
}