using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.ViewModels;

namespace resm_app.Models.IBusinessObject
{
    public interface IWhs<TEntity>
    {
        Task<int> InsertWhs(Whs whs);
        Task<int> UpdateWhs(long id, Whs whs);
        Task<int> DeleteWhs(long id, Whs whs);
        Task<int> SetWhs(long id,Whs whs);
        Task<TEntity> GetWhsById(long id);
        Task<List<TEntity>> GetWhss();
        Task<Whs> GetWhsByDefault();

    }
    public interface IWhsDetail<TEntity>
    {   
        Task<int> InsertWhs01(Whs01 whs01);
        Task<int> UpdateWhs01(long id, Whs01 whs);
        Task<int> DeleteWhs01(long id, Whs01 whs);
        Task<int> DeleteWhs01Rang(long id, Whs01 whs);
        
        Task<TEntity> GetWhs01ById(long id);
        Task<List<TEntity>> GetWhs01s();
        Task<TEntity> GetWhs01ByWhsId(long whsid,long itemId);
        //Task<int> UpdateStockByItemId(WhsDetailViewModel whsmodel);

    }
}