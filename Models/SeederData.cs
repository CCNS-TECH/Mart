using System;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.BusinessObjects.Taxs;

namespace resm_app.Models
{
    public static class SeederData
    {
        public static void SeedData(AppDbContext contexts)
        {
            contexts.Database.Migrate();
            SeedRole(contexts);
            SeedCompany(contexts);
            SeedPermission(contexts);
            SeedPermissionDetail(contexts);
            SeedDept(contexts);
            SeedPosition(contexts);
            SeedEmp(contexts);
            SeedUser(contexts);
            SeedExchange(contexts);
            SeedShift(contexts);
            SeedCate(contexts);
            TaxAsynce(contexts);
            KdsAsynce(contexts);
            SectionTypeAsynce(contexts);
            SeedAutoNumber(contexts);
        }
        private static void SeedEmp(AppDbContext context)
        {
            if (context.Employees.Any())
                return;
            context.Employees.AddRangeAsync(
                new Employee
                {
                    Emp_Code = "0001",
                    Emp_Name ="CCNS",
                    Gender = "Male",
                    Join_Date = DateTime.Now,
                    DoB = DateTime.Now,
                    Card_Num = "",
                    Email = "ccns@gmail.com",
                    Phone1 = "098738933",
                    Phone2 = "0968737483",
                    Dept_Id = 1,
                    Dept_Str = "IT",
                    Post_Id = 1,
                    Post_Str = "Programmer",
                    Created_Date = DateTime.Now,
                    Created_By_Id = 1,
                    Created_By_Name = "Admin",
                    No_Num = "ST0021",
                    St_Num = "St.235",
                    Sangkat = "Saen Sok",
                    Khan = "Saen Sok",
                    City = "Phnom Penh",
                    Province = "Phnom Penh",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Old_Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Deleted = "N",
                    Status = "Y",
                    Shift_Id= 1,
                    Shift_Str = "None"
                });
            context.SaveChangesAsync().Wait();
        }
        private static void SeedUser(AppDbContext contexts)
        {
            if (contexts.UserAccounts.Any())
                return;
            contexts.UserAccounts.AddRangeAsync(
                new UserAccount
                {
                    Emp_Id = 1,
                    Emp_Name = "Admin01",
                    Username = "Admin",
                    Password = "B509A277F2C72469A920D90D46667763A88200BB",
                    Role_Id = 2,
                    Permis_Id = 1,
                    CreateDate = DateTime.Now.Date,
                    Phone = "098767757",
                    Email = "ccns@gamil.com",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Status = "Y",
                    CreateById=1,
                    CreateByName="Admin",
                    Deleted = "N"
                    

                },
                new UserAccount
                {
                    Emp_Id = 1,
                    Emp_Name = "Admin",
                    Username = "Admin02",
                    Password = "B509A277F2C72469A920D90D46667763A88200BB",
                    Role_Id = 2,
                    Permis_Id = 1,
                    CreateDate = DateTime.Now.Date,
                    Phone = "098767757",
                    Email = "ccns@gamil.com",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Status = "Y",
                    CreateById=1,
                    CreateByName="Admin",
                    Deleted = "N"
                    

                },new UserAccount
                {
                    Emp_Id = 1,
                    Emp_Name = "Admin",
                    Username = "Admin03",
                    Password = "B509A277F2C72469A920D90D46667763A88200BB",
                    Role_Id = 2,
                    Permis_Id = 1,
                    CreateDate = DateTime.Now.Date,
                    Phone = "098767757",
                    Email = "ccns@gamil.com",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Status = "Y",
                    CreateById=1,
                    CreateByName="Admin",
                    Deleted = "N"
                },new UserAccount
                {
                    Emp_Id = 1,
                    Emp_Name = "Admin",
                    Username = "Admin04",
                    Password = "B509A277F2C72469A920D90D46667763A88200BB",
                    Role_Id = 2,
                    Permis_Id = 1,
                    CreateDate = DateTime.Now.Date,
                    Phone = "098767757",
                    Email = "ccns@gamil.com",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Status = "Y",
                    CreateById=1,
                    CreateByName="Admin",
                    Deleted = "N"
                    
                },new UserAccount
                {
                    Emp_Id = 1,
                    Emp_Name = "Admin",
                    Username = "Admin05",
                    Password = "B509A277F2C72469A920D90D46667763A88200BB",
                    Role_Id = 2,
                    Permis_Id = 1,
                    CreateDate = DateTime.Now.Date,
                    Phone = "098767757",
                    Email = "ccns@gamil.com",
                    Img = "ce7ee2d651f743159559c9ce491d74df.png",
                    Status = "Y",
                    CreateById=1,
                    CreateByName="Admin",
                    Deleted = "N"
                });
            contexts.SaveChangesAsync().Wait();
        }
        private static void SeedCompany(AppDbContext contexts)
        {
            if (contexts.Companies.Any())
                return;
            contexts.Companies.AddRangeAsync(
                new Company
                {
                    Company_En = "CCNS",
                    Company_Str = "CCNS",
                    Phone1 = "098888333",
                    Phone2 = "087333999",
                    Wifi = "9998888",
                    No_Num = "268EO",
                    St_Num = "589",
                    Sangkat = "Toul Sangke",
                    Khan = "Russey Keo",
                    City = "Phnom Penh",
                    Province = "Phnom Penh",
                    Email = "ccns@gmail.com.kh",
                    Img = "3900a6ade0204bfb8c34cccca690ed6b.png",
                    Description = "Have a nice day",
                    Old_Img = "",
                    Default = "Y",
                    Deleted = "N"
                }); ;
            contexts.SaveChangesAsync().Wait();
        }

        public static void SeedPermission(AppDbContext context)
        {
            if (context.Permissions.Any())
                return;
            context.Permissions.AddRangeAsync(
                new UserPermission
                    {
                        Permis_En = "Read-Write",
                        Create = "Y",
                        Update = "Y",
                        Delete = "Y",
                        Read = "Y",
                        Level = 4,
                        Deleted = "N",
                        Status = "Y"
                    },
                    new UserPermission
                    {
                        Permis_En = "Read-Write",
                        Create = "Y",
                        Update = "Y",
                        Delete = "N",
                        Read = "Y",
                        Level = 3,
                        Deleted = "N",
                        Status = "Y"
                    },
                    new UserPermission
                    {
                        Permis_En = "Read-Write",
                        Create = "Y",
                        Update = "N",
                        Delete = "N",
                        Read = "Y",
                        Level = 2,
                        Deleted = "N",
                        Status = "Y"
                    },
                    new UserPermission
                    {
                        Permis_En = "Read-Only",
                        Create = "N",
                        Update = "N",
                        Delete = "N",
                        Read = "Y",
                        Level = 1,
                        Deleted = "N",
                        Status = "Y"
                    },
                    new UserPermission
                    {
                        Permis_En = "None",
                        Create = "N",
                        Update = "N",
                        Delete = "N",
                        Read = "Y",
                        Level = 0,
                        Deleted = "N",
                        Status = "Y"
                    }
                );
        }
        private static void SeedPermissionDetail(AppDbContext contexts)
        {
            if (contexts.PermissionDetails.Any())
                return;
            contexts.PermissionDetails.AddRangeAsync(
                new UserPermissionDetail
                {
                    Perm_En = "Programmer",
                    DocEntry =1,
                    Permis_Str = "Read-Write",
                    Role_Id =2,
                    Role_Str="Admin",
                    Status="Y"

                },
                new UserPermissionDetail
                {
                    Perm_En = "Cashier",
                    DocEntry =2,
                    Permis_Str = "Read-Write",
                    Role_Id =4,
                    Role_Str="User",
                    Status="Y"
                },
                new UserPermissionDetail
                {
                    Perm_En = "Order",
                    DocEntry =2,
                    Permis_Str = "Read-Only",
                    Role_Id =4,
                    Role_Str="User",
                    Status="Y"
                });
            contexts.SaveChangesAsync().Wait();
        }

        private static void SeedRole(AppDbContext contexts)
        {
            if (contexts.UserRoles.Any())
                return;

            contexts.UserRoles.AddRangeAsync(
                new UserRole
                {
                    Role_En = "Supper Admin",
                    Status = "Y"
                },
                new UserRole
                {
                    Role_En = "Admin",
                    Status = "Y"
                },
                new UserRole
                {
                    Role_En = "Manager",
                    Status = "Y"
                },
                new UserRole
                {
                    Role_En = "User",
                    Status = "Y"
                },
                new UserRole
                {
                    Role_En = "None",
                    Status = "N"
                });
            contexts.SaveChangesAsync().Wait();
        }

        private static void SeedDept(AppDbContext context)
        {
            if (context.Depts.Any())
                return;
            context.Depts.AddRangeAsync(
                new Dept
                {
                    Dept_En = "None",
                    Dept_Str = "None",
                    Color = Color.Azure.Name,
                    Deleted = "N",
                    Status = "Y"
                },
                new Dept
                {
                    Dept_En = "IT",
                    Dept_Str = "Information Technology",
                    Color = Color.CornflowerBlue.Name,
                    Deleted = "N",
                    Status = "Y"
                },
                new Dept
                {
                    Dept_En = "Finance",
                    Dept_Str = "Finance",
                    Color = Color.Coral.Name,
                    Deleted = "N",
                    Status = "Y"
                },
                new Dept
                {
                    Dept_En = "Account",
                    Dept_Str = "Account",
                    Color = Color.Salmon.Name,
                    Deleted = "N",
                    Status = "Y"
                },
                new Dept
                {
                    Dept_En = "Logistic & Warehouse",
                    Dept_Str = "Logistic & Warehouse",
                    Color = Color.ForestGreen.Name,
                    Deleted = "N",
                    Status = "Y"
                });
        }
        private static void SeedPosition(AppDbContext contexts)
        {
            if (contexts.Positions.Any())
                return;
            contexts.Positions.AddRangeAsync(
                new Position
                {
                    Position_En = "None", 
                    Position_Str = "None",
                    Dept_Id = 1,
                    Deleted ="N",
                    Status="Y"
                },
                new Position
                {
                    Position_En = "Programmer", 
                    Position_Str = "Programmer",
                    Dept_Id = 5,
                    Deleted ="N",
                    Status="Y"
                },
                new Position
                {
                    Position_En = "Cashier", 
                    Position_Str = "Cashier",
                    Dept_Id = 3,
                    Deleted ="N",
                    Status="Y"
                });
            contexts.SaveChangesAsync().Wait();
        }
        private static void SeedExchange(AppDbContext context)
        {
            if (context.Exchanges.Any())
                return;
            context.Exchanges.AddRangeAsync(
                new Exchange
                {
                    Dollar = 1,
                    Riel = 4000,
                    Started = DateTime.Now,
                    Start_Time = "00:00 am",
                    End = DateTime.Now.AddMonths(1),
                    End_Time = "12:59 pm",
                    Default = "Y",
                    Deleted = "N",
                    DocDate = DateTime.Now
                },
                new Exchange
                {
                    Dollar = 1,
                    Riel = 4050,
                    Started = DateTime.Now,
                    Start_Time = "00:00 am",
                    End = DateTime.Now.AddMonths(1),
                    End_Time = "12:59 pm",
                    Default = "N",
                    Deleted = "N",
                    DocDate = DateTime.Now
                },
                new Exchange
                {
                    Dollar = 1,
                    Riel = 4100,
                    Started = DateTime.Now,
                    Start_Time = "00:00 am",
                    End = DateTime.Now.AddMonths(2),
                    End_Time = "12:59 pm",
                    Default = "N",
                    Deleted = "N",
                    DocDate = DateTime.Now
                });
            context.SaveChangesAsync().Wait();
        }

        private static void SeedShift(AppDbContext context)
        {
            if (context.Shifts.Any())
                return;
            context.Shifts.AddRangeAsync(
            
               new Shift
               {
                   Shift_Str = "None",
                   StartHour = "0",
                   EndHour = "0",
                   Hour = 0,
                   Deleted = "N"
               },
               new Shift
               {
                   Shift_Str = "Shift 1",
                   StartHour = "06:00 am",
                   EndHour = "02:00 pm",
                   Hour = 8,
                   Deleted = "N"
               },
               new Shift
               {
                   Shift_Str = "Shift 2",
                   StartHour = "02:00 pm",
                   EndHour = "10:00 pm",
                   Hour = 8,
                   Deleted = "N"
               },
               new Shift
               {
                   Shift_Str = "Shift 3",
                   StartHour = "10:00 pm",
                   EndHour = "06:00 am",
                   Hour = 8,
                   Deleted = "N"
               });
            context.SaveChangesAsync().Wait();
        }

        private static void SeedCate(AppDbContext context)
        {
            if (context.Categories.Any())
                return;
            context.Categories.AddRangeAsync(
                new Category
                {
                    Cate_En = "Food",
                    Cate_Str = "Food",
                    Color = Color.CornflowerBlue.Name,
                    Created_Date = DateTime.Now,
                    Created_By_Id = 1,
                    Created_By_Name = "Admin",
                    Deleted = "N",
                    Status = "Y"

                },
                new Category
                {
                    Cate_En = "Beverage",
                    Cate_Str = "Beverage",
                    Color = Color.DodgerBlue.Name,
                    Created_Date = DateTime.Now,
                    Created_By_Id = 1,
                    Created_By_Name = "Admin",
                    Deleted = "N",
                    Status = "Y"

                },
                new Category
                {
                    Cate_En = "Service",
                    Cate_Str = "Service",
                    Color = Color.IndianRed.Name,
                    Created_Date = DateTime.Now,
                    Created_By_Id = 1,
                    Created_By_Name = "Admin",
                    Deleted = "N",
                    Status = "Y"

                });
            context.SaveChangesAsync().Wait();
        }

        private static void TaxAsynce(AppDbContext context)
        {
            if(context.Taxs.Any())
                return;
            context.Taxs.AddRangeAsync(
                new Tax
                {
                    TaxStr = "0%",
                    Rate = 0,
                    CreateById = 1,
                    CreateStr = "Admin",
                    CreatedDate = DateTime.Now,
                    Deleted = "N",
                    Default = "N"
                },
                new Tax
                {
                    TaxStr = "10%",
                    Rate = 10,
                    CreateById = 1,
                    CreateStr = "Admin",
                    CreatedDate = DateTime.Now,
                    Deleted = "N",
                    Default = "N"
                },
                new Tax
                {
                    TaxStr = "15%",
                    Rate = 15,
                    CreateById = 1,
                    CreateStr = "Admin",
                    CreatedDate = DateTime.Now,
                    Deleted = "N",
                    Default = "N"
                },new Tax
                {
                    TaxStr = "25%",
                    Rate = 25,
                    CreateById = 1,
                    CreateStr = "Admin",
                    CreatedDate = DateTime.Now,
                    Deleted = "N",
                    Default = "N"
                });
             context.SaveChangesAsync().Wait();
        }

        private static void KdsAsynce(AppDbContext context)
        {
            if (context.Kdss.Any())
                return;
            context.Kdss.AddRangeAsync(
            
                new Kds
                {
                    GKdsStr = "None",
                    Deleted = "N",
                    Date = DateTime.Now
                },
                new Kds
                {
                    GKdsStr = "Soup",
                    Deleted = "N",
                    Date = DateTime.Now
                },
                new Kds
                {
                    GKdsStr = "Fried",
                    Deleted = "N",
                    Date = DateTime.Now
                },
                new Kds
                {
                    GKdsStr = "Dessert",
                    Deleted = "N",
                    Date = DateTime.Now
                },
                new Kds
                {
                    GKdsStr = "Bar",
                    Deleted = "N",
                    Date = DateTime.Now
                });
            context.SaveChangesAsync().Wait();
        } 
        private static void SectionTypeAsynce(AppDbContext context)
        {
            if (context.SectoinTypes.Any())
                return;
            context.SectoinTypes.AddRangeAsync(

                new SectionType
                {
                    Type = "None",
                    Status = "Y"
                },
                new SectionType
                {
                    Type = "Normal",
                    Status = "Y"
                },
                new SectionType
                {
                    Type = "VIP",
                    Status = "Y"
                });
            context.SaveChangesAsync().Wait();
        } 
        private static void SeedAutoNumber(AppDbContext contexts)
        {
            if (contexts.AutoNumbers.Any())
                return;
            contexts.AddRangeAsync(
                new AutoNumber
                {
                    AutoKey = "O",
                    Started = 19000000001,
                    Next = 19000000000,
                    End = 19999999999,
                    Prefix = "O-",
                    LineStatus = "N",
                    Title = "Order",
                    Deleted = "N"
                },
                new AutoNumber
                {
                    AutoKey = "R",
                    Started = 19000000001,
                    Next = 19000000000,
                    End = 19999999999,
                    Prefix = "R-",
                    LineStatus = "N",
                    Title = "Receipt",
                    Deleted = "N"
                },new AutoNumber
                {
                    AutoKey = "I",
                    Started = 19000000001,
                    Next = 19000000000,
                    End = 19999999999,
                    Prefix = "B-",
                    LineStatus = "N",
                    Title = "Invoice",
                    Deleted = "N"
                });
            contexts.SaveChangesAsync().Wait();
        }
    }
}