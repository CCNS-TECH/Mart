using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Prefixs;

namespace resm_app.Models.IBusinessObject
{
    public interface IInvoice
    {
        Task<AutoNumber> GetAutoNumber(string keynot);
        Task<int> UpdateAutoNumber(string keynote, long autonum);
        Task<long> InsertInvoice(Invoice invoice);
        Task<int> UpdateInvoice(Invoice invoice);
        Task<int> UpdateInvoiceAfterPaid(Invoice invoice);
        
        Task<int> InsertInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<Invoice> GetInvoiceById(long id);
        Task<List<InvoiceDetail>> GetInvoiceDetailByInvCode(long invCode);
        Task<Invoice> GetInvoiceToPaymentById(long id);
        Task<Invoice> GetInvoiceToPaymentByCode(long invCode);
        Task<Invoice> GetInvoiceReBillById(long id);
        Task<int> RemoveInvoiceById(long docEntry);
        Task<int> RemoveInvoiceDetailById(long docEntry);
        Task<List<Invoice>> GetInvoicePending();
        Task<List<Invoice>> FindInvoiceByDate(DateTime from, DateTime to);

        Task<List<Invoice>> GetSaleAging();
        Task<List<Invoice>> GetSaleAging(DateTime from,DateTime to);
        Task<Invoice> GetCreditInvoiceToPaymentById(long docEntry);
        Task<Invoice> GetCreditInvoiceToPaymentByInvCode(long invCode);
        Task<Invoice> GetInvoiceViewerByInvCode(long invCode);
    }
}