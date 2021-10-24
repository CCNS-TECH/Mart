using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Commissions;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class CommissionRepository:ICommission
    {
        private readonly AppDbContext _context;

        public CommissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertCommission(Commission commission)
        {
            try
            {
                await _context.Commissions.AddAsync(commission);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
        public async Task<int> EditCommission(Commission commission)
        {
            try
            {
                var commiss = await _context.Commissions.FirstOrDefaultAsync(p => p.Id == commission.Id);
                commiss.GrandTotalUSD = commission.GrandTotalUSD;
                commiss.GrandTotalRiel = commission.CommissionTotalRiel;
                commiss.Description = commission.Description;
                _context.Commissions.Update(commiss);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<int> DeletedCommission(long id)
        {
            try
            {
                var commission = await _context.Commissions.FirstOrDefaultAsync(p => p.Id == id);
                
                commission.Deleted = "N";
                _context.Commissions.Update(commission);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<Commission> GetCommissionById(long id)
        {
            try
            {
                var commiss = await _context.Commissions.FirstOrDefaultAsync(p => p.Id == id);
                return commiss;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<List<Commission>> GetCommissions(DateTime from,DateTime to)
        {
            try
            {
                var commission = await _context.Commissions.Where(p => p.Deleted == "N" && p.DocDate >= from && p.DocDate <= to).ToListAsync();
                var commissionList = (from comis in commission
                                    select  new Commission
                                    {
                                        Id = comis.Id,
                                        Description = comis.Description,
                                        PaymentCode = comis.PaymentCode,
                                        DocDate = comis.DocDate,
                                        AcceptStatus = comis.AcceptStatus,
                                        Prcnt = comis.Prcnt,
                                        AcceptDate = comis.AcceptDate,
                                        GrandTotalUSD = comis.GrandTotalUSD,
                                        GrandTotalRiel = comis.GrandTotalRiel,
                                        CommissionTotalUSD = comis.CommissionTotalUSD,
                                        CommissionTotalRiel = comis.CommissionTotalRiel,
                                        Employee = _context.Employees.FirstOrDefault(p=>p.Id==comis.ReceivedById)
                                    }).ToList();
                return commissionList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }

        public async Task<int> ConfirmCommission(Commission commission)
        {
            try
            {
                var coms = await _context.Commissions.FirstOrDefaultAsync(p =>
                    p.PaymentCode == commission.PaymentCode && p.AcceptStatus == "O");
                coms.AcceptById = commission.AcceptById;
                coms.AcceptByStr = commission.AcceptByStr;
                coms.Remark = commission.Remark;
                coms.AcceptStatus = "C";
                coms.AcceptDate = DateTime.Now;
                coms.LineStatus = "C";
                _context.Commissions.Update(coms);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }
    }
}