using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Commissions;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class ReportsController : Controller
    {
        private readonly IInvoice _invoice;
        private readonly IPayment _payment;
        private readonly ISeller _seller;
        private readonly IUser _user;
        private readonly ICommission _commission;
        private readonly IInventory _inventory;
        private readonly ICashInOut _cash;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ReportsController(IInvoice invoice,IPayment payment,
                                ISeller seller,IUser user,
                                ICommission commission,                                
                                IInventory inventory,
                                ICashInOut cash,
                                IWebHostEnvironment hostingEnvironment)
        {
            _invoice = invoice;
            _payment = payment;
            _seller = seller;
            _user = user;
            _commission = commission;
            _inventory = inventory;
            _cash = cash;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("report/invoice/pending")]
        public async Task<IActionResult> ReportInvoicePending()
        {
            return View(await _invoice.GetInvoicePending());
        }
        [HttpGet("report/invoices")]
        public IActionResult FindReportInvoice()
        {
            return View();
        }
        [HttpGet("report/payments")]
        public async Task<IActionResult> PaymentReport()
        {
            return View(await _payment.GetPayments());
        }
        [HttpGet("report/payment")]
        public IActionResult FindPaymentReport()
        {
            return View();
        }
        [HttpGet("/report/inv")]
        public async Task<JsonResult> GetInvoiceByDate(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var invs = await _seller.SumValueInvoices(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                var invds = new List<InvoiceDetail>();
                foreach (var i in invs)
                {
                    invds.AddRange(i.InvoiceDetails);
                }
                var foods = invds.Where(p => p.Item.CateId == 2).ToList();
                var beverages = invds.Where(p => p.Item.CateId == 3).ToList();
                var services = invs.Sum(p => p.ServiceChargeUSD);
                var otherCharges = invs.Sum(p => p.OtherChargeUSD);
                var sectionAmount = invs.Sum(p => p.SectionAmount);
                
                if (invds.Count > 0)
                {
                   return new JsonResult(new InvoiceViewModel
                   {
                       Food = foods.Sum(p=>p.TotalLine),
                       Beverage = beverages.Sum(p=>p.TotalLine),
                       Service = services,
                       OtherCharge = otherCharges,
                       SectionAmount = sectionAmount
                   });
                }
                else
                {
                    return new JsonResult(new InvoiceViewModel
                    {
                        Food = 0,
                        Beverage = 0,
                        Service = 0,
                        OtherCharge = 0,
                        SectionAmount = 0
                    });
                }
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var invs = await _seller.SumValueInvoices(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                var invds = new List<InvoiceDetail>();
                foreach (var i in invs)
                {
                    invds.AddRange(i.InvoiceDetails);
                }
                var foods = invds.Where(p => p.Item.CateId == 2).ToList();
                var beverages = invds.Where(p => p.Item.CateId == 3).ToList();
                var services = invs.Sum(p => p.ServiceChargeUSD);
                var otherCharges = invs.Sum(p => p.OtherChargeUSD);
                var sectionAmount = invs.Sum(p => p.SectionAmount);
                
                if (invds.Count > 0)
                {
                    return new JsonResult(new InvoiceViewModel
                    {
                        Food = foods.Sum(p=>p.TotalLine),
                        Beverage = beverages.Sum(p=>p.TotalLine),
                        Service = services,
                        OtherCharge = otherCharges,
                        SectionAmount = sectionAmount
                    });
                }
                else
                {
                    return new JsonResult(new InvoiceViewModel
                    {
                        Food = 0,
                        Beverage = 0,
                        Service = 0,
                        OtherCharge = 0,
                        SectionAmount = 0
                    });
                }
            }
            
        }
        [HttpGet("/report/inv/user")]
        public async Task<JsonResult> GetInvoiceByUserId(string from, string to,long id)
        {
            var emp = await _user.GetEmployee(id);
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var invs = await _seller.GetInvoicesByUserId(DateTime.Now.Date,DateTime.Now.Date.AddDays(1),id);
                var invds = new List<InvoiceDetail>();
                foreach (var i in invs)
                {
                    invds.AddRange(i.InvoiceDetails);
                }
                var foods = invds.Where(p => p.Item.CateId == 2).ToList();
                var beverages = invds.Where(p => p.Item.CateId == 3).ToList();
                var services = invs.Sum(p => p.ServiceChargeUSD);
                var otherCharges = invs.Sum(p => p.OtherChargeUSD);
                var sectionAmount = invs.Sum(p => p.SectionAmount);
                var inv = new InvoiceViewModel
                {
                    Food = foods.Sum(p=>p.TotalLine),
                    FoodQty = foods.Sum(p=>p.Quantity),
                    Beverage = beverages.Sum(p=>p.TotalLine),
                    BeverageQty = beverages.Sum(p=>p.Quantity),
                    Service = services,
                    OtherCharge = otherCharges,
                    SectionAmount = sectionAmount,
                    Employee = emp
                };
                return new JsonResult(inv);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var invs = await _seller.GetInvoicesByUserId(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1),id);
                var invds = new List<InvoiceDetail>();
                foreach (var i in invs)
                {
                    invds.AddRange(i.InvoiceDetails);
                }
                var foods = invds.Where(p => p.Item.CateId == 2).ToList();
                var beverages = invds.Where(p => p.Item.CateId == 3).ToList();
                var services = invs.Sum(p => p.ServiceChargeUSD);
                var otherCharges = invs.Sum(p => p.OtherChargeUSD);
                var sectionAmount = invs.Sum(p => p.SectionAmount);
            
                var inv = new InvoiceViewModel
                {
                    Food = foods.Sum(p=>p.TotalLine),
                    FoodQty = foods.Sum(p=>p.Quantity),
                    Beverage = beverages.Sum(p=>p.TotalLine),
                    BeverageQty = beverages.Sum(p=>p.Quantity),
                    Service = services,
                    OtherCharge = otherCharges,
                    SectionAmount = sectionAmount,
                    Employee = emp
                };
                return new JsonResult(inv);
            }
        }
        [HttpGet("report/order/value")]
        public async Task<decimal> GetValueOrder()
        {
            var orders = await _seller.SumGrandTotalOrder();
            return orders.Sum(p => p.GrandTotalUSD);
        }
        [HttpGet("report/invoice/value")]
        public async Task<decimal> GetValueInvoice()
        {
            var orders = await _seller.SumGrandTotalInvoice();
            return orders.Sum(p => p.GrandTotalUSD);
        }
        [HttpGet("report/booked/value")]
        public async Task<int> GetCountBooked()
        {
            return await _seller.CountSectionBooked();
        }
        [HttpGet("report/checked/value")]
        public async Task<int> GetCountChecked()
        {
            return await _seller.CountSectionCheckIn();
        }
        [HttpGet("report/top/sale")]
        public async Task<JsonResult> GetTopSale()
        {
            return new JsonResult(await _seller.GetTopSale());
        }
        [HttpGet("report/purchase")]
        public IActionResult PurchaseReport(string from, string to)
        {
            return View();
        }
        [HttpGet("report/goodsissue")]
        public async Task<IActionResult> GoodsIssueReport(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var goodsissues = await _seller.GoodsIssueList(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                return View(goodsissues);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var prchs = await _seller.GoodsIssueList(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                return View(prchs);
            }
        }
        [HttpGet("report/goodsreceipt")]
        public async Task<IActionResult> GoodsReceiptReport(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var goodsissues = await _seller.GoodsReceiptList(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                return View(goodsissues);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var goodsissues = await _seller.GoodsReceiptList(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                return View(goodsissues);
            }
        }
        [HttpGet("report/inventory")]
        public async Task<IActionResult> InventoryReport()
        {
            var inventorys = await _seller.ItemList();
            return View(inventorys);
            
        }

        [HttpGet("report/aging")]
        public async Task<IActionResult> SaleAging(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var saleAging = await _invoice.GetSaleAging();
                ViewData["SaleAgingTotalUSD"] = saleAging.Sum(p => p.GrandTotalUSD);
                return View(saleAging);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var saleAging = await _invoice.GetSaleAging(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["SaleAgingTotalUSD"] = saleAging.Sum(p => p.GrandTotalUSD);
                return View(saleAging);
            }
            
        }
        [HttpGet]
        public IActionResult SaleAgingReport()
        {
            return View();
        }

        [HttpGet("/invoice/viewer/{id}")]
        public async Task<IActionResult> InvoiceViewer(long id)
        {
            var inv =await _invoice.GetInvoiceViewerByInvCode(id);
            return View(inv);
        }
        [HttpGet("/commission/list")]
        public async Task<IActionResult> CommissionLists(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var commissions = await _commission.GetCommissions(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                ViewData["CommissionsTotalUSD"] = commissions.Sum(p => p.CommissionTotalUSD);
                return View(commissions);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var commissions = await _commission.GetCommissions(DateTime.Parse(datefrm),DateTime.Parse(dateto).Date.AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["CommissionsTotalUSD"] = commissions.Sum(p => p.CommissionTotalUSD);
                return View(commissions);
            }
        }
        [HttpPost("/commission/confirm")]
        public async Task<IActionResult> ConfirmCommission(Commission commission)
        {
            if (string.IsNullOrEmpty(commission.PaymentCode.ToString())
                && string.IsNullOrEmpty(commission.AcceptById.ToString())
                && string.IsNullOrEmpty(commission.AcceptByStr))
            {
                return Ok(0);
            }
            else
            {
               var confirm = await _commission.ConfirmCommission(commission);
               return Ok(confirm);
            }
        }
        [HttpGet("/payment/id/{id}")]
        public async Task<IActionResult> CommissionViewer(long id)
        {
            var payment = await _payment.GetPaymentById(id);

            var invoice = payment.Invoices.FirstOrDefault();
            ViewBag.TimeIn = invoice.TimeIn;
            ViewBag.TimeOut = invoice.TimeOut;

            return View(payment);
        }

        [HttpGet("/purchase/viewer/{id}")]
        public async Task<IActionResult> PurchaseViewer(long id)
        {
            var purchs = await _inventory.GetPurchaseByCode(id);
            return View(purchs);
        }
        [HttpGet("/report/topsales")]
        public async Task<IActionResult> TopSaleReport(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var topSales = await _seller.GetTopSale(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                ViewData["TopSalesTotalUSD"] = topSales.Sum(p => p.TotalLine);
                return View(topSales);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var topSales = await _seller.GetTopSale(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["TopSalesTotalUSD"] = topSales.Sum(p => p.TotalLine);
                return View(topSales);
            }
        }
        [HttpGet("/report/sales")]
        public async Task<IActionResult> SaleReport(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var saleReported = await _seller.GetSaleReported(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                ViewData["SalesTotalUSD"] = saleReported.Sum(p => p.TotalLine);
                return View(saleReported);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var saleReported = await _seller.GetSaleReported(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["SalesTotalUSD"] = saleReported.Sum(p => p.TotalLine);
                return View(saleReported);
            }
        }

        [HttpGet("/get/sale/aging")]
        public async Task<IActionResult> GetSaleAgingJsonAsync(string from,string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var saleAging = await _invoice.GetSaleAging();
                ViewData["SaleAgingTotalUSD"] = saleAging.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= saleAging.Count,
                    recordsFiltered= saleAging.Count,
                    data = saleAging
                };
                return new JsonResult(json);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var saleAging = await _invoice.GetSaleAging(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["SaleAgingTotalUSD"] = saleAging.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= saleAging.Count,
                    recordsFiltered= saleAging.Count,
                    data = saleAging
                };
                return new JsonResult(json);
            }
        }
        [HttpGet("/get/payment/paid")]
        public async Task<IActionResult> GetPaymentReportJsonAsync(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var invs = await _payment.GetPaymentByDate(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
                ViewBag.From = DateTime.Now.ToString("MM/dd/yyyy");
                ViewBag.To = DateTime.Now.ToString("MM/dd/yyyy");
                ViewData["GrandTotalPayment"] = invs.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= invs.Count,
                    recordsFiltered= invs.Count,
                    data = invs
                };
                return new JsonResult(json);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var invs = await _payment.GetPaymentByDate(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["GrandTotalPayment"] = invs.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= invs.Count,
                    recordsFiltered= invs.Count,
                    data = invs
                };
                return new JsonResult(json);
            }
        }
        [HttpGet("/get/invoice/lists")]
        public async Task<IActionResult> GetInvoiceReportAsync(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var invs = await _invoice.FindInvoiceByDate(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
                ViewBag.From = DateTime.Now.ToString("MM/dd/yyyy");
                ViewBag.To = DateTime.Now.ToString("MM/dd/yyyy");
                ViewData["GrandTotalInvoice"] = invs.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= invs.Count,
                    recordsFiltered= invs.Count,
                    data = invs
                };
                return new JsonResult(json);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var invs = await _invoice.FindInvoiceByDate(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["GrandTotalInvoice"] = invs.Sum(p => p.GrandTotalUSD);
                var json = new
                {
                    draw = 1,
                    recordsTotal= invs.Count,
                    recordsFiltered= invs.Count,
                    data = invs
                };
                return new JsonResult(json);
            }
        }
        [HttpGet("/sale/export")]
        public async Task<IActionResult> ExportSaleReport(string from, string to)
        {
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                List<Invoice> invoices = await _invoice.GetSaleAging(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                FileStreamResult fr = ExportToExcel.CreateExcelFile.StreamExcelDocument(invoices, "saleReport.xlsx");
                return fr;
            }
            return Ok(404);
        }

        [HttpGet("/get/purchase/list")]
        public async Task<IActionResult> GetPurchaseRportAsync(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var prchs = await _seller.PurchaseLists(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                var json = new
                {
                    draw = 1,
                    recordsTotal= prchs.Count,
                    recordsFiltered= prchs.Count,
                    data = prchs
                };
                return new JsonResult(json);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var prchs = await _seller.PurchaseLists(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                var json = new
                {
                    draw = 1,
                    recordsTotal= prchs.Count,
                    recordsFiltered= prchs.Count,
                    data = prchs
                };
                return new JsonResult(json);
            }
        }
        [HttpGet("/report/booking")]
        public async Task<IActionResult> BookingReport(string from, string to)
        {
            var payment = (await _payment.GetPayments()).Where(pay=>pay.BookingId != 0);

            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var paid = payment.Where(p=>p.PaidDate >= DateTime.Now.Date && p.PaidDate<=DateTime.Now.Date.AddDays(1));
                ViewData["CommissionTotalUSD"] = paid.Sum(p => p.ComissionUSD);
                return View(paid);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-" + dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2] + "-" + dto[0] + "-" + dto[1];
                var paid = payment.Where(p => p.PaidDate >= DateTime.Parse(datefrm) && p.PaidDate <= DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["CommissionTotalUSD"] = paid.Sum(p => p.ComissionUSD);
                return View(paid);
            }
        }

        [HttpGet("/report/cashinout")]
        public async Task<IActionResult> CashInOutReport(string from, string to)
        {
            var cash = await _cash.GetCashOuts();

            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var CashInOut = cash.Where(p => p.DocDate >= DateTime.Now.Date && p.DocDate <= DateTime.Now.Date.AddDays(1));

                ViewData["SaleAmount"] = CashInOut.Sum(p => p.SaleAmount);
                return View(CashInOut);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-" + dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2] + "-" + dto[0] + "-" + dto[1];
                var CashInOut = cash.Where(p => p.DocDate >= DateTime.Parse(datefrm) && p.DocDate <= DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                ViewData["SaleAmount"] = CashInOut.Sum(p => p.SaleAmount);
                return View(CashInOut);
            }
        }

        [HttpGet("report/stock")]
        public async Task<IActionResult> StockReport()
        {
            var itemList = await _inventory.GetItems();
            return View(itemList);
        }

    }
}