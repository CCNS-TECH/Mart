using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Models.Repositories
{
    public class ProductRepository:IProduct<Item>,IQRCode<QRCoders>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertItem(Item item)
        { 
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            
            var val = await _context.Items.Select(p => p.Id).MaxAsync();
            return val;
        }

        public async Task<int> UpdateItem(long id, Item item)
        {
            var itm = await _context.Items.FirstOrDefaultAsync(p => p.Id == id);
            itm.ItemEn = item.ItemEn;
            itm.ItemStr = item.ItemStr;
            itm.PrintTo = item.PrintTo;
            itm.SubCateL0Id = item.SubCateL0Id;
            itm.SubCateL0Str = item.SubCateL0Str;
            itm.TaxId = item.TaxId;
            itm.TaxStr = item.TaxStr;
            itm.SaleUoMId = item.SaleUoMId;
            itm.SaleUoMStr = item.SaleUoMStr;
            itm.PchUoMId = item.PchUoMId;
            itm.PchUoMStr = item.PchUoMStr;
            itm.Barcode = item.Barcode;
            itm.InvPch = item.InvPch;
            itm.Inv = item.Inv;
            itm.InvSale = item.InvSale;
            itm.ItemType = item.ItemType;
            itm.PriceListId = item.PriceListId;
            itm.PriceListStr = item.PriceListStr;
            itm.SalePrice = item.SalePrice;
            itm.OldImg = item.Img;
            itm.Img = item.Img;
            itm.UpdatedById = item.UpdatedById;
            itm.UpdatedByName = item.UpdatedByName;
            itm.UpdatedDate=DateTime.Now;

            _context.Items.Update(itm);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteItem(long id,Item item)
        {
            var itm = await _context.Items.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            itm.Deleted = "Y";
            itm.Status = "N";
            itm.DeletedById = item.DeletedById;
            itm.DeletedByName = item.DeletedByName;
            itm.DeletedDate=DateTime.Now;
            _context.Items.Update(itm);
            return await _context.SaveChangesAsync();
        }

        public async Task<Item> GetItem(long id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            return item;
        }

        public async Task<List<Item>> GetItemAll()
        {
            try
            {
                var items = await _context.Items.Where(p => p.Deleted == "N").ToListAsync();
                var itemLists = (from itm in items
                    select new Item
                    {
                        Id = itm.Id,
                        ItemCode = itm.ItemCode,
                        ItemEn = itm.ItemEn,
                        ItemStr= itm.ItemStr ,
                        CateId = itm.CateId,
                        CateStr = itm.CateStr,
                        SubCateL0Id= itm.SubCateL0Id,
                        SubCateL0Str= itm.SubCateL0Str ,
                        SubCateL1Id = itm.SubCateL1Id,
                        SubCateL1Str = itm.SubCateL1Str,
                        InStock = itm.InStock,
                        GUoMId = itm.GUoMId,
                        GUoMStr = itm.GUoMStr,
                        Inv = itm.Inv,
                        InvPch = itm.InvPch,
                        InvSale = itm.InvSale,
                        SaleUoMId = itm.SaleUoMId,
                        SaleUoMStr = itm.SaleUoMStr,
                        InvUoMId = itm.InvUoMId,
                        InvUoMStr = itm.InvUoMStr,
                        PchUoMId = itm.PchUoMId,
                        PchUoMStr = itm.PchUoMStr,
                        TaxStr  = itm.TaxStr,
                        TaxRate  = itm.TaxRate,
                        Cost  = itm.Cost,
                        SalePrice  = itm.SalePrice,
                        QrCodeId  = itm.QrCodeId,
                        QrCodeGuidStr  = itm.QrCodeGuidStr,
                        Barcode  = itm.Barcode,
                        PriceListId  = itm.PriceListId,
                        PriceListStr  = itm.PriceListStr,
                        PrintTo  = itm.PrintTo,
                        ManageBy  = itm.ManageBy,
                        ItemType = itm.ItemType,
                        Img  = itm.Img,
                        OldImg  = itm.Img,
                        Status = itm.Status , 
                        Deleted= itm.Deleted,
                        Category = _context.Categories.FirstOrDefault(p=>p.CateId == itm.CateId),
                        SubCategoryL1 = _context.SubCategoryL1s.FirstOrDefault(p=>p.SubCateL1_Id == itm.SubCateL0Id),
                        PriceList = _context.PriceLists.FirstOrDefault(p=>p.Id == itm.PriceListId)
                    }).ToList();
                return itemLists;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<int> CheckItem(string itemcode)
        {
            var itm = await _context.Items.FirstOrDefaultAsync(p => p.ItemCode == itemcode);
            
            if (itm != null)
                return 0;
            else
                return 1;

        }
        public async Task<int> IssueStockInventory(WhsDetailViewModel whsDetail)
        {
            try
            {
                var item = await _context.Items.FirstOrDefaultAsync(p => p.Id == whsDetail.ItemId);
                
                if (item.Inv == "Y")
                {
                    var whs =await _context.Whss.FirstOrDefaultAsync(w => w.Id == whsDetail.WhsId);
                    whs.InStock -= whsDetail.Quantity;
                    _context.Whss.Update(whs);
                    //await _context.SaveChangesAsync();

                    var prod =await _context.Items.FirstOrDefaultAsync(p => p.Id == whsDetail.ItemId);
                    prod.InStock -= whsDetail.Quantity;
                    _context.Update(prod);
                    //await _context.SaveChangesAsync();

                    var whs1 =await _context.Whs01s.FirstOrDefaultAsync(wh => wh.WhsId == whsDetail.WhsId && wh.Item_Id == whsDetail.ItemId);
                    whs1.InStock -= whsDetail.Quantity;
                    _context.Update(whs1);
                    //await _context.SaveChangesAsync();
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
        public async Task<decimal> IssueBatchItem(long itemId, decimal value)
        {
            try
            {
                decimal currnetQty = 0;
                var batchItems = await _context.Batches.Where(p => p.ItemId == itemId && p.Quantity > 0 && p.EXP >= DateTime.Now.Date).ToListAsync();
                if (batchItems.Count > 0)
                {
                    var batch = batchItems.Min(p => p.EXP);
                    var batchIssue = await _context.Batches.FirstOrDefaultAsync(p => p.EXP == batch);

                    if (value > batchIssue.Quantity)
                    {
                        currnetQty = value - batchIssue.Quantity;
                        batchIssue.Quantity -= batchIssue.Quantity;
                    
                        _context.Batches.Update(batchIssue);
                        await _context.SaveChangesAsync();
                    
                        return currnetQty;
                    }
                    else
                    {
                        batchIssue.Quantity -= value;
                        _context.Batches.Update(batchIssue);
                        await _context.SaveChangesAsync();
                        return currnetQty;
                    }
                }
                return currnetQty;
                
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
            
        }

        public async Task<long> InsertQRCode(QRCoders qrCoders)
        {
            await _context.QrCoderses.AddAsync(qrCoders);
            await _context.SaveChangesAsync();
            var id = await _context.QrCoderses.Select(p => p.Id).MaxAsync();
            return id;
        }

        public async Task<int> UpdateQRCode(long id, QRCoders qrCoders)
        {
            var qrcode = await _context.QrCoderses.FirstOrDefaultAsync(p => p.Id == id);
            qrcode.GuidCode = qrCoders.GuidCode;
            
            _context.QrCoderses.Update(qrcode);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteQRCode(long id)
        {
            var qrcode = await _context.QrCoderses.FirstOrDefaultAsync(p => p.Id == id);
            qrcode.Deleted = "Y";
            _context.QrCoderses.Update(qrcode);
            return await _context.SaveChangesAsync();
        }

        public async Task<QRCoders> GetQRCodeById(long id)
        {
            var qrcode = await _context.QrCoderses.FirstOrDefaultAsync(p => p.Id == id);
            return qrcode;
        }

        public async Task<List<QRCoders>> GetQRCode()
        {
            var qrcodes = await _context.QrCoderses.Where(p => p.Deleted == "N").ToListAsync();
            return qrcodes;
        }
    }
}