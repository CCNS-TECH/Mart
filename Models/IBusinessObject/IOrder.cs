using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.ViewModels;

namespace resm_app.Models.IBusinessObject
{
    public interface IOrder
    {
        Task<long> InsertOrder(Order order);
        Task<int> InsertOrder01(OrderDetail orderDetail);
        Task<Order> GetOrderBySectionId(long id);
        Task<List<Order>> GetOrders();
        Task<int> UpdateOrder(long docEntry,Order order);
        Task<int> RemovedOrderDetail(long docEntry);
        Task<int> RemoveOrderById(long id);
        Task<int> DeletedOrderById(long id,Order order);
        Task<Order> GetBillByOrderId(long id);
        Task<int> TransferSectionOrder(SectionTransferViewModel transfer);
        Task<int> UpdateStatusOrder(long docEntry);
        Task<int> UpdateOrderAfterPaid(Order order);
        Task<List<Order>> GetNewOrder();
    }
}