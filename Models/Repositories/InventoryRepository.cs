using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace resm_app.Models.Repositories
{
    public class InventoryRepository:IInventory
    {
        private readonly AppDbContext _dbContext;
        public InventoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<long> Save_Purchase(Purchase purchase)
        {            
            await _dbContext.Purchases.AddAsync(purchase);
            await _dbContext.SaveChangesAsync();
            //var pur = _dbContext.Purchases;
            return purchase.DocEntry; // pur.Max(p => p.DocEntry);
        }
      

        public async Task<int> Save_Purchase01(Purchase01 purchase01)
        {
            var duom = _dbContext.DefineUoMs.FirstOrDefault(u => u.GUoM_Id == purchase01.GUoMId && u.UoM_Id == purchase01.UoMId);
            var value = duom.BaseQty / duom.AltQty;

            var whs =await _dbContext.Whss.FirstOrDefaultAsync(w=>w.Id ==purchase01.WhsId);
            whs.InStock += (purchase01.Quantity * value);
            _dbContext.Whss.Update(whs);
            await _dbContext.SaveChangesAsync();

            var item =await _dbContext.Items.FirstOrDefaultAsync(p => p.Id == purchase01.ItemId);
            item.InStock += (purchase01.Quantity * value);
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();

            var whs1 =await _dbContext.Whs01s.FirstOrDefaultAsync(wh => wh.WhsId == whs.Id && wh.Item_Id == purchase01.ItemId);
            whs1.InStock += (purchase01.Quantity * value);
            _dbContext.Update(whs1);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Purchase01s.AddAsync(purchase01);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Purchase> GetPurchaseByCode(long id)
        {
            try
            {
                var purch = await _dbContext.Purchases.FirstOrDefaultAsync(p=>p.DocEntry == id);
                purch.purchase01s = _dbContext.Purchase01s.Where(p => p.DocEntry == id).ToList();
                return purch;

            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }


        public async Task<int> Save_Batch(Batch batch)
        {
            var duom =await _dbContext.DefineUoMs.FirstOrDefaultAsync(u => u.GUoM_Id == batch.GUoMId && u.UoM_Id == batch.UoMId);
            var value = duom.BaseQty / duom.AltQty;
            var qty=batch.Quantity * value;
            batch.Quantity = qty;

            var bat =await _dbContext.Batches.Where(b => b.BatchNum == batch.BatchNum && b.EXP == batch.EXP).CountAsync();
            if (bat == 0)
            {
                await _dbContext.Batches.AddAsync(batch);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                var batc =await _dbContext.Batches.FirstOrDefaultAsync(b => b.BatchNum == batch.BatchNum && b.EXP == batch.EXP);
                batc.Quantity += batch.Quantity;
                _dbContext.Batches.Update(batc);
                return await _dbContext.SaveChangesAsync();
            }
            
        }

        public async Task<int> Save_Serial(Serial serial)
        {
            await _dbContext.Serials.AddAsync(serial);
            return await _dbContext.SaveChangesAsync();
        }

        
        public async Task<Batch> GetBatch(long itemid, string batch)
        {
            var count = _dbContext.Batches.Count(b => b.ItemId == itemid && b.BatchNum == batch);

            if (count > 0)
            {
                var bat = await _dbContext.Batches.FirstAsync(b => b.ItemId == itemid && b.BatchNum == batch);
                return bat;
            }
            return null;          

        }

        public async Task<Serial> GetSerial(long itemid, string serial)
        {
            var count = _dbContext.Serials.Count(s => s.ItemId == itemid && s.SerailNum == serial);
            if (count > 0)
            {
                var ser = await _dbContext.Serials.FirstOrDefaultAsync(s => s.ItemId == itemid && s.SerailNum == serial);
                return ser;
            }
            return null;            
        }

        public async Task<long> Save_Issue(GoodsIssue issue)
        {
            await _dbContext.GoodsIssues.AddAsync(issue);
            await _dbContext.SaveChangesAsync();
            var iss = _dbContext.GoodsIssues;
            return iss.Max(i => i.DocEntry);
        }

        public async Task<int> Save_Issue01(GoodsIssue01 issue01)
        {
            issue01.DocDate = DateTime.Now;
            var duom =await _dbContext.DefineUoMs.FirstOrDefaultAsync(u => u.GUoM_Id == issue01.GUoMId && u.UoM_Id == issue01.UoMId);
            decimal value = duom.BaseQty / duom.AltQty;

            var whs =await _dbContext.Whss.FirstOrDefaultAsync(w => w.Id == issue01.WhsId);
            whs.InStock -= (issue01.Quantity * value);
            _dbContext.Whss.Update(whs);
            await _dbContext.SaveChangesAsync();

            var item =await _dbContext.Items.FirstOrDefaultAsync(p => p.Id == issue01.ItemId);
            item.InStock -= (issue01.Quantity * value);
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();

            var whs1 =await _dbContext.Whs01s.FirstOrDefaultAsync(wh => wh.WhsId == whs.Id && wh.Item_Id == issue01.ItemId);
            whs1.InStock -= (issue01.Quantity * value);
            _dbContext.Update(whs1);
            await _dbContext.SaveChangesAsync();

            await _dbContext.GoodsIssue01s.AddAsync(issue01);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<long> Save_Receipt(GoodsReceipt receipt)
        {
            await _dbContext.GoodsReceipts.AddAsync(receipt);
            await _dbContext.SaveChangesAsync();
            var rec = _dbContext.GoodsReceipts;
            return rec.Max(i => i.DocEntry);
        }

        public async Task<int> Save_Receipt01(GoodsReceipt01 receipt01)
        {
            receipt01.DocDate = DateTime.Now;
            var duom =await _dbContext.DefineUoMs.FirstOrDefaultAsync(u => u.GUoM_Id == receipt01.GUoMId && u.UoM_Id == receipt01.UoMId);
            var value = duom.BaseQty / duom.AltQty;

            var whs =await _dbContext.Whss.FirstOrDefaultAsync(w => w.Id == receipt01.WhsId);
            whs.InStock += (receipt01.Quantity * value);
            _dbContext.Whss.Update(whs);
            await _dbContext.SaveChangesAsync();

            var item =await _dbContext.Items.FirstOrDefaultAsync(p => p.Id == receipt01.ItemId);
            item.InStock += (receipt01.Quantity * value);
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();

            var whs1 =await _dbContext.Whs01s.FirstOrDefaultAsync(wh => wh.WhsId == whs.Id && wh.Item_Id == receipt01.ItemId);
            whs1.InStock += (receipt01.Quantity * value);
            _dbContext.Update(whs1);
            await _dbContext.SaveChangesAsync();

            await _dbContext.GoodsReceipt01s.AddAsync(receipt01);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update_Batch(Batch batch, string type)
        {
            var duom =await _dbContext.DefineUoMs.FirstOrDefaultAsync(u => u.GUoM_Id == batch.GUoMId && u.UoM_Id == batch.UoMId);
            var value = duom.BaseQty / duom.AltQty;
            batch.Quantity = batch.Quantity * value;

            var batc =await _dbContext.Batches.FirstOrDefaultAsync(b => b.BatchNum == batch.BatchNum);

            if (type == "R")
            {
                batc.Quantity += batch.Quantity;     
            }
            else
            {
                batc.Quantity -= batch.Quantity;
            }
            _dbContext.Batches.Update(batc);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update_Serial(Serial serial, string type)
        {
            if (type == "R")
            {
                await _dbContext.Serials.AddAsync(serial);
            }
            else
            {
                var ser = await _dbContext.Serials.FirstOrDefaultAsync(s => s.SerailNum == serial.SerailNum);
                ser.Status = "N";
                _dbContext.Serials.Update(ser);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Item>> GetItems()
        {
            try
            {
                var items = await _dbContext.Items.Where(p=>p.Deleted=="N").ToListAsync();

                List<Item> itemlist = new List<Item>();

                foreach (Item item in items)
                {
                    item.PrintTo = "";
                    var duom = _dbContext.DefineUoMs.Where(u => u.GUoM_Id == item.GUoMId).OrderByDescending(d=>d.BaseQty/d.AltQty);

                    foreach(var uom in duom)
                    {
                        var value = uom.BaseQty / uom.AltQty;
                        if (item.InStock > 0)
                        {
                            var stockconvert = item.InStock / value;
                            var mainStock = (stockconvert.ToString()).Split('.');
                            int stock = Convert.ToInt32(mainStock[0]);

                            var laststock = stockconvert - stock;
                            if(laststock > 0)
                            {
                                item.InStock = laststock * value;
                            }
                            else
                            {
                                item.InStock = 0;
                            }

                            item.PrintTo = item.PrintTo + stock + ' ' + uom.AltUoMName + " | ";
                        }
                        else
                        {
                            item.PrintTo = item.PrintTo + 0 + ' ' + uom.AltUoMName + " | ";
                        }
                    }

                    item.PrintTo = item.PrintTo.Substring(0, item.PrintTo.Length - 3);

                    itemlist.Add(item);
                }

                return itemlist.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
