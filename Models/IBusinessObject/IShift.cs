using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.Models.IBusinessObject
{
    public interface IShift<TEntity>
    {
        Task<int> InsertShift(Shift shift);
        Task<int> UpdateShift(long id,Shift shift);
        Task<int> DeleteShift(long id);
        Task<TEntity> GetShift(long id);
        Task<List<TEntity>> GetShifts();
    }
}