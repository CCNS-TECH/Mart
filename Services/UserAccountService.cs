using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Services
{
    public class UserAccountService
    {
        private readonly IUser _user;
        private readonly IAccount _account;

        public UserAccountService(IUser user,IAccount account)
        {
            _user = user;
            _account = account;
        }
        public async Task<List<Employee>> GetEmps()
        {
            return await _user.GetEmployees();
        }

        public async Task<List<UserAccount>> GetUserAccs()
        {
            return await _account.AccLists();
        }
        public async Task<List<UserRole>> GetUserRoles()
        {
            return await _account.RoleLists();
        }
        public async Task<List<UserPermission>> GetUserPermission()
        {
            return await _account.UserPermissions();
        }

        public async Task<List<MenuPermission>> GetMenuPermissions(long UserId)
        {
            try { 
                return await _account.GetMenuPermissions(UserId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}