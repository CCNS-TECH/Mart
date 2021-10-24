using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.UriParser;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;
namespace resm_app.Models.Repositories
{
    public class ReportRepository:ISeller
    {
        private readonly AppDbContext _context;
        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetSellerById(long saleId)
        {
            try
            {
                var sellers = await _context.Orders.Where(p => p.OrderById == saleId && p.OrderStatus=="C").ToListAsync();
                return sellers;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<List<Item>> GetItemByType(string type)
        {
            try
            {
                var items = await _context.Items.Where(p => p.Inv==type).ToListAsync();
                return items;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<Section>> GetSections()
        {
            try
            {
                var sections = await _context.Sections.Where(p=>p.Deleted=="N").ToListAsync();
                return sections;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<int> CountSectionBooked()
        {
            try
            {
                var booked = await _context.BookingSections.Where(p => p.LineStatus == "O").ToListAsync();
                return booked.Count;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<int> CountSectionCheckIn()
        {
            try
            {
                var checkId = await _context.SectionCheckIns.Where(p => p.LineStatus == "O").ToListAsync();
                return checkId.Count;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
            
        }
        public async Task<List<Order>> SumGrandTotalOrder()
        {
            try
            {
                var orders = await _context.Orders.Where(p => p.OrderStatus == "O" && p.DocStatus=="O").ToListAsync();
                return orders;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public Task<List<Batch>> GetItemExp()
        {
            try
            {
                return _context.Batches.Where(p => p.EXP >= DateTime.Now.AddMonths(6)).ToListAsync();
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<List<Invoice>> SumGrandTotalInvoice()
        {
            try
            {
                var invs = await _context.Invoices.Where(p => p.PayStatus == "O" && p.CustomerId == 0).ToListAsync();
                return invs;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<List<Invoice>> GetInvoicesByUserId(DateTime from,DateTime to,long id)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");
                var invs = await _context.Invoices.Where(p => p.CloseDate >= from && p.CloseDate <= to && p.CloseById==id).ToListAsync();
                var invList = (from invoice in invs
                    select new Invoice
                    {
                        DocEntry = invoice.DocEntry,
                        InvCode = invoice.InvCode,
                        OrderCode = invoice.OrderCode,
                        ServiceChargeUSD = invoice.ServiceChargeUSD,
                        ServiceChargeRiel = invoice.ServiceChargeRiel,
                        OtherChargeUSD = invoice.OtherChargeUSD,
                        OtherChargeRiel = invoice.OtherChargeRiel,
                        SubTotalUSD = invoice.SubTotalUSD,
                        SubTotalRiel = invoice.SubTotalRiel,
                        GrandTotalUSD = invoice.GrandTotalUSD,
                        GrandTotalRiel =invoice.GrandTotalRiel,
                        ReceivedUSD = invoice.ReceivedUSD,
                        ReceivedRiel = invoice.ReceivedRiel,
                        SectionAmount = invoice.SectionAmount,
                        InvoiceDetails =(from inv in _context.InvoiceDetails.Where(p=>p.DocEntry==invoice.DocEntry)
                            select new InvoiceDetail
                            {
                                Id = inv.Id,
                                ItemCode = inv.ItemCode,
                                ItemStr = inv.ItemStr,
                                Quantity = inv.Quantity,
                                UnitPrice = inv.UnitPrice, 
                                TotalLine = inv.TotalLine,
                                Currency = inv.Currency,
                                Item = _context.Items.FirstOrDefault(p=>p.Id==inv.ItemId)
                            }).ToList()
                    }).ToList();
                return invList;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<Invoice>> SumValueInvoices(DateTime from, DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");
                var invs = await _context.Invoices.Where(p => p.CloseDate >= from && p.CloseDate <= to).ToListAsync();
                var invList = (from invoice in invs
                    select new Invoice
                    {
                        DocEntry = invoice.DocEntry,
                        InvCode = invoice.InvCode,
                        OrderCode = invoice.OrderCode,
                        ServiceChargeUSD = invoice.ServiceChargeUSD,
                        ServiceChargeRiel = invoice.ServiceChargeRiel,
                        OtherChargeUSD = invoice.OtherChargeUSD,
                        OtherChargeRiel = invoice.OtherChargeRiel,
                        SubTotalUSD = invoice.SubTotalUSD,
                        SubTotalRiel = invoice.SubTotalRiel,
                        GrandTotalUSD = invoice.GrandTotalUSD,
                        GrandTotalRiel =invoice.GrandTotalRiel,
                        ReceivedUSD = invoice.ReceivedUSD,
                        ReceivedRiel = invoice.ReceivedRiel,
                        SectionAmount = invoice.SectionAmount,
                        InvoiceDetails =(from inv in _context.InvoiceDetails.Where(p=>p.DocEntry==invoice.DocEntry)
                            select new InvoiceDetail
                            {
                                Id = inv.Id,
                                ItemCode = inv.ItemCode,
                                ItemStr = inv.ItemStr,
                                Quantity = inv.Quantity,
                                UnitPrice = inv.UnitPrice, 
                                TotalLine = inv.TotalLine,
                                Currency = inv.Currency,
                                Item = _context.Items.FirstOrDefault(p=>p.Id==inv.ItemId)
                            }).ToList()
                    }).ToList();
                return invList;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<Purchase>> PurchaseLists(DateTime from, DateTime to)
        {
            try
            {
                var purch = await _context.Purchases.Where(p=>p.DocStatus == "Y" && p.PurchaseDate >= from && p.PurchaseDate <= to).ToListAsync();
                var prchlists = (from pch in purch
                    select new Purchase()
                    {
                        DocEntry = pch.DocEntry,
                        InvCode = pch.InvCode,
                        VendorId = pch.VendorId,
                        VendorStr = pch.VendorStr,
                        CreateDate = pch.CreateDate,
                        CreateById = pch.CreateById,
                        DiscPrcnt = pch.DiscPrcnt,
                        DiscTotal = pch.DiscTotal,
                        PurchaseDate = pch.PurchaseDate,
                        TaxPrcnt = pch.TaxPrcnt,
                        TaxTotal = pch.TaxTotal,
                        CreateByName = pch.CreateByName,
                        SubTotalRiel = pch.SubTotalRiel,
                        SubTotalUSD = pch.SubTotalUSD,
                        GrandTotalRiel = pch.GrandTotalRiel,
                        GrandTotalUSD = pch.GrandTotalUSD,
                        purchase01s = _context.Purchase01s.Where(p=>p.DocEntry==pch.DocEntry).ToList()
                    }).ToList();
                
                return prchlists;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<GoodsIssue01>> GoodsIssueList(DateTime from, DateTime to)
        {
            try
            {
                var goodsissues = await _context.GoodsIssue01s.Where(p => p.DocDate >= from && p.DocDate <= to)
                    .ToListAsync();
                return goodsissues;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<GoodsReceipt01>> GoodsReceiptList(DateTime @from, DateTime to)
        {
            try
            {
                var goodsreceipts = await _context.GoodsReceipt01s.Where(p => p.DocDate >= from && p.DocDate <= to)
                    .ToListAsync();
                return goodsreceipts;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<Item>> ItemList()
        {
            try
            {
                var items = await _context.Items.Where(p => p.Inv == "Y").ToListAsync();
                var itemlists = (from i in items
                    select new Item
                    {
                        Id = i.Id,
                        ItemCode = i.ItemCode,
                        ItemEn = i.ItemEn,
                        ItemStr = i.ItemStr,
                        InStock = i.InStock,
                        Inv = i.Inv,
                        InvUoMId = i.InvUoMId,
                        InvUoMStr = i.InvUoMStr,
                        CreatedDate = i.CreatedDate,
                        Category = _context.Categories.FirstOrDefault(p=>p.CateId==i.CateId)
                    }).ToList();
                return itemlists;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<List<InvoiceDetail>> GetTopSale()
        {
            var detail = await _context.InvoiceDetails.ToListAsync();

            var list = (from s in detail
                group s by new { s.ItemStr, s.UoMStr } into g

                select new InvoiceDetail
                {
                    ItemCode = g.Max(s => s.ItemCode),
                    ItemStr = g.Key.ItemStr,
                    Quantity = g.Sum(s => s.Quantity),
                    UoMStr = g.Key.UoMStr,
                    UnitPrice = g.Max(s => s.UnitPrice)

                }).ToList();

            return list;
        }
        public async Task<List<InvoiceDetail>> GetTopSale(DateTime from, DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");
                var detail = await _context.InvoiceDetails.Where(d => d.DocDate >= from && d.DocDate <= to).ToListAsync();

                var list = (from s in detail
                    group s by new { s.ItemCode,s.UoMStr,s.UnitPrice} into g
                    select new InvoiceDetail
                    {
                        ItemCode = g.Key.ItemCode,
                        ItemStr = g.Max(p=>p.ItemStr),
                        Quantity = g.Sum(s => s.Quantity),
                        UoMStr = g.Key.UoMStr,
                        UnitPrice = g.Key.UnitPrice,
                        TotalLine=(g.Sum(p=>p.Quantity)* g.Key.UnitPrice)
                    }).OrderByDescending(p=>p.Quantity).ToList();
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
            
        }
        public async Task<List<InvoiceDetail>> GetSaleReported(DateTime from, DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");
                var detail = await _context.InvoiceDetails.Where(d => d.DocDate >= from && d.DocDate <= to).ToListAsync();

                var list = (from s in detail
                    group s by new { s.ItemCode,s.UoMStr,s.UnitPrice,s.DocDate} into g
                    select new InvoiceDetail
                    {
                        ItemCode = g.Key.ItemCode,
                        ItemStr = g.Max(p=>p.ItemStr),
                        Quantity = g.Sum(s => s.Quantity),
                        UoMStr = g.Key.UoMStr,
                        DocDate = g.Key.DocDate,
                        UnitPrice = g.Key.UnitPrice,
                        TotalLine=(g.Sum(p=>p.Quantity)* g.Key.UnitPrice)
                    
                    }).OrderByDescending(p=>p.DocDate).ToList();
                return list;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
            
        }

        public async Task<List<Payment>> GetPaymentListAsync(DateTime from, DateTime to)
        {
            try
            {
                from += TimeSpan.Parse("06:00:00");
                to += TimeSpan.Parse("05:59:59");

                var payments = await _context.Payments.Where(p => p.PaymentDate >= from  && p.PaymentDate <= to)
                    .ToListAsync();
              
                return  payments;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
        public async Task<List<Batch>> GetExpiredDate()
        {
            try
            {
                var batchs = await _context.Batches.Where(b=>b.EXP >= DateTime.Now.Date &&  b.EXP <= DateTime.Now.Date.AddMonths(3) && b.Quantity > 0).ToListAsync();
                return batchs;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
    }
}