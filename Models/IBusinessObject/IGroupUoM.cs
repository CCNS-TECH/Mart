using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.UoMs;

namespace resm_app.Models.IBusinessObject
{
    public interface IGroupUoM<TEntity>
    {
        Task<int> InsertGroupUoM(GroupUoM groupUoM);
        Task<int> UpdateGroupUoM(long id, GroupUoM groupUoM);
        Task<int> DeleteGroupUoM(long id, GroupUoM groupUoM);
        
        Task<TEntity> GetGroupUoM(long id);
        Task<List<TEntity>> GetGroupUoMs();
    }
}