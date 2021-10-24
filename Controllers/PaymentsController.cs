using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Commissions;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class PaymentsController : Controller
    {
        private readonly IOrder _order;
        private readonly ISection<Section> _section;
        private readonly IInvoice _invoice;
        private readonly IPayment _payment;
        private readonly ICheckInSection<SectionCheckIn> _checkInSection;
        private readonly ICommission _commission;
        private readonly IWhs<Whs> _whs;
        private readonly IWhsDetail<Whs01>_whsDetail;
        private readonly IUoM<UoM> _uoM;
        private readonly IProduct<Item> _product;
        
        public PaymentsController(IOrder order,
                                    ISection<Section> section,
                                    IInvoice invoice,
                                    IPayment payment,
                                    ICheckInSection<SectionCheckIn> checkInSection,
                                    ICommission commission,
                                    IWhs<Whs> whs,
                                    IWhsDetail<Whs01> whsDetail,
                                    IUoM<UoM> uom,
                                    IProduct<Item> product)
        {
            _order = order;
            _section = section;
            _invoice = invoice;
            _payment = payment;
            _checkInSection = checkInSection;
            _commission = commission;
            _whs = whs;
            _whsDetail = whsDetail;
            _uoM = uom;
            _product = product;
        }
        [HttpGet("payment/pay/{id}")]
        public async Task<IActionResult> Payment(long id)
        {
            var sections = await _section.GetSections();
            var section =  sections.Where(p => p.Id == id).FirstOrDefault();
            var invoice = await _invoice.GetInvoiceToPaymentById(id);
            
            ViewBag.section = section;
            ViewBag.Invoice = invoice;
            if (invoice.BookingSection == null)
                ViewBag.CommissionCheck = "readonly";
            else
                ViewBag.CommissionCheck = "";
            return View();
        }

        [HttpPost("payment/pay")]
        public async Task<IActionResult> Payment(Payment payment,string invCode,long sectionId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var inv = invCode.Trim();
                    var invcod = inv.Split("#");
                    var receipt = await _invoice.GetAutoNumber("R");
                    payment.PaymentCode = receipt.Next + 1;
                    payment.PaymentDate = DateTime.Now;
                    payment.PayType = "-";

                    var book = new BookingSection { SectionId = sectionId };

                    payment.BookingSection = book;

                    var docEntry = await _payment.InsertPayment(payment);
                    if (docEntry > 0)
                    {
                        var data = await AddPaymentDetail(payment,docEntry,long.Parse(invcod[1]),"N");
                        if (data > 0)
                        {
                            await _invoice.UpdateAutoNumber("R",payment.PaymentCode);
                            await UpdateInvoiceAfterPaid(payment,long.Parse(invcod[1]));
                            await UpdateSectionAfterPaid(sectionId);
                            await UpdateOrderAfterPaid(payment, sectionId);
                            if (payment.ComissionPrcn > 0)
                                await AddCommissionAsync(payment);

                            var sectionCheckIn = new SectionCheckIn
                            {
                                SectionId = sectionId,
                                UpdatedInById = payment.ReceivedById,
                                UpdatedByStr = payment.ReceivedByStr
                            };
                            await _checkInSection.UpdateCheckInAfterPaid(sectionCheckIn);
                        
                            return Ok(payment.PaymentCode);
                        }
                        else
                        {
                           await _payment.RemovePaymentById(docEntry);
                           return Ok(200);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return Ok(501);
        }

        private async Task<int> AddPaymentDetail(Payment payment,long docEntry,long invcode,string credit)
        {
            if (payment.PaymentDetails.Count > 0)
            {
                var eff = 0;
                var line = 1;
                foreach (var pd in payment.PaymentDetails)
                {
                    var paymentdetail = new PaymentDetail
                    {          
                        DocEntry = docEntry,
                        InvCode = invcode,
                        OrderCode = pd.OrderCode,
                        OrderById = pd.OrderById,
                        OrderByStr = pd.OrderByStr,
                        Floor = pd.Floor,
                        SectionId = pd.SectionId,
                        SectionStr = pd.SectionStr,
                        GSectionId = pd.GSectionId,
                        GSectionStr = pd.GSectionStr,
                        SectionTypeId = pd.SectionTypeId,
                        SectionTypeStr = pd.SectionTypeStr,
                        DocDate = DateTime.Now.Date,
                        LineNumber = line,
                        BaseLine = pd.BaseLine,
                        RefLine = pd.RefLine,
                        ItemId = pd.ItemId,
                        ItemCode = pd.ItemCode,
                        ItemStr = pd.ItemStr,
                        ItemType = pd.ItemType,
                        Quantity = pd.Quantity,
                        Cost = pd.Cost,
                        Currency = pd.Currency,
                        UnitPrice = pd.UnitPrice,
                        UoMId = pd.UoMId,
                        UoMStr = pd.UoMStr,
                        GUoMId = pd.GUoMId,
                        GUoMStr = pd.GUoMStr,
                        WhsId = pd.WhsId,
                        WhsStr = pd.WhsStr,
                        DiscPrcnt = pd.DiscPrcnt,
                        TotalDiscUSD  = pd.TotalDiscUSD,
                        TotalDiscRiel = pd.TotalDiscRiel,
                        TaxPrcnt = pd.TaxPrcnt,
                        TaxRate = pd.TaxRate,
                        TotalTaxUSD = pd.TotalTaxUSD,
                        TotalTaxRiel = pd.TotalTaxRiel,
                        TotalLine = pd.TotalLine,
                        LineStatus = pd.LineStatus,
                        LineFree = pd.LineFree,
                        Deleted  = pd.Deleted,
                        Description =pd.Description
                    };
                    var whsds = new WhsDetailViewModel
                    {
                        ItemId = pd.ItemId,
                        ItemStr = pd.ItemStr,
                        UoMId = pd.UoMId,
                        GUoMId = pd.GUoMId,
                        Quantity = pd.Quantity
                    };
                  eff =  await _payment.InsertPaymentDetail(paymentdetail);
                  if(credit == "N")
                    await UpdateStockInventoryAsync(whsds);
                  line++;
                }

                return eff;
            }

            return 0;
        }

        private async Task<int> UpdateInvoiceAfterPaid(Payment payment,long invCode)
        {
            try
            {
                var inv = await _invoice.GetInvoiceToPaymentByCode(invCode);
                inv.ReceivedUSD = payment.ReceivedUSD;
                inv.ReceivedRiel = payment.ReceivedRiel;
                var Grandtotal = Convert.ToDecimal(payment.GrandTotalUSD.ToString("0.00"));
                var ReceivedUSD = Convert.ToDecimal(payment.ReceivedUSD.ToString("0.00"));
                if (Grandtotal <= ReceivedUSD)
                {
                    inv.DocStatus = "C";
                    inv.CloseDate=DateTime.Now;
                    inv.CloseById = payment.ReceivedById;
                    inv.CloseByStr = payment.ReceivedByStr;
                    inv.PayStatus = "Y";
                }
                else
                {
                    inv.DocStatus = "P";
                    inv.CloseById = payment.ReceivedById;
                    inv.CloseByStr = payment.ReceivedByStr;
                }

                await _invoice.UpdateInvoiceAfterPaid(inv);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }
        private async Task<int> UpdateSectionAfterPaid(long sectionId)
        {
            var section = await _section.GetSection(sectionId);
            section.BookingId = 0;
            section.BookingStatus = "N";
            section.LineStatus = "N";
            section.CheckInId = 0;

           return await _section.UpdateSectionAfterPaid(section);
        }

        private async Task<int> UpdateOrderAfterPaid(Payment payment,long sectionId)
        {
            var order = await _order.GetOrderBySectionId(sectionId);
            if (order != null)
            {
                var ord = new Order
                {
                    SectionId = sectionId,
                    OrderStatus = "C",
                    DocStatus = "C",
                    CloseById = payment.ReceivedById,
                    CloseByStr = payment.ReceivedByStr
                        
                };
              return  await _order.UpdateOrderAfterPaid(ord);
            }

            return 0;
        }
        private async Task<int> AddCommissionAsync(Payment payment)
        {
            var commission = new Commission
            {
                Description = payment.Description,
                ReceivedById = payment.ComissionById,
                ReceivedByStr = payment.ComissionByStr,
                DocDate = DateTime.Now,
                PaymentCode = payment.PaymentCode,
                GrandTotalUSD = payment.GrandTotalUSD,
                GrandTotalRiel = payment.GrandTotalRiel,
                Prcnt = payment.ComissionRate.ToString(),
                Rate = payment.ComissionRate,
                CommissionTotalUSD = payment.ComissionUSD,
                CommissionTotalRiel = payment.ComissionRiel,
                LineStatus = "P",
                AcceptById = 0,
                AcceptStatus = "O",
                Deleted = "N",
            };
            return await _commission.InsertCommission(commission);
        }
        private async Task<int> UpdateStockInventoryAsync(WhsDetailViewModel whsmodel)
        {
            var whs = await _whs.GetWhsByDefault();
            var whs01s = await _whsDetail.GetWhs01ByWhsId(whs.Id,whsmodel.ItemId);
            var quantity = await _uoM.ConvertQuantityByUoM(whsmodel.UoMId, whsmodel.GUoMId, whsmodel.Quantity);
            var item = await _product.GetItem(whsmodel.ItemId);
            whsmodel.WhsId = whs01s.WhsId;
            whsmodel.ItemId = whs01s.Item_Id;
            whsmodel.Quantity = quantity;
            await _product.IssueStockInventory(whsmodel);
            if (item.ManageBy == "B")
            {
                decimal currentQty = await _product.IssueBatchItem(whsmodel.ItemId, whsmodel.Quantity);

                while (currentQty > 0)
                {
                    currentQty = await _product.IssueBatchItem(whsmodel.ItemId, currentQty);
                }
            }
            /*else if (item.ManageBy == "S")
            {
                
            }*/

            return 0;
        }
        
        [HttpPost("payment/credit")]
        public async Task<IActionResult> PaymentCreate(CreditPaymentViewModel creditPayment)
        {
            if (ModelState.IsValid)
            {
                var inv = creditPayment.InvCode.Trim();
                var invcod = inv.Split("#");
                creditPayment.InvCode = invcod[1];
               var credit = await _payment.CreditPayment(creditPayment);
               var invs = await _invoice.GetInvoiceDetailByInvCode(long.Parse(creditPayment.InvCode));
               
               if (credit > 0)
               {
                   //loop cute stock
                   foreach (var invd in invs)
                   {
                       var whsds = new WhsDetailViewModel
                       {
                           ItemId = invd.ItemId,
                           ItemStr = invd.ItemStr,
                           UoMId = invd.UoMId,
                           GUoMId = invd.GUoMId,
                           Quantity = invd.Quantity
                       };
                       await UpdateStockInventoryAsync(whsds);
                   }
                   
                   await UpdateSectionAfterPaid(creditPayment.SectionId);
                   await UpdateOrderAfterCreditPayment(creditPayment);
                   if (creditPayment.CommissionPrcnt > 0)
                       await AddCommissionFromCreditPaymentAsync(creditPayment);

                   var sectionCheckIn = new SectionCheckIn
                   {
                       SectionId = creditPayment.SectionId,
                       UpdatedInById = creditPayment.CreateById,
                       UpdatedByStr = creditPayment.CreateByStr
                   };
                   await _checkInSection.UpdateCheckInAfterPaid(sectionCheckIn);
               }
               return Ok(credit);
            }
            return Ok(501);
        }

        [HttpGet("payment/credit/pay/{id}")]
        public async Task<IActionResult> CreditInvoiceToPayment(long id)
        {
            var invoice = await _invoice.GetCreditInvoiceToPaymentById(id);
            var section = await _section.GetSection(invoice.SectionId);
            
            ViewBag.CreditSection = section;
            ViewBag.CreditInvoice = invoice;
            return View();
        }
        [HttpPost("payment/credit/pay")]
        public async Task<IActionResult> CreditInvoiceToPayment(Payment payment,string invCode)
        {
            if (ModelState.IsValid)
            {
                var inv = invCode.Trim();
                var invcod = inv.Split("#");
                var receipt = await _invoice.GetAutoNumber("R");
                payment.PaymentCode = receipt.Next + 1;
                payment.PaymentDate = DateTime.Now;
                
                var docEntry = await _payment.InsertPayment(payment);
                if (docEntry > 0)
                {
                    var data = await AddPaymentDetail(payment,docEntry,long.Parse(invcod[1]),"Y");
                    if (data > 0)
                    {
                        await _invoice.UpdateAutoNumber("R",payment.PaymentCode);
                        await UpdateCreditInvoiceAfterPaid(payment,long.Parse(invcod[1]));
                        
                        return Ok(payment.PaymentCode);
                    }
                    else
                    {
                        await _payment.RemovePaymentById(docEntry);
                        return Ok(200);
                    }
                }
            }
            return Ok(501);
        }
        private async Task<int> UpdateOrderAfterCreditPayment(CreditPaymentViewModel creditPayment)
        {
            var order = await _order.GetOrderBySectionId(creditPayment.SectionId);
            if (order != null)
            {
                var ord = new Order
                {
                    SectionId = creditPayment.SectionId,
                    OrderStatus = "C",
                    DocStatus = "C",
                    CloseById = creditPayment.CreateById,
                    CloseByStr = creditPayment.CreateByStr
                        
                };
                return  await _order.UpdateOrderAfterPaid(ord);
            }

            return 0;
        }
        private async Task<int> UpdateCreditInvoiceAfterPaid(Payment payment, long invCode)
        {
            try
            {
                var inv = await _invoice.GetCreditInvoiceToPaymentByInvCode(invCode);
                inv.ReceivedUSD = payment.ReceivedUSD;
                inv.ReceivedRiel = payment.ReceivedRiel;
                var GrandTotal = Convert.ToDecimal(inv.GrandTotalUSD.ToString("0.00"));
                var ReceivedUSD = Convert.ToDecimal(payment.ReceivedUSD.ToString("0.00"));

                if (GrandTotal <= ReceivedUSD)
                {
                    inv.DocStatus = "C";
                    inv.CloseDate=DateTime.Now;
                    inv.CloseById = payment.ReceivedById;
                    inv.CloseByStr = payment.ReceivedByStr;
                    inv.PayStatus = "Y";
                }
                else
                {
                    inv.DocStatus = "P";
                    inv.CloseById = payment.ReceivedById;
                    inv.CloseByStr = payment.ReceivedByStr;
                }

                await _invoice.UpdateInvoiceAfterPaid(inv);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }
        private async Task<int> AddCommissionFromCreditPaymentAsync(CreditPaymentViewModel creditPayment)
        {
            var commission = new Commission
            {
                Description = creditPayment.Description,
                ReceivedById = creditPayment.BookingId,
                DocDate = DateTime.Now,
                PaymentCode = 0,
                GrandTotalUSD = creditPayment.GrandTotalUSD,
                GrandTotalRiel = creditPayment.GrandTotalRiel,
                Prcnt = creditPayment.CommissionPrcnt.ToString(),
                Rate = creditPayment.CommissionRate,
                CommissionTotalUSD = creditPayment.CommissionTotalUSD,
                CommissionTotalRiel = creditPayment.CommissionTotalRiel,
                LineStatus = "P",
                AcceptById = 0,
                AcceptStatus = "O",
                Deleted = "N",
            };
            return await _commission.InsertCommission(commission);
        }
    }
}