using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class DeptRepository:IDept
    {
        private readonly AppDbContext _context;
        public DeptRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Dept>> GetDepts()
        {
            var depts = await _context.Depts.Where(p => p.Deleted == "N").ToListAsync();
            return depts;
        }

        public async Task<List<Position>> GetPositionByDeptId(long deptId)
        {
            var poss = await _context.Positions.Where(p => p.Dept_Id == deptId).ToListAsync();
            return poss;
        }
    }
}