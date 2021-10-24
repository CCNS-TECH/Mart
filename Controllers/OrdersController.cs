using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class OrdersController:Controller
    {
        private readonly IOrder _order;
        private readonly IInvoice _invoice;
        private readonly IPayment _payment;
        private readonly IWhs<Whs> _whs;
        private readonly IWhsDetail<Whs01>_whsDetail;
        private readonly IUoM<UoM> _uoM;
        private readonly IProduct<Item> _product;

        public OrdersController(IOrder order,
            IInvoice invoice,
            IPayment payment,
            IWhs<Whs> whs,
            IWhsDetail<Whs01> whsDetail,
            IUoM<UoM> uom,
            IProduct<Item> product)
        {
            _order = order;
            _invoice = invoice;
            _payment = payment;
            _whs = whs;
            _whsDetail = whsDetail;
            _uoM = uom;
            _product = product;
        }
        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost("order/walkin")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderCode = await CreateNewOrder(order);
                if (orderCode > 0)
                {
                    order.OrderCode = orderCode;
                    await AddInvoice(order);
                    return Ok(orderCode);
                }
                else
                    return Ok(0);
            }    
            return Ok(Response.StatusCode);
        }
        private async Task<long> CreateNewOrder(Order order) 
        {
            if (order != null)
            {
                var ordernum = await _invoice.GetAutoNumber("O");
                
                order.OrderCode = ordernum.Next + 1;
                
                order.CancelById = 0;
                order.CloseById = 0;
                order.UpdatedById = 0;
                order.DocDate=DateTime.Now;
                order.OrderType = "W";
                order.DocStatus = "C";
                order.OrderStatus = "C";
                
                var docEntry = await _order.InsertOrder(order);
                if (docEntry > 0)
                {
                    var eff = await CreateOrderDetail(docEntry,order);
                    if (eff == 0)
                        await _order.RemoveOrderById(docEntry);
                    else
                        await _invoice.UpdateAutoNumber("O", order.OrderCode);
                    
                    return order.OrderCode;
                }
            }
            return 0;
        }
        private async Task<int> CreateOrderDetail(long docEntry,Order order)
        {
                if (order.OrderDetails != null)
                {
                    var i = 1;
                    var eff = 0;
                    foreach (var od in order.OrderDetails)
                    {
                        var orderdetail = new OrderDetail
                        {
                            DocEntry = docEntry,
                            LineNumber = i,
                            ItemCode = od.ItemCode,
                            ItemStr = od.ItemStr,
                            ItemId = od.ItemId,

                            UoMId = od.UoMId,
                            UoMStr = od.UoMStr,
                            GUoMId = od.GUoMId,
                            GUoMStr = od.GUoMStr,

                            ItemTypeStr = od.ItemTypeStr,
                            Quantity = od.Quantity,
                            Cost = od.Cost,
                            UnitPrice = od.UnitPrice,
                            Currency = od.Currency,

                            DiscPrcnt = od.DiscPrcnt,
                            TotalDiscUSD = od.TotalDiscUSD,
                            TotalDiscRiel = od.TotalDiscRiel,

                            TotalTaxPrcnt = od.TotalTaxPrcnt,
                            TotalTaxUSD = od.TotalTaxUSD,
                            TotalTaxRiel = od.TotalTaxRiel,
                            TotalTaxRate = od.TotalTaxRate,

                            TotalLine = od.TotalLine,
                            CancelStatus = "N",
                            LineStatus = "C",
                            BillStatus = "N",
                            Deleted = "N",
                            LineFree = od.LineFree,
                            Description = od.Description
                        };
                        i++;
                        eff = await _order.InsertOrder01(orderdetail);
                    }
                    return eff;
                }
                return 0;
        }
        private async Task<long> AddInvoice(Order order)
        {
            var invocenum = await _invoice.GetAutoNumber("I");
            var invnum = invocenum.Next += 1;
            var invcode =  await AddInvoiceAsync(order,invnum);
            if (invcode > 0)
            {
                var edd= await AddInvoiceDetailAsync(order, invcode);
                if (edd > 0)
                {
                    await _invoice.UpdateAutoNumber("I", invnum);
                    await AddPaymentAsync(order, invnum);
                }
                else
                {
                    await _invoice.RemoveInvoiceById(invcode);
                    return 0;
                }
                return invnum;
            }
            
            return 0;
        }
        private async Task<long> AddInvoiceAsync(Order order,long invcode)
        {
            var invoice = new Invoice
            { 
                InvCode = invcode,
                OrderCode = order.OrderCode ,
                DiscPrcnt = order.DiscPrcnt,
                TotalDiscUSD = order.TotalDiscUSD,
                TotalDiscRiel = order.TotalDiscRiel,

                TaxPrcnt = order.TaxPrcnt,
                TotalTaxUSD = order.TotalTaxUSD,
                TotalTaxRiel =order.TotalTaxRiel ,
                ExchangeRate = order.ExchangeRate,

                ServiceChargeUSD = order.ServiceChargeUSD,
                ServiceChargeRiel = order.ServiceChargeRiel,
                OtherChargeUSD = order.OtherChargeUSD,
                OtherChargeRiel = order.OtherChargeRiel,

                ShiftId = order.ShiftId,        
                ShiftStr = order.ShiftStr,
                
                BookingId = order.BookingId,
                BookingStatus = order.BookingStatus,
                
                SectionId = order.SectionId,
                SectionStr = order.SectionStr,
                GSectionId = order.GSectoinId,
                GSectionStr = order.GSectoinStr,

                SectionTypeId = order.SectionTypeId,
                SectionTypeStr = order.SectionTypeStr,
                Duration = order.Duration,
                SectionPrice = order.SectionPrice,
                FreeHour = order.FreeHour,
                TotalHour = order.TotalHour,
                
                SectionAmount = order.SectionAmount,
                SubTotalUSD = order.SubTotalUSD,
                SubTotalRiel = order.SubTotalRiel,
                GrandTotalUSD = order.GrandTotalUSD,
                GrandTotalRiel = order.GrandTotalRiel,

                CreateById = order.OrderById,
                CreateByStr = order.OrderByStr,
                CloseById = order.OrderById,
                CloseByStr = order.OrderByStr,
                CloseDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CancelStatus = "N",
                DocStatus = "C",
                PayStatus = "Y",
                Deleted = "N",
                Description = order.Description,
                InvType = "W"
            };
            var docEntry = await _invoice.InsertInvoice(invoice);
            return docEntry;
        }

        private async Task<int> AddInvoiceDetailAsync(Order order,long docEntry)
        {
            if (order.OrderDetails != null)
            {
                var i = 1;
                var eff = 0;
                foreach (var od in order.OrderDetails)
                {
                    var invoiceDetail = new InvoiceDetail
                    {
                        DocEntry = docEntry,
                        LineNum = i,
                        ItemCode = od.ItemCode,
                        ItemStr = od.ItemStr,
                        ItemId = od.ItemId,
                        OrderById = order.OrderById,
                        OrderByStr = order.OrderByStr,

                        UoMId = od.UoMId,
                        UoMStr = od.UoMStr,
                        GUoMId = od.GUoMId,
                        GUoMStr = od.GUoMStr,
                        ItemTypeStr = od.ItemTypeStr,

                        Quantity = od.Quantity,
                        Cost = od.Cost,
                        SizeId = 1,
                        DocDate = DateTime.Now,
                        UnitPrice = od.UnitPrice,

                        Currency = od.Currency,
                        DiscPrcnt = od.DiscPrcnt,
                        TotalDiscUSD = od.TotalDiscUSD,
                        TotalDiscRiel = od.TotalDiscRiel,

                        TaxPrcnt = od.TotalTaxPrcnt,
                        TotalTaxUSD = od.TotalTaxUSD,
                        TotalTaxRiel = od.TotalTaxRiel,

                        TaxRate = od.TotalTaxRate,
                        TotalLine = od.TotalLine,
                        LineStatus = "O",
                        Deleted = "N",
                        
                        LineFree = od.LineFree,
                        Description = od.Description
                    };
                    i++;
                    eff = await _invoice.InsertInvoiceDetail(invoiceDetail);
                }
                return eff;
            }
            
            return 0;
        }
        private async Task<long> AddPaymentAsync(Order order,long invcod)
        {
                var receipt = await _invoice.GetAutoNumber("R");
                var paymentCode = receipt.Next + 1;
                var payment = new Payment
                {
                    PaymentCode =paymentCode,
                    DiscPrcnt=order.DiscPrcnt, 
                    TotalDiscUSD =order.TotalDiscUSD,
                    TotalDiscRiel =order.TotalDiscRiel,
                    TaxPrcnt =order.TaxPrcnt,
                    TotalTaxUSD =order.TotalTaxUSD,
                    TotalTaxRiel =order.TotalTaxRiel,
                    ExchangeRate =order.ExchangeRate,
                    ShiftId =order.ShiftId,
                    ShiftStr =order.ShiftStr,
                    ServiceChargeUSD =order.ServiceChargeUSD,
                    ServiceChargeRiel =order.ServiceChargeRiel,
                    OtherChargeUSD =order.OtherChargeUSD,
                    OtherChargeRiel =order.OtherChargeRiel,
                    SubTotalUSD =order.SubTotalUSD,
                    SubTotalRiel =order.SubTotalRiel,
                    GrandTotalUSD =order.GrandTotalUSD,
                    GrandTotalRiel =order.GrandTotalRiel,
                    ReceivedUSD = order.GrandTotalUSD,
                    ReceivedRiel =order.GrandTotalRiel,
                    ComissionPrcn = 0,
                    ComissionRate =0,
                    ComissionUSD =0,
                    ComissionRiel =0,
                    ComissionById =0,
                    ComissionByStr ="",
                    BookingId =0,
                    BookingStatus ="N",
                    PaymentDate =DateTime.Now,
                    ReceivedById =order.OrderById,
                    ReceivedByStr =order.OrderByStr,
                    MethodTypeId = 1,
                    MethodTypeStr ="Cash",
                    DocStatus ="C",
                    CancelById =0,
                    Deleted ="N",
                    Description =order.Description,
                    PayType ="W"
                };
                var docEntry = await _payment.InsertPayment(payment);
                if (docEntry > 0)
                {
                    var data = await AddPaymentDetail(order,docEntry,invcod);
                    if (data > 0)
                    {
                        await _invoice.UpdateAutoNumber("R",paymentCode);
                        return (payment.PaymentCode);
                    }
                    else
                    {
                        await _payment.RemovePaymentById(docEntry);
                        return (200);
                    }
                }

                return 0;
        }

        private async Task<int> AddPaymentDetail(Order order,long docEntry,long invcode)
        {
            if (order.OrderDetails.Count > 0)
            {
                var eff = 0;
                foreach (var pd in order.OrderDetails)
                {
                    var paymentdetail = new PaymentDetail
                    {          
                        DocEntry = docEntry,
                        InvCode = invcode,
                        OrderCode = order.OrderCode,
                        OrderById = order.OrderById,
                        OrderByStr = order.OrderByStr,
                        Floor = 0,
                        SectionId = 0,
                        SectionStr = "",
                        GSectionId = 0,
                        GSectionStr = "",
                        SectionTypeId = 0,
                        SectionTypeStr = "",
                        DocDate = DateTime.Now,
                        LineNumber = pd.LineNumber,
                        BaseLine = pd.LineNumber,
                        RefLine = pd.LineNumber,
                        ItemId = pd.ItemId,
                        ItemCode = pd.ItemCode,
                        ItemStr = pd.ItemStr,
                        ItemType = pd.ItemTypeStr,
                        Quantity = pd.Quantity,
                        Cost = pd.Cost,
                        Currency = pd.Currency,
                        UnitPrice = pd.UnitPrice,
                        UoMId = pd.UoMId,
                        UoMStr = pd.UoMStr,
                        GUoMId = pd.GUoMId,
                        GUoMStr = pd.GUoMStr,
                        DiscPrcnt = pd.DiscPrcnt,
                        TotalDiscUSD  = pd.TotalDiscUSD,
                        TotalDiscRiel = pd.TotalDiscRiel,
                        TaxPrcnt = pd.TotalTaxPrcnt,
                        TaxRate =  pd.TotalTaxRate,
                        TotalTaxUSD = pd.TotalTaxUSD,
                        TotalTaxRiel = pd.TotalTaxRiel,
                        TotalLine =  pd.TotalLine,
                        LineStatus = pd.LineStatus,
                        LineFree = pd.LineFree,
                        Deleted  = pd.Deleted,
                        Description = pd.Description

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
                    if(eff > 0)
                        await UpdateStockInventoryAsync(whsds);
                }
                return eff;
            }
            return 0;
        }
        private async Task<int> UpdateStockInventoryAsync(WhsDetailViewModel whsmodel)
        {
            try
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
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}