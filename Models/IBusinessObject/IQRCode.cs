using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Products;

namespace resm_app.Models.IBusinessObject
{
    public interface IQRCode<TEntity>
    {
        Task<long> InsertQRCode(QRCoders qrCoders);
        Task<int> UpdateQRCode(long id, QRCoders qrCoders);
        Task<int> DeleteQRCode(long id);
        
        Task<TEntity> GetQRCodeById(long id);
        Task<List<TEntity>> GetQRCode();
    }
}