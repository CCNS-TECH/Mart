using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;

namespace resm_app.Models.IBusinessObject
{
    public interface ISeller
    {
        Task<List<Order>> GetSellerById(long saleId);
        Task<List<Item>> GetItemByType(string type);
        Task<List<Section>> GetSections();
        Task<int> CountSectionBooked();
        Task<int> CountSectionCheckIn();
        Task<List<Order>> SumGrandTotalOrder();
        Task<List<Batch>> GetItemExp();
        Task<List<InvoiceDetail>> GetTopSale();
        Task<List<Invoice>> SumGrandTotalInvoice();
        Task<List<Invoice>> GetInvoicesByUserId(DateTime from,DateTime to,long id);
        Task<List<Invoice>> SumValueInvoices(DateTime from,DateTime to);
        Task<List<Purchase>> PurchaseLists(DateTime from, DateTime to);
        Task<List<GoodsIssue01>> GoodsIssueList(DateTime from, DateTime to);
        Task<List<GoodsReceipt01>> GoodsReceiptList(DateTime from, DateTime to);
        Task<List<Item>> ItemList();
        Task<List<InvoiceDetail>> GetTopSale(DateTime from, DateTime to);
        Task<List<InvoiceDetail>> GetSaleReported(DateTime from, DateTime to);
        Task<List<Batch>> GetExpiredDate();

    }
}