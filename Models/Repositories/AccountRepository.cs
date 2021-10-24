using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;
using AsignUser = resm_app.Models.BusinessObjects.Accounts.AsignUser;

namespace resm_app.Models.Repositories
{
    public class AccountRepository : IAccount
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserAccount> Login(LoginViewModel login)
        {
            var users = await _context.UserAccounts.FirstOrDefaultAsync(p =>
                p.Username == login.Username && p.Password == login.Password);
            if (users == null)
                return users;

            var permis = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == users.Permis_Id);
            var role = await _context.UserRoles.FirstOrDefaultAsync(p => p.Id == users.Role_Id);
            var permiss = await _context.PermissionDetails.FirstOrDefaultAsync(p => p.Role_Id == users.Role_Id && p.DocEntry == permis.Id);
            var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == users.Emp_Id && p.Deleted == "N");
            var shift = await _context.Shifts.FirstAsync(p => p.Id == emp.Shift_Id);
            var user = new UserAccount
            {
                Id = users.Id,
                Username = users.Username,
                Email = users.Email,
                UserRole = new UserRole
                {
                    Id = role.Id,
                    Role_En = role.Role_En,
                },
                UserPermission = new UserPermission
                {
                    Id = permis.Id,
                    Permis_En = permis.Permis_En,
                    Level = permis.Level,
                    Create = permis.Create,
                    Update = permis.Update,
                    Delete = permis.Delete,
                    Read = permis.Read,
                    Status = permis.Status
                },
                UserPermissionDetail = new UserPermissionDetail
                {
                    Id = permiss.Id,
                    Perm_En = permis.Permis_En,
                    DocEntry = permiss.DocEntry,
                    Permis_Str = permiss.Permis_Str
                },
                Employee = new Employee
                {
                    Id = emp.Id,
                    Emp_Code = emp.Emp_Code,
                    Emp_Name = emp.Emp_Name,
                    Email = emp.Email,
                    Phone1 = emp.Phone1,
                    Phone2 = emp.Phone2,
                    Dept_Id = emp.Dept_Id,
                    Dept_Str = emp.Dept_Str,
                    Post_Id = emp.Post_Id,
                    Post_Str = emp.Post_Str,
                    Img = emp.Img,
                    Old_Img = emp.Old_Img,
                    No_Num = emp.No_Num,
                    St_Num = emp.St_Num,
                    Sangkat = emp.Sangkat,
                    Khan = emp.Khan,
                    City = emp.City,
                    Province = emp.Province,
                    Shift = new Shift
                    {
                        Id = shift.Id,
                        Shift_Str = shift.Shift_Str,
                        StartHour = shift.StartHour,
                        EndHour = shift.EndHour,
                        Hour = shift.Hour
                    }
                }
            };
            return user;
        }

        public async Task<int> InsertAcc(UserAccount userAccount)
        {
            var acc = await _context.UserAccounts.Where(p => p.Status == "Y").ToListAsync();
            var count = acc.Count();
            if (count >= 5)
                userAccount.Status = "N";

            await _context.UserAccounts.AddAsync(userAccount);
            return await _context.SaveChangesAsync();

            //return (int)userAccount.Id;

        }

        public async Task<int> UpdateAcc(UserAccount userAccount)
        {
            var acc = await _context.UserAccounts.FirstOrDefaultAsync(p => p.Id == userAccount.Id);
            acc.Username = userAccount.Username;
            acc.Password = userAccount.Password;
            acc.New_Password = userAccount.New_Password;
            acc.Old_Password = userAccount.Old_Password;
            acc.UpdateDate = DateTime.Now;
            acc.Email = userAccount.Email;
            acc.UpdateById = userAccount.UpdateById;
            acc.UpdateByName = userAccount.UpdateByName;
            acc.Img = userAccount.Img;
            acc.Old_Img = userAccount.Old_Img;

            _context.UserAccounts.Update(acc);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteAcc(long Id, UserAccount userAccount)
        {
            var acc = await _context.UserAccounts.FirstOrDefaultAsync(p => p.Id == Id);
            acc.Deleted = "Y";
            acc.Status = "N";
            acc.DeleteById = userAccount.DeleteById;
            acc.DeleteByName = userAccount.DeleteByName;
            acc.DeleteDate = DateTime.Now;

            _context.UserAccounts.Update(acc);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<UserRole>> RoleLists()
        {
            var roles = await _context.UserRoles.Where(p => p.Deleted == "N").ToListAsync();
            return roles;
        }

        public async Task<List<UserPermission>> UserPermissions()
        {
            var perms = await _context.Permissions.Where(p => p.Deleted == "N").ToListAsync();
            return perms;
        }

        public async Task<List<UserAccount>> AccLists()
        {
            var accs = await _context.UserAccounts.Where(p => p.Deleted == "N" && p.Status == "Y").ToListAsync();
            var roles = await _context.UserRoles.ToListAsync();
            var acls = (from ac in accs
                        select new UserAccount()
                        {
                            Id = ac.Id,
                            Username = ac.Username,
                            Email = ac.Email,
                            CreateDate = ac.CreateDate,
                            Emp_Id = ac.Emp_Id,
                            Emp_Name = ac.Emp_Name,
                            UserRole = (from r in roles
                                        where r.Id == ac.Role_Id
                                        select new UserRole()
                                        {
                                            Id = r.Id,
                                            Role_En = r.Role_En
                                        }).FirstOrDefault()
                        }).ToList();
            return acls;
        }

        public async Task<List<UserAccount>> UserLists()
        {
            try
            {
                var accs = await _context.UserAccounts.Where(p => p.Deleted == "N" && p.Status == "Y").ToListAsync();
                var acls = (from ac in accs
                            select new UserAccount()
                            {
                                Id = ac.Id,
                                Username = ac.Username,
                                Email = ac.Email,
                                CreateDate = ac.CreateDate,
                                Emp_Id = ac.Emp_Id,
                                Emp_Name = ac.Emp_Name,
                                Employee = _context.Employees.FirstOrDefault(p => p.Id == ac.Emp_Id)
                            }).ToList();
                return acls;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<UserAccount> GetAccById(long Id)
        {
            var acc = await _context.UserAccounts.FirstOrDefaultAsync(p => p.Id == Id && p.Deleted == "N" && p.Status == "Y");
            return acc;
        }

        public async Task<int> AsignAccount(AsignUser asignUser)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id == asignUser.FromId);
            var asign = await _context.UserAccounts.FirstOrDefaultAsync(p => p.Id == asignUser.ToId);

            if (asign != null)
            {
                asign.Emp_Id = asignUser.FromId;
                asign.Emp_Name = asignUser.FromName;
                asign.Email = emp.Email;
                asign.Phone = emp.Phone1;
                asign.Old_Img = asign.Img;
                asign.Img = emp.Img;

                asign.UpdateDate = asignUser.UpdatedDate;
                asign.UpdateById = asignUser.UpdatedById;
                asign.UpdateByName = asignUser.UpdateByStr;

                _context.UserAccounts.Update(asign);
                return await _context.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<int> InsertAsignUser(AsignUser asignUser)
        {
            await _context.AsignUsers.AddAsync(asignUser);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddMenu(MenuPermission menu)
        {
            try
            {
                //int condition = await _context.MenuPermissions.Where(_ => _.Type == "Module").CountAsync();
                if (menu.Id == 0)
                {
                    await _context.MenuPermissions.AddAsync(menu);
                }
                else
                {
                    if (menu.Status == "D")
                    {
                        var m = await _context.MenuPermissions.FirstOrDefaultAsync(_ => _.Id == menu.Id);
                        m.Status = "D";
                        m.Updated_by = menu.Updated_by;
                        m.Update_At = menu.Update_At;
                        _context.MenuPermissions.Update(m);
                    }
                    else
                    {
                        _context.MenuPermissions.Update(menu);
                    }
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }

        public async Task<List<MenuPermission>> GetMenus()
        {
            try
            {
                var res = await _context.MenuPermissions.Where(_ => _.Status != "D").OrderBy(_ => _.OrderBy).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //public async Task<int> MenuUserAutoAdd(int UserId, int MenuId)
        //{
        //    var users = await _context.UserAccounts.ToListAsync();
        //    var menus = await _context.MenuPermissions.ToListAsync();

        //    if (MenuId == 0)
        //    {
        //        foreach (var m in menus)
        //        {
        //            var menu = new SetPermission
        //            {
        //                MenuId = m.Id,
        //                Status = "A",
        //                Created_At = DateTime.Now,
        //                Created_by = 1,
        //                UserId = UserId
        //            };
        //            await _context.SetPermissions.AddAsync(menu);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var u in users)
        //        {
        //            var menu = new SetPermission
        //            {
        //                MenuId = MenuId,
        //                Status = "A",
        //                Created_At = DateTime.Now,
        //                Created_by = 1,
        //                UserId = u.Id
        //            };
        //            await _context.SetPermissions.AddAsync(menu);
        //        }
        //    }
        //    return await _context.SaveChangesAsync();
        //}

        public async Task<List<SetPermission>> GetMenuByUser(long UserId)
        {
            try
            {
                return await _context.SetPermissions.Where(_=>_.UserId == UserId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<int> SavePermission(List<SetPermission> permissions)
        {
            foreach(var perm in permissions)
            {
                var count = await  _context.SetPermissions.CountAsync(_ => _.MenuId == perm.MenuId && _.UserId == perm.UserId);

                if(count == 0)
                {
                    perm.Created_At = DateTime.Now;
                    perm.Created_by = 1;
                    await _context.SetPermissions.AddAsync(perm);
                }
                else
                {
                    var per = await _context.SetPermissions.FirstOrDefaultAsync(_ => _.MenuId == perm.MenuId && _.UserId == perm.UserId);
                    per.Updated_by = 1;
                    per.Update_At = DateTime.Now;
                    per.Status = perm.Status;

                    _context.SetPermissions.Update(per);
                }
                
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MenuPermission>> GetMenuPermissions(long UserId)
        {
            var perm = await _context.SetPermissions.Where(_ => _.UserId == UserId && _.Status == "A").ToListAsync();
            var menus = await _context.MenuPermissions.Where(_ => _.Status == "A").ToListAsync();

            var menuUser = (from m in menus
                            join p in perm on m.Id equals p.MenuId
                            orderby m.OrderBy
                            select new MenuPermission
                            {
                                Id = m.Id,
                                ParentId = m.ParentId,
                                Name = m.Name,
                                Controller = m.Controller,
                                Action = m.Action,
                                Description = m.Description,
                                Icon = m.Icon,
                                OrderBy = m.OrderBy,
                                Type = m.Type,
                            }).ToList();
            return menuUser;
        }
    }
}