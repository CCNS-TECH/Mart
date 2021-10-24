using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class POSsController:Controller
    {
        private readonly ICheckInSection<SectionCheckIn> _checkIn;
        private readonly IBookingSection<BookingSection> _booking;
        private readonly ISection<Section> _section;
        private readonly IOrder _order;
        private readonly IInvoice _invoice;

        public POSsController(ICheckInSection<SectionCheckIn> checkIn,
                                IBookingSection<BookingSection> booking,
                                ISection<Section> section,
                                IOrder order,
                                IInvoice invoice)
        {
            _checkIn = checkIn;
            _booking = booking;
            _section = section;
            _order = order;
            _invoice = invoice;
        }
        [HttpGet("pos/sections")]
        public IActionResult Pos()
        {
            return View();
        }
        [HttpGet("pos/section/get/{id}")]
        public async Task<JsonResult> GetSectionById(long id)
        {
            return new JsonResult(await _section.GetSection(id));
        }
        [HttpGet("pos/order/{id}")]
        public async Task<IActionResult> Order(long id)
        {
            var sections = await _section.GetSections();
            var section = sections.Where(p => p.Id == id).FirstOrDefault();
            var order = await _order.GetOrderBySectionId(id);
            var invoice = await _invoice.GetInvoiceById(id);
            ViewBag.section = section;
            ViewBag.Order = order;
            ViewBag.Inv = invoice;
            return View();
        }
        [HttpGet("pos/orderbyid/{id}")]
        public async Task<JsonResult> GetOrderById(long id)
        {
            try
            {
                var order = await _order.GetOrderBySectionId(id);
                return new JsonResult(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(404);
            }
        }
        [HttpPost("pos/section/checkin")]
        public async Task<IActionResult> CheckInSection(SectionCheckIn checkin)
        {
            if (ModelState.IsValid)
            {
                var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
                var usName = HttpContext.Session.GetString("OwnnerName");
                checkin.CheckedInById = usId;
                checkin.CheckedInByStr = usName;
                checkin.CheckedInDate=DateTime.Now;
                checkin.LineStatus = "O";
                
                var chckId =  await _checkIn.InsertCheckIn(checkin);
                if (chckId > 0)
                {
                    var section = new Section
                    {
                        Id = checkin.SectionId,
                        SectionEn =checkin.SectionStr,
                        LineStatus = "B",
                        CheckInId = chckId
                    };
                   await _section.CheckInSection(checkin.SectionId, section);
                }
                return RedirectToAction("pos","POSs");
            }
            return View("pos");
        }
        [HttpPost("pos/section/booking")]
        public async Task<IActionResult> BookingSection(BookingSection booking)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            
            booking.CreatedById = usId;
            booking.CreatedByName = usName;
            booking.ConfirmStatus = "N";
            booking.LineStatus = "O";
            booking.Deleted = "N";
            
            var chck =  await _booking.InsertBooking(booking);
            if (chck > 0)
            {
                var section = new Section
                {
                    LineStatus = "R",
                    BookingStatus = "Y",
                    BookingId = chck,
                    UpdatedDate = DateTime.Now,
                    UpdatedById = usId,
                    UpdatedByStr = usName
                };
                await _booking.CheckSectionBooking(booking.SectionId,section);
            }
            return RedirectToAction("pos","POSs");
        }
        [HttpGet("/pos/section/booking/{id}")]
        public async Task<JsonResult> GetSectionBookingById(long id)
        {
            var bookings = await _booking.GetBookingSections();
            return new JsonResult(bookings.Where(p=>p.SectionId==id).ToList());
        }
        [HttpPost("/pos/section/confirm/booking")]
        public async Task<JsonResult> ConfirmBookingById(long id,string message)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            
            var booking = await _booking.GetBookingSectionById(id);
            
            booking.ConfirmById = usId;
            booking.ConfirmByStr = usName;
            booking.ConfirmDate=DateTime.Now;
            booking.ConfirmStatus = "Y";
            booking.StartTime = DateTime.Now.TimeOfDay;
            
            var bookings = await _booking.ConfirmBooking(id,booking);
            if (bookings > 0)
            {
                var checkInsect = new SectionCheckIn
                {
                    SectionId = booking.SectionId,
                    GSectionId = booking.GSectionId,
                    TypeId = booking.TypeId,
                    CheckedInById = usId,
                    CheckedInByStr = usName,
                    CheckedInDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    StartTime = DateTime.Now,
                    LineStatus = "O",
                    Pax = booking.Pax,
                    Floor = booking.Floor,
                    Description = message
                };
                await ConfirmSectionBooking(id, checkInsect);
            }
            
            return new JsonResult(booking);
        }
        private async Task<int> ConfirmSectionBooking(long id, SectionCheckIn checkIn)
        {
            var section = await _section.GetSection(id);
            var bookings = await _booking.GetBookingSections();

            var checkbooking = bookings.Where(p => p.SectionId == id && p.LineStatus == "O").Count();

            if (checkbooking == 0)
                section.BookingStatus = "N";


            section.LineStatus = "Y";
            var scts = await _checkIn.InsertCheckIn(checkIn);
            if (scts > 0)
            {
                section.CheckInId = scts;
                return await _section.CheckInSection(id, section);
            }
            return 0;

        }

        [HttpPost("/pos/section/cancel/booking")]
        public async Task<JsonResult> CancelBookingById(long id,string message)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            
            var booking = await _booking.GetBookingSectionById(id);
            
            booking.CancelById = usId;
            booking.CancelByStr = usName;
            booking.CancelDate=DateTime.Now;
            booking.CancelTime = DateTime.Now.TimeOfDay;
            booking.LineStatus = "C";
            booking.CancelStatus = "Y";
            booking.Description = message;
            
            var bookings = await _booking.CancelBooking(id,booking);
            if (bookings > 0)
            {
                var sect = new Section
                {
                    LineStatus = "N",
                    BookingStatus = "N",
                    BookingId = 0,
                    UpdatedDate = DateTime.Now,
                    UpdatedById = usId,
                    UpdatedByStr = usName
                };
                await _booking.CheckSectionBooking(id,sect);
            }
            return new JsonResult(booking);
        }


        [HttpPost("section/transfer")]
        public async Task<IActionResult> SectionTransfer(SectionTransferViewModel transfer)
        {
            try
            {
                ModelState.Remove("Description");
                if (ModelState.IsValid)
                {
                    var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
                    var usName = HttpContext.Session.GetString("OwnnerName");
                    var section = await _section.GetSection(transfer.ToSectionId);

                    transfer.ToGroupSectionId = section.GSectionId;
                    transfer.ToGroupSectionStr = section.GroupSection.GSectionEn;
                    transfer.ToSectionStr = section.SectionEn;
                    transfer.SectionTypeId = section.SectionType.Id;
                    transfer.SectionTypeStr = section.SectionType.Type;
                    transfer.SectionPrice = section.Price;

                    /// update old table
                    var status = await _section.TransferSection(transfer.FromSectionId, transfer);
                    if (status > 0)
                    {
                        var sect = new Section
                        {
                            LineStatus = "N",
                            BookingStatus = "N",
                            BookingId = 0,
                            CheckInId = 0,
                            UpdatedDate = DateTime.Now,
                            UpdatedById = usId,
                            UpdatedByStr = usName
                        };
                        var sec = await _booking.CheckSectionBooking(transfer.FromSectionId, sect);
                        if (sec > 0)
                        {
                            var sect1 = new Section
                            {
                                LineStatus = "B",
                                BookingStatus = "N",
                                UpdatedDate = DateTime.Now,
                                UpdatedById = usId,
                                UpdatedByStr = usName,
                                CheckInId = status
                            };
                            await _section.TransferSectionCheckIn(transfer.ToSectionId, sect1);

                        }
                    }
                    return RedirectToAction("Pos", "POSs");
                }

                return RedirectToAction("Pos", "POSs");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return  RedirectToAction("Pos", "POSs");
            }
            
        }

        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.OrderCode != 0)
                {
                    var eff = await _order.UpdateOrder(order.DocEntry,order);
                    if (eff > 0)
                    {
                       var val = await _order.RemovedOrderDetail(order.DocEntry);                       
                           val = await CreateOrderDetail(order.DocEntry,order);

                        var sect = new Section
                        {
                            LineStatus = "B",
                            UpdatedDate = DateTime.Now
                        };
                        await _checkIn.CheckSectionPrintBill(order.SectionId, sect);
                        return Ok(val);
                    }
                }
                else
                {
                   var eff = await CreateNewOrder(order);
                   if (eff > 0)
                       return Ok(eff);
                   else
                       return Ok(0);
                }
                
            }    
            return Ok(Response.StatusCode);
        }

        private async Task<int> CreateNewOrder(Order order) 
        {
            if (order != null)
            {
                var ordernum = await _invoice.GetAutoNumber("O");
                
                order.OrderCode = ordernum.Next + 1;
                
                order.CancelById = 0;
                order.CloseById = 0;
                order.UpdatedById = 0;
                order.DocDate=DateTime.Now;
                order.OrderType = "-";
                order.TimeIn = order.TimeIn;
                order.TimeOut = order.TimeOut;
                var docEntry = await _order.InsertOrder(order);
                if (docEntry > 0)
                {
                    var eff = await CreateOrderDetail(docEntry,order);
                    if (eff == 0)
                        await _order.RemoveOrderById(docEntry);
                    else
                        await _invoice.UpdateAutoNumber("O", order.OrderCode);
                    
                    return eff;
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
                        var orderail = new OrderDetail
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
                            LineStatus = "O",
                            BillStatus = "N",
                            Deleted = "N",
                            LineFree = od.LineFree,
                            Description = od.Description,
                            
                        };
                        i++;
                        eff = await _order.InsertOrder01(orderail);
                    }
                    return eff;
                }
                
                return 0;
        }

        [HttpGet("invoice/get")]
        public async Task<JsonResult> GetDocNumInvoice(string autokey)
        {
            var invocenum = await _invoice.GetAutoNumber(autokey);
            invocenum.Next += 1;
            return new JsonResult(invocenum);
        }

        [HttpPost("invoice/create")]
        public async Task<JsonResult> CreateInvoice(Order order,string invoiceCode,string docEntry)
        {
            if (ModelState.IsValid)
            {
                if (invoiceCode != null)
                {
                    var invcode = invoiceCode.Trim();
                    var splitInvcod = invcode.Split("#");

                    var inv = await UpdateInvoiceAsync(order, long.Parse(splitInvcod[1]));
                    if (inv > 0)
                    {
                        var eff = await _invoice.RemoveInvoiceDetailById(long.Parse(docEntry));
                        
                            eff =  await AddInvoiceDetail(order,long.Parse(docEntry));
                        var sect = new Section
                        {
                            LineStatus = "C",
                            UpdatedDate = DateTime.Now
                        };
                        await _checkIn.CheckSectionPrintBill(order.SectionId, sect);
                        return new JsonResult(eff);
                    }
                    return new JsonResult(0);
                }
                else
                {
                    var invocenum = await _invoice.GetAutoNumber("I");
                    var invnum = invocenum.Next += 1;
                    var invcode =  await AddInvoice(order,invnum);
                    if (invcode > 0)
                    {
                        var edd= await AddInvoiceDetail(order, invcode);
                        if (edd > 0)
                        {
                            await _invoice.UpdateAutoNumber("I", invnum);
                            var sect = new Section
                            {
                                LineStatus = "C",
                                UpdatedDate = DateTime.Now
                            };
                            await _checkIn.CheckSectionPrintBill(order.SectionId,sect);
                            await _order.UpdateStatusOrder(order.OrderCode);
                            await UpdateCheckInSection(order.SectionId);
                        }
                        else
                        {
                            await _invoice.RemoveInvoiceById(invcode);
                            return new JsonResult(0);
                        }
                    }
                    return new JsonResult(invnum);
                }
                
            }
            return new JsonResult(0);
            
        }

        private async Task<int> UpdateCheckInSection(long id)
        {
            return await _checkIn.UpdateSectionCheckInById(id);
            
        }
        
        private async Task<int> UpdateInvoiceAsync(Order order,long invcode)
        {
            var invoice = new Invoice
            { 
                InvCode = invcode,
                
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
                CreateDate = DateTime.Now,
                TimeIn = order.TimeIn,
                TimeOut = order.TimeOut,
                Description = order.Description+"Update By UserName:"+order.OrderByStr+"And ID:"+order.OrderById,
            };
            var docEntry = await _invoice.UpdateInvoice(invoice);
            return docEntry;
        }
        private async Task<long> AddInvoice(Order order,long invcode)
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
                CreateDate = DateTime.Now,
                CloseById = 0,
                CancelStatus = "N",
                DocStatus = "O",
                PayStatus = "O",
                Deleted = "N",
                Description = order.Description,
                InvType = "-",
                TimeIn = order.TimeIn,
                TimeOut = order.TimeOut
            };
            var docEntry = await _invoice.InsertInvoice(invoice);
            return docEntry;
        }

        private async Task<int> AddInvoiceDetail(Order order,long docEntry)
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
                        DocDate = DateTime.Now.Date,
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
                        Description = od.Description,
                        
                    };
                    i++;
                    eff = await _invoice.InsertInvoiceDetail(invoiceDetail);
                }
                return eff;
            }
            
            return 0;
        }

        [HttpGet("/invoice/get/{id}")]
        public async Task<JsonResult> GetInvoiceById(long id)
        {
            var inv = await _invoice.GetInvoiceReBillById(id);
            return new JsonResult(inv);
        }
        [HttpGet("/order/get/new")]
        public async Task<JsonResult> GetNewOrder()
        {
            return new JsonResult(await _order.GetNewOrder());
        }
    }
}