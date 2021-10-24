using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class ExchangeRepository:IExchRate<Exchange>
    {
        private readonly AppDbContext _context;

        public ExchangeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> SetExchRate(long id,Exchange exchange)
        {
            var ex0 = await _context.Exchanges.FirstOrDefaultAsync(p => p.Default=="Y" && p.Deleted=="N");
            var ex01 = await _context.Exchanges.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            if (ex0 != null)
            {
                ex0.Updated_By_Id = exchange.Updated_By_Id;
                ex0.Updated_By_Name = exchange.Updated_By_Name;
                ex0.Updated_Date=DateTime.Now;
                ex0.Default = "N";
            
                _context.Exchanges.Update(ex0);
            }
            ex01.Updated_By_Id = ex01.Updated_By_Id;
            ex01.Updated_By_Name = ex01.Updated_By_Name;
            ex01.Updated_Date=DateTime.Now;
            ex01.Default = "Y";
            _context.Exchanges.Update(ex01);
            return await _context.SaveChangesAsync();
        }

        public async Task<Exchange> GetDefaultExchagne()
        {
            var ex = await _context.Exchanges.FirstOrDefaultAsync(p => p.Default == "Y");
            return ex;
        }

        public async Task<int> InsertExchRate(Exchange ex)
        {
            await _context.Exchanges.AddAsync(ex);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateExchRate(long id, Exchange ex)
        {
            var exc = await _context.Exchanges.FirstOrDefaultAsync(p=>p.Id==id && p.Deleted=="N");

            exc.ExStr = ex.ExStr;
            exc.Dollar = ex.Dollar;
            exc.Riel = ex.Riel;
            exc.Started = ex.Started;
            exc.Start_Time = ex.Start_Time;
            exc.End = ex.End;
            exc.End_Time = ex.End_Time;
            exc.Updated_By_Id = ex.Updated_By_Id;
            exc.Updated_By_Name = ex.Updated_By_Name;
            exc.Updated_Date=DateTime.Now;
            _context.Exchanges.Update(exc);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExch(long id, Exchange ex)
        {
            var exc = await _context.Exchanges.FirstOrDefaultAsync(p=>p.Id==id && p.Deleted=="N");

            exc.Deleted = "Y";
            exc.Deleted_By_Id = ex.Updated_By_Id;
            exc.Deleted_By_Name = ex.Updated_By_Name;
            exc.Deleted_Date = DateTime.Now;
            
            _context.Exchanges.Update(exc);
            return await _context.SaveChangesAsync();
        }

        public async Task<Exchange> GetExchRate(long id)
        {
            var exc = await _context.Exchanges.FirstOrDefaultAsync(p=>p.Id==id && p.Deleted=="N");
            return exc;
        }

        public async Task<List<Exchange>> GetExchRates()
        {
            var excs = await _context.Exchanges.Where(p=>p.Deleted=="N").ToListAsync();
            return excs;
        }
    }
}