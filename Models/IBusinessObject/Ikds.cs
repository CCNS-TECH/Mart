using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.BusinessObjects.Taxs;

namespace resm_app.Models.IBusinessObject
{
    public interface Ikds<TEntity>
    {
        Task<int> InsertKds(Kds kds);
        Task<int> UpdateKds(long id, Kds kds);
        Task<int> DeleteKds(long id);

        Task<List<TEntity>> GetKdss();
        Task<TEntity> GetKds(long id);
    }
}