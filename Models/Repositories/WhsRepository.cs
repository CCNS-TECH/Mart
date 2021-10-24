using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Models.Repositories
{
    public class WhsRepository:IWhs<Whs>,IWhsDetail<Whs01>
    {
        private readonly AppDbContext _context;

        public WhsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertWhs(Whs whs)
        {
           await _context.Whss.AddAsync(whs);
           return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateWhs(long id, Whs whs)
        {
            var wh = await _context.Whss.FirstOrDefaultAsync(p => p.Id == id);
            wh.Whs_En = whs.Whs_En;
            wh.Whs_Str = whs.Whs_Str;
            wh.Address = whs.Address;
            wh.Remark = whs.Remark;
            wh.Updated_By_Id = whs.Updated_By_Id;
            wh.Updated_By_Name = whs.Updated_By_Name;
            wh.Updated_Date=DateTime.Now;

            _context.Whss.Update(wh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteWhs(long id, Whs whs)
        {
            var wh = await _context.Whss.FirstOrDefaultAsync(p => p.Id == id);
            wh.Deleted = "Y";
            wh.Deleted_By_Id = whs.Deleted_By_Id;
            wh.Deleted_By_Name = whs.Deleted_By_Name;
            wh.Deleted_Date = DateTime.Now;
            
            _context.Whss.Update(wh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertWhs01(Whs01 whs01)
        {
            await _context.Whs01s.AddAsync(whs01);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteWhs01(long id, Whs01 whs)
        {
            var whss = await _context.Whs01s.FirstOrDefaultAsync(p => p.Id == id);
            whss.InStock = whs.InStock;
            whss.Deleted_By_Id = whs.Updated_By_Id;
            whss.Deleted_By_Name = whs.Updated_By_Name;
            whss.Deleted_Date=DateTime.Now;
            whss.Status = "N";

            _context.Whs01s.Update(whss);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteWhs01Rang(long id, Whs01 whs)
        {
            var whss = await _context.Whs01s.FirstOrDefaultAsync(p => p.Id == id);
            whss.InStock = whs.InStock;
            whss.Deleted_By_Id = whs.Updated_By_Id;
            whss.Deleted_By_Name = whs.Updated_By_Name;
            whss.Deleted_Date=DateTime.Now;
            whss.Status = "N";
            
            _context.Whs01s.Update(whss);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateWhs01(long id, Whs01 whs)
        {
            var whss = await _context.Whs01s.FirstOrDefaultAsync(p => p.Id == id);
            whss.Item_Id = whs.Item_Id;
            whss.Item_Str = whs.Item_Str;
            whss.Updated_By_Id = whs.Updated_By_Id;
            whss.Updated_By_Name = whs.Updated_By_Name;
            whss.Updated_Date=DateTime.Now;

            _context.Whs01s.Update(whss);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SetWhs(long id, Whs whs)
        {
            var whs0 = await _context.Whss.FirstOrDefaultAsync(p => p.Default=="Y" && p.Deleted=="N");
            var whs01 = await _context.Whss.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            if (whs0 != null)
            {
                whs0.Updated_By_Id = whs.Updated_By_Id;
                whs0.Updated_By_Name = whs.Updated_By_Name;
                whs0.Updated_Date=DateTime.Now;
                whs0.Default = "N";
            
                _context.Whss.Update(whs0);
            }
            whs01.Updated_By_Id = whs.Updated_By_Id;
            whs01.Updated_By_Name = whs.Updated_By_Name;
            whs01.Updated_Date=DateTime.Now;
            whs01.Default = "Y";
            _context.Whss.Update(whs01);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<Whs01> GetWhs01ById(long id)
        {
            var whs=await _context.Whs01s.FirstOrDefaultAsync(p=>p.Id==id);
            return whs;
        }

        public async Task<List<Whs01>> GetWhs01s()
        {
            var whs= await _context.Whs01s.Where(p=>p.Status=="Y").ToListAsync();
            return whs;
        }

        public async Task<Whs01> GetWhs01ByWhsId(long whsId,long itemId)
        {
            try
            {
                var whs01 = await _context.Whs01s.FirstOrDefaultAsync(p => p.WhsId == whsId && p.Item_Id==itemId);
                return whs01;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        /*public async Task<int> UpdateStockByItemId(WhsDetailViewModel whsmodel)
        {
            try
            { 
                var whs = await _context.Whs01s.FirstOrDefaultAsync(p =>
                    p.WhsId == whsmodel.WhsId && p.Item_Id == whsmodel.ItemId);

                whs.InStock -= whsmodel.Quantity;

                _context.Whs01s.Update(whs);
                return await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
           
        }*/

        public async Task<Whs> GetWhsById(long id)
        {
            var whs = await _context.Whss.FirstOrDefaultAsync(p=>p.Id==id);
            return whs;
        }

        public async Task<Whs> GetWhsDefault()
        {
            var whs = await _context.Whss.FirstOrDefaultAsync(p=>p.Default=="Y");
            return whs;
        }

        public async Task<List<Whs>> GetWhss()
        {
            var whss = await _context.Whss.Where(p=>p.Deleted=="N").ToListAsync();
            return whss;
        }

        public async Task<Whs> GetWhsByDefault()
        {
            try
            {
                var whs = await _context.Whss.FirstOrDefaultAsync(p => p.Default == "Y");
                return whs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}