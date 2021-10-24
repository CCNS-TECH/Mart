using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Products;
using resm_app.ViewModels;

namespace resm_app.Models.IBusinessObject
{
    public interface IProduct<TEntity>
    {
        Task<long> InsertItem(Item item);
        Task<int> UpdateItem(long id,Item item);
        Task<int> DeleteItem(long id,Item item);
        Task<TEntity> GetItem(long id);
        Task<List<TEntity>> GetItemAll();
        Task<int> CheckItem(string itemcode);
        Task<int> IssueStockInventory(WhsDetailViewModel whsDetail);
        Task<decimal> IssueBatchItem(long itemId, decimal value);
    }
}