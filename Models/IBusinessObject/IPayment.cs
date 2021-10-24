using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.ViewModels;

namespace resm_app.Models.IBusinessObject
{
    public interface IPayment
    {
        Task<long> InsertPayment(Payment payment);
        Task<int> InsertPaymentDetail(PaymentDetail paymentDetail);
        Task<Payment> GetPaymentById(long paymentCode);
        Task<List<Payment>> GetPayments();
        Task<List<Payment>> GetPaymentByDate(DateTime from, DateTime to);
        Task<int> CancelPayment(long id, Payment payment);
        Task<int> CreditPayment(CreditPaymentViewModel creditPayment);
        Task<int> RemovePaymentById(long id);
    }
}