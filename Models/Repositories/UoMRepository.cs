using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class UoMRepository:IUoM<UoM>,IGroupUoM<GroupUoM>,IDefineUoM<DefineUoM>
    {
        private readonly AppDbContext _context;

        public UoMRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> InsertUoM(UoM uom)
        {
            await _context.UoMs.AddAsync(uom);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUoM(long id, UoM uom)
        {
            try
            {
                var uoms = await _context.UoMs.FirstOrDefaultAsync(p => p.UoM_Id == id);
            
                uoms.UoM_Name = uom.UoM_Name;
                uoms.UoM_Foreign = uom.UoM_Foreign;
                uoms.Updated_By_Id = uom.Updated_By_Id;
                uoms.Updated_By_Name = uom.Updated_By_Name;
                uoms.Updated_Date = DateTime.Now;

                _context.UoMs.Update(uoms);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            
        }

        public async Task<int> DeleteUoM(long id, UoM uom)
        {
            try
            {
                var uoms = await _context.UoMs.FirstOrDefaultAsync(p => p.UoM_Id == id);
            
                uoms.Deleted_By_Id = uom.Updated_By_Id;
                uoms.Deleted_By_Name = uom.Updated_By_Name;
                uoms.Deleted_Date = DateTime.Now;
                uoms.Deleted = "Y";

                _context.UoMs.Update(uoms);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            
        }

        public async Task<UoM> GetUoM(long id)
        {
            var uom = await _context.UoMs.FirstOrDefaultAsync(p => p.UoM_Id == id &&  p.Deleted=="N");
            return uom;
        }

        public async Task<List<UoM>> GetUoMAll()
        {
            var uoms = await _context.UoMs.Where(p => p.Deleted=="N").ToListAsync();
            return uoms;
        }

        public async Task<int> Add_DefineUoM(DefineUoM duom)
        {
            if (duom.DUoM_Id != 0)
            {
                var dfuom = await _context.DefineUoMs.FirstOrDefaultAsync(p => p.DUoM_Id == duom.DUoM_Id);
                dfuom.AltQty = duom.AltQty;
                dfuom.AltUoMName = duom.AltUoMName;
                dfuom.BaseQty = duom.BaseQty;
                dfuom.BaseUoM_Id = duom.BaseUoM_Id;
                dfuom.Created_By_Id = duom.Created_By_Id;
                dfuom.Created_By_Name = duom.Created_By_Name;
                dfuom.Created_Date = duom.Created_Date;
                dfuom.UoM = duom.UoM;
                dfuom.UoM_Id = duom.UoM_Id;
                dfuom.Used = duom.Used;

                _context.DefineUoMs.Update(dfuom);
            }
            else
            {
                await _context.DefineUoMs.AddAsync(duom);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DefineUoM>> Get_DefineUoM(long GUoM_Id)
        {
            return (await _context.DefineUoMs.Where(p => p.GUoM_Id == GUoM_Id).ToListAsync());
            
        }
        public async Task<decimal> ConvertQuantityByUoM(long uomId, long gruopId, decimal qty)
        {
            try
            {
                var define = await _context.DefineUoMs.FirstAsync(d => d.UoM_Id == uomId && d.GUoM_Id == gruopId);
                var value = (define.BaseQty / define.AltQty) * qty;
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
        public async Task<int> InsertGroupUoM(GroupUoM groupUoM)
        {
            await _context.GroupUoMs.AddAsync(groupUoM);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateGroupUoM(long id, GroupUoM groupUoM)
        {
            try
            {
                var guom = await _context.GroupUoMs.FirstOrDefaultAsync(p => p.GUoM_Id == id);
            
                guom.GUoM_Name = groupUoM.GUoM_Name;
                guom.GUoM_Foreign = groupUoM.GUoM_Foreign;
                guom.Updated_By_Id = groupUoM.Updated_By_Id;
                guom.Updated_By_Name = groupUoM.Updated_By_Name;
                guom.Updated_Date=DateTime.Now;

                _context.GroupUoMs.Update(guom);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            

        }

        public async Task<int> DeleteGroupUoM(long id, GroupUoM groupUoM)
        {
            try
            {
                var guom = await _context.GroupUoMs.FirstOrDefaultAsync(p => p.GUoM_Id == id);
            
                guom.Deleted_By_Id = groupUoM.Deleted_By_Id;
                guom.Deleted_By_Name = groupUoM.Deleted_By_Name;
                guom.Deleted_Date=DateTime.Now;
                guom.Deleted = "Y";

                _context.GroupUoMs.Update(guom);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            
        }

        public async Task<GroupUoM> GetGroupUoM(long id)
        {
            var guom = await _context.GroupUoMs.FirstOrDefaultAsync(p => p.GUoM_Id == id && p.Deleted=="N");
            return guom;
        }

        public async Task<List<GroupUoM>> GetGroupUoMs()
        {
            var guom = await _context.GroupUoMs.Where(p => p.Deleted=="N").ToListAsync();
            return guom;
        }

        public async Task<int> InsertDefineUoM(DefineUoM defineUoM)
        {
            await _context.DefineUoMs.AddAsync(defineUoM);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateDefineUoM(long id, DefineUoM defineUoM)
        {
            try
            {
                var definesp = await _context.DefineUoMs.FirstOrDefaultAsync(p => p.DUoM_Id == id);
             
                definesp.AltQty = defineUoM.AltQty;
                definesp.BaseQty = defineUoM.BaseQty;
                definesp.Updated_By_Id = defineUoM.Updated_By_Id;
                definesp.Updated_By_Name = defineUoM.Updated_By_Name;
                definesp.Updated_Date = DateTime.Now;

                _context.DefineUoMs.Update(definesp);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            
        }

        public async Task<int> DeleteDefineUoM(long id, DefineUoM defineUoM)
        {
            try
            {
                var definesp = await _context.DefineUoMs.FirstOrDefaultAsync(p => p.DUoM_Id == id);
            
                definesp.Deleted_By_Id = defineUoM.Deleted_By_Id;
                definesp.Deleted_By_Name = defineUoM.Deleted_By_Name;
                definesp.Deleted_Date = DateTime.Now;
                definesp.Deleted = "Y";
            
                _context.DefineUoMs.Update(definesp);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
            
        }

        public async Task<DefineUoM> GetDefineUoM(long id)
        {
            var definesp = await _context.DefineUoMs.FirstOrDefaultAsync(p => p.DUoM_Id == id && p.Deleted=="N");
            return definesp;
        }

        public async Task<List<DefineUoM>> GetDefineUoMs()
        {
            var definesps = await _context.DefineUoMs.Where(p => p.Deleted=="N").ToListAsync();
            return definesps;
        }

        public async Task<int> Delete_DefineUoM(int id, DefineUoM duom)
        {
            var dfuom = await _context.DefineUoMs.FirstOrDefaultAsync(p => p.DUoM_Id == id);
            dfuom.Deleted = "1";
            dfuom.Deleted_By_Id = duom.Deleted_By_Id;
            dfuom.Deleted_By_Name = duom.Deleted_By_Name;
            dfuom.Deleted_Date = duom.Deleted_Date;

            _context.DefineUoMs.Update(dfuom);
            return await _context.SaveChangesAsync();


        }
    }
}