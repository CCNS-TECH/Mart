using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Models.Repositories
{
    public class OrderRepository:IOrder
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertOrder(Order order)
        {
            try
            {
                order.DocTime = DateTime.Now.TimeOfDay;
                await _context.Orders.AddAsync(order);
                var i = await _context.SaveChangesAsync();
                var id = await _context.Orders.Select(p => p.DocEntry).MaxAsync();
                return id;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return 0;
            }
            
        }

        public async Task<int> InsertOrder01(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            return await _context.SaveChangesAsync();
        }
        public async Task<Order> GetOrderBySectionId(long id)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(p => p.SectionId == id && p.OrderStatus=="O");
                var orderdetails = await _context.OrderDetails.Where(p => p.DocEntry == order.DocEntry).ToListAsync();
                order.OrderDetails = orderdetails;

                return order;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return  null;
            }
            
        }

        public Task<List<Order>> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateOrder(long docEntry,Order order)
        {
            try
            {
                var ord = await _context.Orders.FirstOrDefaultAsync(p => p.OrderCode == order.OrderCode && p.DocEntry==docEntry);
                ord.Duration = order.Duration;
                ord.SectionPrice = order.SectionPrice;
                ord.SectionAmount = order.SectionAmount;
                ord.DiscPrcnt = order.DiscPrcnt;
                ord.TotalDiscUSD = order.TotalDiscUSD;
                ord.TotalDiscRiel = order.TotalDiscRiel;
                ord.TaxPrcnt = order.TaxPrcnt;
                ord.TotalTaxUSD = order.TotalTaxUSD;
                ord.TotalTaxRiel = order.TotalTaxRiel;
                ord.OtherChargeRiel = order.OtherChargeRiel;
                ord.OtherChargeUSD = order.OtherChargeUSD;
                ord.ServiceChargeRiel = order.ServiceChargeRiel;
                ord.ServiceChargeUSD = order.ServiceChargeUSD;
                ord.SubTotalUSD = order.SubTotalUSD;
                ord.SubTotalRiel = order.SubTotalRiel;
                ord.GrandTotalUSD = order.GrandTotalUSD;
                ord.GrandTotalRiel = order.GrandTotalRiel;
                ord.UpdatedDate=DateTime.Now;
                ord.UpdatedById = order.UpdatedById;
                ord.UpdatedByStr = order.UpdatedByStr;
                ord.FreeHour = order.FreeHour;
                ord.TotalHour = order.TotalHour;
                ord.TimeIn = order.TimeIn;
                ord.TimeOut = order.TimeOut;
                ord.DiscPrcnt = order.DiscPrcnt;

                _context.Orders.Update(ord);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
            
        }
        public async Task<int> RemovedOrderDetail(long docEntry)
        {
            var orders = await _context.OrderDetails.Where(p => p.DocEntry == docEntry).ToListAsync();
            _context.OrderDetails.RemoveRange(orders);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> RemoveOrderById(long id)
        {
            var order = await _context.Orders.FirstAsync(p => p.DocEntry == id);
            _context.Orders.RemoveRange(order);
            return await _context.SaveChangesAsync();
        }

        public Task<int> DeletedOrderById(long id, Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetBillByOrderId(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> TransferSectionOrder(SectionTransferViewModel transfer)
        {
            try
            {
                var ord = await _context.Orders.FirstOrDefaultAsync(p => p.SectionId == transfer.FromSectionId);
            
                ord.SectionId = transfer.ToSectionId;
                ord.SectionStr = transfer.ToSectionStr;
                ord.GSectoinId = transfer.ToGroupSectionId;
                ord.GSectoinStr = transfer.ToGroupSectionStr;
                ord.SectionTypeId = transfer.SectionTypeId;
                ord.SectionTypeStr = transfer.SectionTypeStr;
                ord.SectionPrice = transfer.SectionPrice;
                
                _context.Orders.Update(ord);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                throw;
            }
            
        }
        public async Task<int> UpdateStatusOrder(long ordercode)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(p => p.OrderCode == ordercode);
            order.DocStatus = "I";
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrderAfterPaid(Order order)
        {
            try
            {
                var ord = await _context.Orders.FirstOrDefaultAsync(p => p.SectionId == order.SectionId && p.OrderStatus == "O");
                ord.DocStatus = order.DocStatus;
                ord.OrderStatus = order.OrderStatus;
                ord.CloseDate=DateTime.Now;
                ord.CloseById = order.CloseById;
                ord.CloseByStr = order.CloseByStr;

                _context.Orders.Update(ord);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<List<Order>> GetNewOrder()
        {
            try
            {
                var order = await _context.Orders.Where(p => p.DocStatus == "O" || p.DocStatus=="I").ToListAsync();
                return order;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
    }
}