using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;

namespace resm_app.Models.Repositories
{
    public class UserRepository:IUser
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsetUser(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
             await _context.SaveChangesAsync();

            var us = await _context.Employees.Select(p => p.Id).MaxAsync();
            return us;
        }

        public async Task<int> UpdateUser(Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == employee.Id);
            emp.Emp_Code = employee.Emp_Code;
            emp.Emp_Name = employee.Emp_Name;
            emp.Shift_Id = employee.Shift_Id;
            emp.Shift_Str = employee.Shift_Str;
            emp.Dept_Id = employee.Dept_Id;
            emp.Dept_Str = employee.Dept_Str;
            emp.Post_Id = employee.Post_Id;
            emp.Post_Str = employee.Post_Str;
            emp.No_Num = employee.No_Num;
            emp.St_Num = employee.St_Num;
            emp.Sangkat = employee.Sangkat;
            emp.Khan = employee.Khan;
            emp.Province = employee.Province;
            emp.Img = employee.Img;
            emp.Updated_Date=DateTime.Now;
            emp.Updated_By_Id = employee.Updated_By_Id;
            emp.Updated_By_Name = employee.Updated_By_Name;
            emp.Phone1 = employee.Phone1;
            emp.Phone2 = employee.Phone2;
            emp.Old_Img = employee.Old_Img;

            _context.Employees.Update(emp);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteUser(long Id,Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == Id);
            emp.Deleted = "Y";
            emp.Status = "N";
            emp.Deleted_By_Id = employee.Deleted_By_Id;
            emp.Deleted_By_Name = employee.Deleted_By_Name;
            emp.Deleted_Date=DateTime.Now;

            _context.Employees.Update(emp);
            return await _context.SaveChangesAsync();

        }

        public async Task<Employee> GetEmployee(long Id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == Id && p.Deleted=="N" && p.Status=="Y");
            emp.Old_Img = emp.Img;
            
            return emp;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var emps = await _context.Employees.Where(p =>p.Deleted=="N" && p.Status=="Y").ToListAsync();
            return emps;
        }
    }
}