using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class ShiftRepository:IShift<Shift>
    {
        private readonly AppDbContext _context;

        public ShiftRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> InsertShift(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateShift(long id,Shift shift)
        {
            var shf = await _context.Shifts.FirstOrDefaultAsync(p => p.Id == id);
            shf.Shift_Str = shift.Shift_Str;
            shf.StartHour = shift.StartHour;
            shf.EndHour = shift.EndHour;
            shf.Hour = shift.Hour;

            _context.Shifts.Update(shf);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteShift(long id)
        {
            var shf = await _context.Shifts.FirstOrDefaultAsync(p => p.Id == id);
            shf.Deleted = "Y";
            
            _context.Shifts.Update(shf);
            return await _context.SaveChangesAsync();
        }

        public async Task<Shift> GetShift(long id)
        {
            var shf = await _context.Shifts.FirstOrDefaultAsync(p => p.Id == id && p.Deleted=="N");
            return shf;
        }

        public async Task<List<Shift>> GetShifts()
        {
            var shf = await _context.Shifts.Where(p => p.Deleted == "N").ToListAsync();
            return shf;
        }
    }
}