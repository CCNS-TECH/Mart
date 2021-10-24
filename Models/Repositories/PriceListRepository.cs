using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class PriceListRepository:IPriceList<PriceList>,IPriceListDetail<PriceList01>
    {
        private readonly AppDbContext _context;
        public PriceListRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertPriceList(PriceList priceList)
        {   
            await _context.PriceLists.AddAsync(priceList);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePriceList(long id, PriceList priceList)
        {
            var prd = await _context.PriceLists.FirstOrDefaultAsync(p => p.Id == id);
            
            prd.PriceList_En = priceList.PriceList_En;
            prd.PriceList_Str = priceList.PriceList_Str;
            prd.Updated_By_Id = priceList.Updated_By_Id;
            prd.Updated_By_Name = priceList.Updated_By_Name;
            prd.Updated_Date=DateTime.Now;

            _context.PriceLists.Update(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePriceList(long id, PriceList priceList)
        {
            var prd = await _context.PriceLists.FirstOrDefaultAsync(p => p.Id == id);
            
            prd.Deleted_By_Id = priceList.Updated_By_Id;
            prd.Deleted_By_Name = priceList.Updated_By_Name;
            prd.Deleted_Date =  DateTime.Now;
            prd.Status = "N";
        
            _context.PriceLists.Update(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SetPriceList(long id, PriceList priceList)
        {
            var splr = await _context.PriceLists.FirstOrDefaultAsync(p => p.Default=="Y" && p.Status=="Y");
            var splr01 = await _context.PriceLists.FirstOrDefaultAsync(p => p.Id == id && p.Status=="Y");
            if (splr != null)
            {
                splr.Updated_By_Id = priceList.Updated_By_Id;
                splr.Updated_By_Name = priceList.Updated_By_Name;
                splr.Updated_Date=DateTime.Now;
                splr.Default = "N";
            
                _context.PriceLists.Update(splr);
            }
            
            splr01.Updated_By_Id = priceList.Updated_By_Id;
            splr01.Updated_By_Name = priceList.Updated_By_Name;
            splr01.Updated_Date=DateTime.Now;
            splr01.Default = "Y";
            _context.PriceLists.Update(splr01);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<PriceList> GetPriceList(long id)
        {
            var prd = await _context.PriceLists.FirstOrDefaultAsync(p => p.Id == id);
            return prd;
        }

        public async Task<List<PriceList>> GetPriceListAll()
        {
            var prd = await _context.PriceLists.Where(p => p.Status == "Y").ToListAsync();
            return prd;
        }

        public async Task<int> InsertPriceList01(PriceList01 priceList01)
        {
            priceList01.Status = "Y";
            await _context.PriceList01s.AddAsync(priceList01); 
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePriceList01(long id, PriceList01 priceList01)
        {
            var prd = await _context.PriceList01s.FirstOrDefaultAsync(p => p.Id == id);
            
            prd.Item_Id = priceList01.Item_Id;
            prd.Item_Str = priceList01.Item_Str;
            prd.Updated_By_Id = priceList01.Updated_By_Id;
            prd.Updated_By_Name = priceList01.Updated_By_Name;
            prd.Updated_Date=DateTime.Now;

            _context.PriceList01s.Update(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePriceList01(long id,PriceList01 priceList01)
        {
            var prd = await _context.PriceList01s.FirstOrDefaultAsync(p => p.Id == id);
            
            prd.Deleted_By_Id = priceList01.Updated_By_Id;
            prd.Deleted_By_Name = priceList01.Updated_By_Name;
            prd.Deleted_Date = DateTime.Now;
            prd.Status = "N";
            _context.PriceList01s.Update(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<PriceList01> GetPriceList01(long id)
        {
            var prd = await _context.PriceList01s.FirstOrDefaultAsync(p => p.Id == id);
            return prd;
        }

        public async Task<List<PriceList01>> GetPriceList01All()
        {
            var prds = await _context.PriceList01s.Where(p => p.Status == "Y").ToListAsync();
            var price = await _context.Exchanges.FirstOrDefaultAsync(p => p.Default == "Y");
            var pricelists = (from i in prds
                    select new PriceList01
                    {
                        Id = i.Id,
                        Item_Id = i.Item_Id,
                        Item_Str = i.Item_Str,
                        UoM_ID = i.UoM_ID,
                        UoM_Str = i.UoM_Str,
                        PriceList_Id = i.PriceList_Id,
                        Price_USD = i.Price_USD,
                        Price_Riel = i.Price_USD * price.Riel,
                        Status = i.Status
                    }
                ).ToList();
            return pricelists;
        }

        public async Task<int> DeletePriceListRang(long id, PriceList01 list01)
        {
            var prd = await _context.PriceList01s.FirstOrDefaultAsync(p => p.Id == id);
            
            prd.Deleted_By_Id = list01.Updated_By_Id;
            prd.Deleted_By_Name = list01.Updated_By_Name;
            prd.Deleted_Date = DateTime.Now;
            prd.Status = "N";

            _context.PriceList01s.Update(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SetPriceListItem(long id, PriceList01 pricelist)
        {
            var prd = await _context.PriceList01s.FirstOrDefaultAsync(p => p.Id == id);
            prd.Price_USD = pricelist.Price_USD;
            prd.Price_Riel = pricelist.Price_Riel;
            _context.PriceList01s.Update(prd);
            return await _context.SaveChangesAsync();
        }
    }
}