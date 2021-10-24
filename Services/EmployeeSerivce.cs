using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class EmployeeSerivce
    {
        private readonly IUser _user;
        private readonly IAccount _account;
        private readonly IShift<Shift> _shift;

        public EmployeeSerivce(IUser user,IAccount account,IShift<Shift> shift)
        {
            _user = user;
            _account = account;
            _shift = shift;
        }
        public async Task<List<Employee>> EmployeesList()
        {
            return await _user.GetEmployees();
        }
        public async Task<List<UserAccount>> GetUserAccount()
        {
            return await _account.UserLists();
        }
        public async Task<List<Shift>> GetShifts()
        {
            return await _shift.GetShifts();
        }
    }
}