using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.UoMs;

namespace resm_app.Models.IBusinessObject
{
    public interface IDefineUoM<TEntity>
    {
        Task<int> InsertDefineUoM(DefineUoM defineUoM);
        Task<int> UpdateDefineUoM(long id, DefineUoM defineUoM);
        Task<int> DeleteDefineUoM(long id, DefineUoM defineUoM);
        
        Task<TEntity> GetDefineUoM(long id);
        Task<List<TEntity>> GetDefineUoMs();
    }
}