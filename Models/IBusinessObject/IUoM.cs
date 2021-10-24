using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.UoMs;

namespace resm_app.Models.IBusinessObject
{
    public interface IUoM<TEntity>
    {
        Task<int> InsertUoM(UoM uom);
        Task<int> UpdateUoM(long id, UoM uom);
        Task<int> DeleteUoM(long id, UoM uom);

        Task<TEntity> GetUoM(long id);
        Task<List<TEntity>> GetUoMAll();

        Task<int> Add_DefineUoM(DefineUoM duom);
        Task<List<DefineUoM>> Get_DefineUoM(long GUoM_Id);
        Task<decimal> ConvertQuantityByUoM(long uomId, long gruopId, decimal qty);

        Task<int> Delete_DefineUoM(int id,DefineUoM duom);

    }
}