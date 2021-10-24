using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.Models.IBusinessObject
{
    public interface IDept
    {
        Task<List<Dept>> GetDepts();
        Task<List<Position>> GetPositionByDeptId(long deptId);
    }
}