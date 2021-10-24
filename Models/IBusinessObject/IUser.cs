using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.Models.IBusinessObject
{
    public interface IUser
    {
        Task<long> InsetUser(Employee employee);
        Task<int> UpdateUser(Employee employee);
        Task<int> DeleteUser(long Id,Employee employee);
        
        Task<Employee> GetEmployee(long Id);
        Task<List<Employee>> GetEmployees();
    }
}
