using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class TaxReposiotory:ITax<Tax>
    {
        private readonly AppDbContext _context;

        public TaxReposiotory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertTax(Tax tax)
        {
            await _context.Taxs.AddAsync(tax);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTax(long id, Tax tax)
        {
            var tx = await _context.Taxs.FirstOrDefaultAsync(p =>p.Id==id && p.Deleted == "N");
            tx.TaxStr = tax.TaxStr;
            tx.Rate = tax.Rate;
            tx.UpdatedById = tax.UpdatedById;
            tx.UpdatedByStr = tax.UpdatedByStr;
            tx.UpdatedDate=DateTime.Now;
            _context.Update(tx);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTax(long id, Tax tax)
        {
            var tx = await _context.Taxs.FirstOrDefaultAsync(p =>p.Id==id && p.Deleted == "N");
            tx.TaxStr = tax.TaxStr;
            tx.Rate = tax.Rate;
            tx.DeletedById = tax.DeletedById;
            tx.DeletedByStr = tax.DeletedByStr;
            tx.DeletedDate=DateTime.Now;
            tx.Deleted = "Y";
            
            _context.Update(tx);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Tax>> GetTaxs()
        {
            return await _context.Taxs.Where(p => p.Deleted == "N").ToListAsync();
        }

        public async Task<Tax> GetTax(long id)
        {
            return await _context.Taxs.FirstOrDefaultAsync(p =>p.Id==id && p.Deleted == "N");
        }
    }
}