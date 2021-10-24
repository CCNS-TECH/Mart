using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.IBusinessObject;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Invoices;

namespace resm_app.Models.Repositories
{
    public class InvoiceRepository:IInvoice
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AutoNumber> GetAutoNumber(string keynote)
        {
            var auto = await _context.AutoNumbers.FirstOrDefaultAsync(p=>p.AutoKey==keynote);
            return auto;
        }

        public async Task<int> UpdateAutoNumber(string keynote, long autonum)
        {
            var auto = await _context.AutoNumbers.FirstOrDefaultAsync(p => p.AutoKey == keynote);
            auto.Next = autonum;
            auto.LineStatus = "Y";
            _context.AutoNumbers.Update(auto);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> InsertInvoice(Invoice invoice)
        {
            try
            {
                invoice.DocTime = DateTime.Now.TimeOfDay;
                await _context.Invoices.AddAsync(invoice);
                await _context.SaveChangesAsync();
                var doc = await _context.Invoices.Select(p => p.DocEntry).MaxAsync();
                return doc;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }

        public async Task<int> UpdateInvoice(Invoice invoice)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invoice.InvCode);
                
                inv.Duration = invoice.Duration;
                inv.SectionPrice = invoice.SectionPrice;
                inv.SectionAmount = invoice.SectionAmount;
                
                inv.DiscPrcnt = invoice.DiscPrcnt;
                inv.TotalDiscUSD = invoice.TotalDiscUSD;
                inv.TotalDiscRiel = invoice.TotalDiscRiel;
                
                inv.TaxPrcnt = invoice.TaxPrcnt;
                inv.TotalTaxUSD = invoice.TotalTaxUSD;
                inv.TotalTaxRiel = invoice.TotalTaxRiel;
                
                inv.OtherChargeRiel = invoice.OtherChargeRiel;
                inv.OtherChargeUSD = invoice.OtherChargeUSD;
                inv.ServiceChargeRiel = invoice.ServiceChargeRiel;
                inv.ServiceChargeUSD = invoice.ServiceChargeUSD;
                
                inv.SubTotalUSD = invoice.SubTotalUSD;
                inv.SubTotalRiel = invoice.SubTotalRiel;
                inv.GrandTotalUSD = invoice.GrandTotalUSD;
                inv.GrandTotalRiel = invoice.GrandTotalRiel;
                
                inv.ExchangeRate = invoice.ExchangeRate;
                    
                inv.CreateDate = DateTime.Now;
                inv.CreateById = invoice.CreateById;
                inv.CreateByStr = invoice.CreateByStr;
                inv.FreeHour = invoice.FreeHour;
                inv.TotalHour = invoice.TotalHour;
                
                inv.ShiftId = invoice.ShiftId;
                inv.ShiftStr = invoice.ShiftStr;
                    
                _context.Invoices.Update(inv);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
            
        }

        public async Task<int> UpdateInvoiceAfterPaid(Invoice invoice)
        {
            try
            {
                invoice.DocTime = DateTime.Now.TimeOfDay;
                invoice.CreateDate = DateTime.Now;
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invoice.InvCode);
                inv.ReceivedUSD = invoice.ReceivedUSD;
                inv.ReceivedRiel = invoice.ReceivedRiel;
                inv.DocStatus = invoice.DocStatus;
                inv.CloseDate = invoice.CloseDate;
                inv.CloseById = invoice.CloseById;
                inv.CloseByStr = invoice.CloseByStr;

                _context.Invoices.Update(inv);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> InsertInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            try
            {
                invoiceDetail.DocDate = DateTime.Now;
                await _context.InvoiceDetails.AddAsync(invoiceDetail);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
        }

        public async Task<Invoice> GetInvoiceById(long id)
        {
            var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.SectionId == id && p.DocStatus == "O");
            return inv;
        }

        public async Task<List<InvoiceDetail>> GetInvoiceDetailByInvCode(long invCode)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invCode);
                var invds = await _context.InvoiceDetails.Where(p => p.DocEntry == inv.DocEntry).ToListAsync();
                return invds;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Invoice> GetInvoiceToPaymentById(long id)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.SectionId == id && p.DocStatus == "O");
                var invDetails = await _context.InvoiceDetails.Where(p => p.DocEntry == inv.DocEntry).ToListAsync();
                var booking = await _context.BookingSections.FirstOrDefaultAsync(p => p.Id == inv.BookingId);
                inv.InvoiceDetails = invDetails;
                inv.BookingSection = booking;
                return inv;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<Invoice> GetInvoiceToPaymentByCode(long invCode)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invCode && p.DocStatus == "O");
                return inv;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
            
        }

        public async Task<Invoice> GetInvoiceReBillById(long id)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.SectionId == id && p.DocStatus == "O");
                var invDetails = await _context.InvoiceDetails.Where(p => p.DocEntry == inv.DocEntry).ToListAsync();
                inv.InvoiceDetails = invDetails;
                return inv;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> RemoveInvoiceDetailById(long docEntry)
        {
            try
            {
                var incd = await _context.InvoiceDetails.Where(p => p.DocEntry == docEntry).ToListAsync();
                _context.InvoiceDetails.RemoveRange(incd);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Invoice>> GetInvoicePending()
        {
            try
            {
                var invList = await _context.Invoices.Where(p => p.DocStatus == "O" || p.PayStatus=="O").ToListAsync();
               
                return invList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
        public async Task<List<Invoice>> FindInvoiceByDate(DateTime from,DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");
                var invList = await _context.Invoices.Where(p => p.CreateDate >= from && p.CreateDate <= to).ToListAsync();
               var invoiceList = (from invoice in invList
                    select new Invoice
                    {
                        DocEntry = invoice.DocEntry,
                        InvCode = invoice.InvCode,
                        OrderCode = invoice.OrderCode,
                        Floor = invoice.Floor,
                        SectionId = invoice.SectionId,
                        SectionStr = invoice.SectionStr,
                        Duration = invoice.Duration,
                        FreeHour = invoice.FreeHour,
                        TotalHour = invoice.TotalHour,
                        SectionPrice = invoice.SectionPrice,
                        SectionAmount = invoice.SectionAmount,
                        GSectionId = invoice.GSectionId,
                        GSectionStr = invoice.GSectionStr,
                        SectionTypeId = invoice.SectionTypeId,
                        SectionTypeStr = invoice.SectionTypeStr,
                        DiscPrcnt = invoice.DiscPrcnt,
                        TotalDiscUSD = invoice.TotalDiscUSD,
                        TotalDiscRiel = invoice.TotalDiscRiel,
                        TaxPrcnt = invoice.TaxPrcnt,
                        TotalTaxUSD = invoice.TotalDiscUSD,
                        TotalTaxRiel = invoice.TotalTaxRiel,
                        ExchangeRate = invoice.ExchangeRate,
                        ServiceChargeUSD = invoice.ServiceChargeUSD,
                        ServiceChargeRiel = invoice.ServiceChargeRiel,
                        OtherChargeUSD = invoice.OtherChargeUSD,
                        OtherChargeRiel = invoice.OtherChargeRiel,
                        ShiftId = invoice.ShiftId,
                        ShiftStr = invoice.SectionStr,
                        BookingId = invoice.BookingId,
                        BookingStatus = invoice.BookingStatus,
                        ComissionPrcnt = invoice.ComissionPrcnt,
                        ComissionRate = invoice.ComissionRate, 
                        ComissionUSD = invoice.ComissionUSD,
                        ComssionRiel = invoice.ComssionRiel,
                        ComissionById = invoice.ComissionById,
                        ComissionByStr = invoice.ComissionByStr, 
                        SubTotalUSD = invoice.SubTotalUSD,
                        SubTotalRiel = invoice.SubTotalRiel,
                        GrandTotalUSD = invoice.GrandTotalUSD,
                        GrandTotalRiel =invoice.GrandTotalRiel,
                        ReceivedUSD = invoice.ReceivedUSD,
                        ReceivedRiel = invoice.ReceivedRiel,
                        CreateById = invoice.CreateById,
                        CreateByStr = invoice.CreateByStr,
                        CreateDate = invoice.CreateDate,
                        CloseById = invoice.CloseById,
                        CloseByStr = invoice.CloseByStr,
                        CloseDate = invoice.CloseDate,
                        CancelStatus = invoice.CancelStatus,
                        DocStatus = invoice.DocStatus,
                        Deleted = invoice.Deleted,
                        Description = invoice.Description,
                        PayDate = invoice.PayDate,
                        PayStatus = invoice.PayStatus,
                        InvoiceDetails = _context.InvoiceDetails.Where(s=>s.DocEntry==invoice.DocEntry).ToList(),
                        BusinessPartner = _context.BusinessPartners.FirstOrDefault(p=>p.VendorId==invoice.CustomerId)
                    }).ToList();
                return invoiceList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<List<Invoice>> GetSaleAging()
        {
            try
            {
                var saleAging = await _context.Invoices.Where(p => p.DocStatus == "P" && p.CustomerId != 0).ToListAsync();
                var saleAgingList = (from invoice in saleAging
                    select new Invoice
                    {
                        DocEntry = invoice.DocEntry,
                        InvCode = invoice.InvCode,
                        OrderCode = invoice.OrderCode,
                        Floor = invoice.Floor,
                        SectionId = invoice.SectionId,
                        SectionStr = invoice.SectionStr,
                        Duration = invoice.Duration,
                        FreeHour = invoice.FreeHour,
                        TotalHour = invoice.TotalHour,
                        SectionPrice = invoice.SectionPrice,
                        SectionAmount = invoice.SectionAmount,
                        GSectionId = invoice.GSectionId,
                        GSectionStr = invoice.GSectionStr,
                        SectionTypeId = invoice.SectionTypeId,
                        SectionTypeStr = invoice.SectionTypeStr,
                        DiscPrcnt = invoice.DiscPrcnt,
                        TotalDiscUSD = invoice.TotalDiscUSD,
                        TotalDiscRiel = invoice.TotalDiscRiel,
                        TaxPrcnt = invoice.TaxPrcnt,
                        TotalTaxUSD = invoice.TotalDiscUSD,
                        TotalTaxRiel = invoice.TotalTaxRiel,
                        ExchangeRate = invoice.ExchangeRate,
                        ServiceChargeUSD = invoice.ServiceChargeUSD,
                        ServiceChargeRiel = invoice.ServiceChargeRiel,
                        OtherChargeUSD = invoice.OtherChargeUSD,
                        OtherChargeRiel = invoice.OtherChargeRiel,
                        ShiftId = invoice.ShiftId,
                        ShiftStr = invoice.SectionStr,
                        BookingId = invoice.BookingId,
                        BookingStatus = invoice.BookingStatus,
                        ComissionPrcnt = invoice.ComissionPrcnt,
                        ComissionRate = invoice.ComissionRate, 
                        ComissionUSD = invoice.ComissionUSD,
                        ComssionRiel = invoice.ComssionRiel,
                        ComissionById = invoice.ComissionById,
                        ComissionByStr = invoice.ComissionByStr, 
                        SubTotalUSD = invoice.SubTotalUSD,
                        SubTotalRiel = invoice.SubTotalRiel,
                        GrandTotalUSD = invoice.GrandTotalUSD,
                        GrandTotalRiel =invoice.GrandTotalRiel,
                        ReceivedUSD = invoice.ReceivedUSD,
                        ReceivedRiel = invoice.ReceivedRiel,
                        CreateById = invoice.CreateById,
                        CreateByStr = invoice.CreateByStr,
                        CreateDate = invoice.CreateDate,
                        CloseById = invoice.CloseById,
                        CloseByStr = invoice.CloseByStr,
                        CloseDate = invoice.CloseDate,
                        CancelStatus = invoice.CancelStatus,
                        DocStatus = invoice.DocStatus,
                        Deleted = invoice.Deleted,
                        Description = invoice.Description,
                        PayDate = invoice.PayDate,
                        InvoiceDetails = _context.InvoiceDetails.Where(s=>s.DocEntry==invoice.DocEntry).ToList(),
                        BusinessPartner = _context.BusinessPartners.FirstOrDefault(p=>p.VendorId==invoice.CustomerId)
                    }).ToList();
                return saleAgingList;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<Invoice>> GetSaleAging(DateTime @from, DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");

                var saleAging = await _context.Invoices.Where(p => p.DocStatus == "P" && p.CustomerId != 0 && p.CreateDate >= from && p.CreateDate <= to).ToListAsync();
                var saleAgingList = (from invoice in saleAging
                    select new Invoice
                    {
                        DocEntry = invoice.DocEntry,
                        InvCode = invoice.InvCode,
                        OrderCode = invoice.OrderCode,
                        Floor = invoice.Floor,
                        SectionId = invoice.SectionId,
                        SectionStr = invoice.SectionStr,
                        Duration = invoice.Duration,
                        FreeHour = invoice.FreeHour,
                        TotalHour = invoice.TotalHour,
                        SectionPrice = invoice.SectionPrice,
                        SectionAmount = invoice.SectionAmount,
                        GSectionId = invoice.GSectionId,
                        GSectionStr = invoice.GSectionStr,
                        SectionTypeId = invoice.SectionTypeId,
                        SectionTypeStr = invoice.SectionTypeStr,
                        DiscPrcnt = invoice.DiscPrcnt,
                        TotalDiscUSD = invoice.TotalDiscUSD,
                        TotalDiscRiel = invoice.TotalDiscRiel,
                        TaxPrcnt = invoice.TaxPrcnt,
                        TotalTaxUSD = invoice.TotalDiscUSD,
                        TotalTaxRiel = invoice.TotalTaxRiel,
                        ExchangeRate = invoice.ExchangeRate,
                        ServiceChargeUSD = invoice.ServiceChargeUSD,
                        ServiceChargeRiel = invoice.ServiceChargeRiel,
                        OtherChargeUSD = invoice.OtherChargeUSD,
                        OtherChargeRiel = invoice.OtherChargeRiel,
                        ShiftId = invoice.ShiftId,
                        ShiftStr = invoice.SectionStr,
                        BookingId = invoice.BookingId,
                        BookingStatus = invoice.BookingStatus,
                        ComissionPrcnt = invoice.ComissionPrcnt,
                        ComissionRate = invoice.ComissionRate, 
                        ComissionUSD = invoice.ComissionUSD,
                        ComssionRiel = invoice.ComssionRiel,
                        ComissionById = invoice.ComissionById,
                        ComissionByStr = invoice.ComissionByStr, 
                        SubTotalUSD = invoice.SubTotalUSD,
                        SubTotalRiel = invoice.SubTotalRiel,
                        GrandTotalUSD = invoice.GrandTotalUSD,
                        GrandTotalRiel =invoice.GrandTotalRiel,
                        ReceivedUSD = invoice.ReceivedUSD,
                        ReceivedRiel = invoice.ReceivedRiel,
                        CreateById = invoice.CreateById,
                        CreateByStr = invoice.CreateByStr,
                        CreateDate = invoice.CreateDate,
                        CloseById = invoice.CloseById,
                        CloseByStr = invoice.CloseByStr,
                        CloseDate = invoice.CloseDate,
                        CancelStatus = invoice.CancelStatus,
                        DocStatus = invoice.DocStatus,
                        Deleted = invoice.Deleted,
                        Description = invoice.Description,
                        PayDate = invoice.PayDate,
                        InvoiceDetails = _context.InvoiceDetails.Where(s=>s.DocEntry==invoice.DocEntry).ToList(),
                        BusinessPartner = _context.BusinessPartners.FirstOrDefault(p=>p.VendorId==invoice.CustomerId)
                    }).ToList();
                return saleAgingList;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<int> RemoveInvoiceById(long docEntry)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.DocEntry == docEntry);
                _context.Invoices.RemoveRange(inv);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                 ex.GetBaseException();
                 throw;
            }
        }
        public async Task<Invoice> GetCreditInvoiceToPaymentById(long docEntry)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.DocEntry == docEntry && p.DocStatus == "P");
                var invDetails = await _context.InvoiceDetails.Where(p => p.DocEntry == inv.DocEntry).ToListAsync();
                var booking = await _context.BookingSections.FirstOrDefaultAsync(p => p.Id == inv.BookingId);
                inv.InvoiceDetails = invDetails;
                inv.BookingSection = booking;
                return inv;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<Invoice> GetCreditInvoiceToPaymentByInvCode(long invCode)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invCode && p.PayStatus == "O");
                return inv;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<Invoice> GetInvoiceViewerByInvCode(long invCode)
        {
            try
            {
                var inv = await _context.Invoices.FirstOrDefaultAsync(p => p.InvCode == invCode);
                var invDetails = await _context.InvoiceDetails.Where(p => p.DocEntry == inv.DocEntry).ToListAsync();
                inv.InvoiceDetails = invDetails;
                return inv;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
    }
}