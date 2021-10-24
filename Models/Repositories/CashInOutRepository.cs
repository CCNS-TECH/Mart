using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.CashInOuts;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class CashInOutRepository:ICashInOut
    {
        private readonly AppDbContext _context;

        public CashInOutRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertCashInAsync(CashIn cashIn)
        {
            try
            {
                await _context.CashIns.AddAsync(cashIn); 
                await _context.SaveChangesAsync();
                return cashIn.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public async Task<int> UpdateCashInAsync(CashIn cashIn)
        {
            try
            {
                var cashin = await _context.CashIns.FirstAsync(_ => _.Id == cashIn.Id);
                var cashIns = await _context.CashIns.Where(p => p.CashInById == cashin.CashInById).ToListAsync();
                foreach(var cash in cashIns)
                {
                    cash.DocStatus = "C";
                    _context.Update(cash);
                }
                
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<CashIn> GetCashInAsync(long id)
        {
            try
            {
                var cashin = await _context.CashIns.FirstOrDefaultAsync(p => p.Id == id);
                return cashin;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<IEnumerable<CashIn>> GetCashInListAsync()
        {
            try
            {
                var cashins = await _context.CashIns.Where(p => p.Delete == "N" && p.DocStatus == "O").ToListAsync();
                return cashins;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }
        }

        public async Task<int> InsertCashOutAsync(CashOut cashOut)
        {
            try
            {
                var Cash = await _context.CashOuts.FirstOrDefaultAsync(_ => _.CashOutById == cashOut.CashOutById &&
                                                                          _.Delete == "N" &&
                                                                          _.DocStatus == "O");
                if(Cash != null)
                {
                    var cashin = await _context.CashIns.Where(_ => _.CashInById == cashOut.CashOutById &&
                                                              _.Delete == "N" &&
                                                              _.DocStatus == "O").ToListAsync();


                    Cash.TotalCashInUSD = cashin.Sum(_ => _.TotalUSD);
                    Cash.TotalCashInRiel = cashin.Sum(_=>_.TotalRiel);

                    _context.CashOuts.Update(Cash);
                }
                else
                {
                    await _context.CashOuts.AddAsync(cashOut);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<int> UpdateCashOutAsync(CashOut cashOut)
        {
            try
            {
                var cashout = await _context.CashOuts.FirstOrDefaultAsync(p => p.CashInId == cashOut.CashInId);
                cashout.CloseById = cashOut.CashOutById;
                cashout.CloseByStr = cashOut.CashOutByStr;
                cashout.ReceivedById = cashOut.ReceivedById;
                cashout.ReceivedByStr = cashOut.ReceivedByStr;
                cashout.GrandTotalUSD = cashOut.GrandTotalUSD;
                cashout.GrandTotalRiel = cashOut.GrandTotalRiel;
                cashout.DocDate = cashOut.DocDate;
                cashout.TotalCashOutUSD = cashOut.TotalCashOutUSD;
                cashout.TotalCashOutRiel = cashOut.TotalCashOutRiel;
                cashout.CashOutUSD = cashOut.CashOutUSD;
                cashout.CashOutRiel = cashOut.CashOutRiel;
                cashout.SaleAmount = cashOut.SaleAmount;
                cashout.SaleAmountReil = cashOut.SaleAmountReil;
                cashout.PayCodeMax = cashOut.PayCodeMax;
                cashout.PayCodeMin = cashOut.PayCodeMin;
                cashout.CloseDate=DateTime.Now;
                cashout.DocDate = cashOut.DocDate;
                cashout.CashOutById = cashOut.CashOutById;
                cashout.CashOutByStr = cashOut.CashOutByStr;
                cashout.DocStatus = "C";
                cashout.CashOutDate = cashOut.CashOutDate;

                _context.CashOuts.Update(cashout);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CashOut> GetCashOutAsync(long id)
        {
            try
            {
                var cashout = await _context.CashOuts.FirstOrDefaultAsync(p => p.Id == id);
                return cashout;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<IEnumerable<CashOut>> GetCashOutListAsync()
        {
            try
            {
                return await _context.CashOuts.Where(p => p.Delete == "N" && p.DocStatus == "O").ToListAsync();
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<List<CashIn>> GetCashInAsync()
        {
            try
            {
                var cashIn = await _context.CashIns.Where(p => p.DocStatus == "O" && p.Delete=="N").ToListAsync();
                return cashIn;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }
        }
        
        public async Task<List<AutoNumber>> GetAutoNumbers()
        {
            var auto = await _context.AutoNumbers.Where(a => a.Deleted == "N").ToListAsync();
            return auto;
        }

        public async Task<List<CashOut>> GetCashOuts()
        {
            var i = 0;
            try
            {
                var cashout = await _context.CashOuts.Where(p => p.Delete == "N").ToListAsync();

                foreach(var x in cashout){
                    var cashin = await _context.CashIns.FirstOrDefaultAsync(a => a.Id == x.CashInId);
                    cashout[i].CashIn = cashin;
                    i++;
                }

                return cashout;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
    }
}