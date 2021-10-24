using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.BusinessPartners;
using resm_app.Models.BusinessObjects.CashInOuts;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class DashboardService
    {
        private readonly ISeller _seller;
        private readonly IBusinessPartner _businessPartner;
        private readonly ICashInOut _cashInOut;

        public DashboardService(ISeller seller,IBusinessPartner businessPartner,ICashInOut cashInOut)
        {
            _seller = seller;
            _businessPartner = businessPartner;
            _cashInOut = cashInOut;
        }
        public async Task<List<Order>> GetOrderBySellerId(long id)
        {
            return await _seller.GetSellerById(id);
        }
        public async Task<List<Item>> GetItemByType(string type)
        {
            return await _seller.GetItemByType(type);
        }
        public async Task<List<Section>> GetSections()
        {
            return await _seller.GetSections();
        }
        public async Task<int> GetCountBooked()
        {
            return await _seller.CountSectionBooked();
        }
        public async Task<int> GetCountChecked()
        {
            return await _seller.CountSectionCheckIn();
        }
        public async Task<decimal> GetValueOrder()
        {
            var orders = await _seller.SumGrandTotalOrder();
            return orders.Sum(p => p.GrandTotalUSD);
        }
        public async Task<decimal> GetValueInvoice()
        {
            var orders = await _seller.SumGrandTotalInvoice();
            return orders.Sum(p => p.GrandTotalUSD);
        }
        public async Task<List<InvoiceDetail>> GetTopSale()
        {
            var invs = await _seller.GetTopSale();
            return invs;
        }
        public async Task<List<BusinessPartner>> GetCustomers()
        {
            var bpns = await _businessPartner.GetBusinessPartners();
            return bpns.Where(p => p.Type == "C").ToList();
        }
        public async Task<IEnumerable<CashIn>> GetCashInList()
        {
            return await _cashInOut.GetCashInListAsync();
        }

        public async Task<CashIn> GetCashInAsync()
        {
            var cashin = await _cashInOut.GetCashInAsync();
            if (cashin.Count != 0) { 
                var PayCode = cashin.Min(p => p.PaymentCode);
                var cashindata = cashin.FirstOrDefault(p => p.PaymentCode == PayCode);
                cashindata.TotalUSD = cashin.Where(_=>_.CashInById == cashindata.CashInById).Sum(_=>_.TotalUSD);
                cashindata.TotalRiel = cashin.Where(_ => _.CashInById == cashindata.CashInById).Sum(_ => _.TotalRiel);

                return cashindata;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Batch>> GetBatchExpireDate()
        {
            return await _seller.GetExpiredDate();
        }
    }
}