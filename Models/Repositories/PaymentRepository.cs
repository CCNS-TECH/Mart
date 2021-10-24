using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Models.Repositories
{
    public class PaymentRepository:IPayment
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertPayment(Payment payment)
        {
            try
            {
                var booking = await _context.BookingSections.FirstOrDefaultAsync(a => a.SectionId == payment.BookingSection.SectionId && a.LineStatus == "O");
                if (booking != null)
                {
                    booking.LineStatus = "C";
                    _context.BookingSections.Update(booking);
                    payment.Description = booking.Description;
                }
            }
            catch (Exception exs)
            {
                Console.WriteLine(exs.Message);
            }

            try
            {
                // payment.Description = "Paid from room checkin";
                payment.PaymentDate = DateTime.Now;
                payment.PaidDate = DateTime.Now;

                await _context.Payments.AddAsync(payment);

                await _context.SaveChangesAsync();
                var docEntry = await _context.Payments.Select(p => p.DocEntry).MaxAsync();
                return docEntry;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }

        public async Task<int> InsertPaymentDetail(PaymentDetail paymentDetail)
        {
            try
            {
                paymentDetail.DocDate = DateTime.Now;
                await _context.PaymentDetails.AddAsync(paymentDetail);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }

        public async Task<Payment> GetPaymentById(long paymentCode)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentCode == paymentCode);
                var paymentdetails = await _context.PaymentDetails.Where(p => p.DocEntry == payment.DocEntry).ToListAsync();
                var invCode = paymentdetails.Max(_ => _.InvCode);
                var invoices = await _context.Invoices.Where(inv => inv.InvCode == invCode).ToListAsync();
                payment.Invoices = invoices;
                payment.PaymentDetails = paymentdetails;
                return payment;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
           
        }

        public async Task<List<Payment>> GetPayments()
        {
            try
            {
                var payments = await _context.Payments.Where(p => p.Deleted == "N").ToListAsync();
                var paymentlist = (from p in payments
                    select new Payment
                    {
                        DocEntry =p.DocEntry,
                        PaymentCode =p.PaymentCode,
                        DiscPrcnt=p.DiscPrcnt,
                        TotalDiscUSD =p.TotalDiscUSD,
                        TotalDiscRiel=p.TotalDiscRiel,
                        TaxPrcnt =p.TaxPrcnt,
                        TotalTaxUSD =p.TotalTaxUSD,
                        TotalTaxRiel =p.TotalTaxRiel,
                        ExchangeRate =p.ExchangeRate,
                        ShiftId =p.ShiftId,
                        ShiftStr =p.ShiftStr,
                        ServiceChargeUSD =p.ServiceChargeUSD,
                        ServiceChargeRiel =p.ServiceChargeRiel,
                        OtherChargeUSD =p.OtherChargeUSD,
                        OtherChargeRiel =p.OtherChargeRiel,
                        SubTotalUSD =p.SubTotalUSD,
                        SubTotalRiel =p.SubTotalRiel,
                        GrandTotalUSD =p.GrandTotalUSD,
                        GrandTotalRiel =p.GrandTotalRiel,
                        ReceivedUSD = p.ReceivedUSD,
                        ReceivedRiel = p.ReceivedRiel,
                        ComissionPrcn =p.ComissionPrcn,
                        ComissionRate =p.ComissionRate,
                        ComissionUSD =p.ComissionUSD,
                        ComissionRiel =p.ComissionRiel,
                        ComissionById =p.ComissionById,
                        ComissionByStr =p.ComissionByStr,
                        BookingId =p.BookingId,
                        BookingStatus =p.BookingStatus,
                        PaymentDate =p.PaymentDate,
                        ReceivedById =p.ReceivedById,
                        ReceivedByStr =p.ReceivedByStr,
                        MethodTypeId =p.MethodTypeId,
                        MethodTypeStr =p.MethodTypeStr,
                        DocStatus =p.DocStatus,
                        CancelStatus =p.CancelStatus,
                        CancelDate =p.CancelDate,
                        CancelById =p.CancelById,
                        CancelByStr =p.CancelByStr,
                        Deleted =p.Deleted,
                        Description =p.Description,
                        PaidDate = p.PaidDate,
                        PaymentDetails = _context.PaymentDetails.Where(b=>b.DocEntry==p.DocEntry).ToList()
                    }).ToList();
                return paymentlist;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }

        public async Task<List<Payment>> GetPaymentByDate(DateTime from, DateTime to)
        {
            try
            {
                from  += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");

                var payments = await _context.Payments.Where(p => p.Deleted == "N" &&
                                                             p.PaidDate >= from &&
                                                             p.PaidDate <= to).ToListAsync();
                var paymentlist = (from p in payments
                    select new Payment
                    {
                        DocEntry =p.DocEntry,
                        PaymentCode =p.PaymentCode,
                        DiscPrcnt=p.DiscPrcnt,
                        TotalDiscUSD =p.TotalDiscUSD,
                        TotalDiscRiel=p.TotalDiscRiel,
                        TaxPrcnt =p.TaxPrcnt,
                        TotalTaxUSD =p.TotalTaxUSD,
                        TotalTaxRiel =p.TotalTaxRiel,
                        ExchangeRate =p.ExchangeRate,
                        ShiftId =p.ShiftId,
                        ShiftStr =p.ShiftStr,
                        ServiceChargeUSD =p.ServiceChargeUSD,
                        ServiceChargeRiel =p.ServiceChargeRiel,
                        OtherChargeUSD =p.OtherChargeUSD,
                        OtherChargeRiel =p.OtherChargeRiel,
                        SubTotalUSD =p.SubTotalUSD,
                        SubTotalRiel =p.SubTotalRiel,
                        GrandTotalUSD =p.GrandTotalUSD,
                        GrandTotalRiel =p.GrandTotalRiel,
                        ReceivedUSD = p.ReceivedUSD,
                        ReceivedRiel = p.ReceivedRiel,
                        ComissionPrcn =p.ComissionPrcn,
                        ComissionRate =p.ComissionRate,
                        ComissionUSD =p.ComissionUSD,
                        ComissionRiel =p.ComissionRiel,
                        ComissionById =p.ComissionById,
                        ComissionByStr =p.ComissionByStr,
                        BookingId =p.BookingId,
                        BookingStatus =p.BookingStatus,
                        PaymentDate =p.PaymentDate,
                        ReceivedById =p.ReceivedById,
                        ReceivedByStr =p.ReceivedByStr,
                        MethodTypeId =p.MethodTypeId,
                        MethodTypeStr =p.MethodTypeStr,
                        DocStatus =p.DocStatus,
                        CancelStatus =p.CancelStatus,
                        CancelDate =p.CancelDate,
                        CancelById =p.CancelById,
                        CancelByStr =p.CancelByStr,
                        Deleted =p.Deleted,
                        PaidDate = p.PaidDate,
                        Description =p.Description,
                        PaymentDetails = _context.PaymentDetails.Where(s=>s.DocEntry == p.DocEntry).ToList()
                    }).ToList();
                return paymentlist;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
            
        }

        public async Task<int> CancelPayment(long id, Payment payment)
        {
            try
            {
                var pay = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentCode == payment.PaymentCode);
                pay.DocStatus = "-";
                pay.CancelById = payment.CancelById;
                pay.CancelByStr = payment.CancelByStr;
                pay.CancelDate=DateTime.Now;
                pay.Description = payment.Description;

                _context.Payments.Update(pay);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
            
        }
        public async Task<int> CreditPayment(CreditPaymentViewModel creditPayment)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == long.Parse(creditPayment.InvCode));
                inv.PayDate = creditPayment.ReturnDate;
                inv.CustomerId = creditPayment.CustomerId;
                inv.CreateById = creditPayment.CreateById;
                inv.CreateByStr = creditPayment.CreateByStr;
                inv.CreateDate = DateTime.Now;
                inv.ShiftId = creditPayment.ShiftId;
                inv.ShiftStr = creditPayment.ShiftStr;
                inv.ComissionById = creditPayment.CommissionById;
                inv.ComissionByStr = creditPayment.CommissionByStr;
                inv.ComissionPrcnt = creditPayment.CommissionPrcnt;
                inv.ComissionRate = creditPayment.CommissionRate;
                inv.ComissionUSD = creditPayment.CommissionTotalUSD;
                inv.ComssionRiel = creditPayment.CommissionTotalRiel;
                inv.PayDate = creditPayment.ReturnDate;
                inv.BookingStatus = creditPayment.BookingStatus;
                inv.Description = creditPayment.Description;
                inv.DocStatus = "P";
                inv.TimeIn = creditPayment.TimeIn;
                inv.TimeOut = creditPayment.TimeOut;
                _context.Invoices.Update(inv);
                return await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<int> RemovePaymentById(long id)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(p => p.DocEntry == id);
                _context.Payments.Remove(payment);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}