using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.BusinessObjects.Whs;


namespace resm_app.SyncData
{
    public static class DataPopulation
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
             var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext dbContext)
        {
            System.Console.WriteLine("Applying Migrations....");
            dbContext.Database.Migrate();
            if (!dbContext.UserRoles.Any())
            {
                System.Console.WriteLine("Adding user role data - seeding...");
                dbContext.UserRoles.AddRange(
                    new UserRole
                    {
                        Role_En = "SuperAdmin",
                        Deleted = "N",
                        Status  = "Y"
                        
                    },
                    new UserRole
                    {
                        Role_En = "Admin",
                        Deleted = "N",
                        Status  = "Y"
                    }, new UserRole
                    {
                        Role_En = "Manager",
                        Deleted = "N",
                        Status  = "Y"
                    }, new UserRole
                    {
                        Role_En = "User",
                        Deleted = "N",
                        Status  = "Y"
                    });
                dbContext.SaveChanges();
            }
            if (!dbContext.Whss.Any())
            {
                System.Console.WriteLine("Adding warehouse data - seeding...");

                dbContext.Whss.AddRange(
                    new Whs
                    {
                        Address = "Phnom Penh",
                        Default = "Y",
                        InStock = 0,
                        Remark  = "Head office"

                    }) ;
                dbContext.SaveChanges();
            }
            if (!dbContext.Taxs.Any())
            {
                System.Console.WriteLine("Adding Tax data - seeding...");

                dbContext.Taxs.AddRange(
                    new Tax
                    {
                        Default = "Y",
                        Rate    = 0,
                        TaxStr  = "0%"

                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.AutoNumbers.Any())
            {
                System.Console.WriteLine("Adding Auto Number data- seeding...");
                dbContext.AutoNumbers.AddRange(
                    new AutoNumber
                    {
                        AutoKey = "O",
                        Deleted = "N",
                        LineStatus = "Y",
                        Prefix  = "O-",
                        Title   = "Order",
                        Started = 20000000001,
                        Next    = 20000000001,
                        End     = 99999999999
                    },
                    new AutoNumber
                    {
                        AutoKey = "R",
                        Deleted = "N",
                        LineStatus = "Y",
                        Prefix  = "R-",
                        Title   = "Receipt",
                        Started = 20000000001,
                        Next    = 20000000001,
                        End     = 99999999999
                    },
                    new AutoNumber
                    {
                        AutoKey = "I",
                        Deleted = "N",
                        LineStatus = "Y",
                        Prefix  = "B-",
                        Title   = "Invoice",
                        Started = 20000000001,
                        Next    = 20000000001,
                        End     = 99999999999
                    });
                dbContext.SaveChanges();
            }
            if (!dbContext.Exchanges.Any())
            {
                System.Console.WriteLine("Adding Exchange Rate data - seeding...");
                dbContext.Exchanges.AddRange(
                    new Exchange
                    {
                        Default = "Y",
                        ExStr = "Dollar",
                        Dollar = 1,
                        Riel = 4000,
                        Deleted = "N",
                        Started = Convert.ToDateTime("2020-06-28"),
                        Start_Time = "12:00 am",
                        End = Convert.ToDateTime("2120-06-28"),
                        End_Time = "12:00 am"
                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.Shifts.Any())
            {
                System.Console.WriteLine("Adding Shift data- seeding");
                dbContext.Shifts.AddRange(
                    new Shift
                    {
                        Deleted = "N",
                        EndHour = "0",
                        Hour = 0,
                        StartHour = "0",
                        Shift_Str = "None"
                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.Positions.Any())
            {
                System.Console.WriteLine("Adding Position data - seeding...");
                dbContext.Positions.AddRange(
                    new Position
                    {
                        Deleted = "N",
                        Dept_Id = 1,
                        Position_En = "None",
                        Position_Str = "None",
                        Status = "Y"
                    });
                dbContext.SaveChanges();
            }
            if (!dbContext.Depts.Any())
            {
                System.Console.WriteLine("Adding Department data - seeding...");
                dbContext.Depts.AddRange(
                    new Dept {
                        Deleted = "N",
                        Dept_En = "None",
                        Dept_Str = "None",
                        Status = "Y"
                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.Employees.Any())
            {
                System.Console.WriteLine("Adding Employee data - seeding...");
                dbContext.Employees.AddRange(
                    new Employee
                    {
                        Card_Num = "00022039540283",
                        City = "Phnom Penh",
                        Deleted = "N",
                        Dept_Id = 1,
                        Dept_Str = "None",
                        DoB = Convert.ToDateTime("1996-01-01"),
                        Email = "ccns@gmail.com",
                        Emp_Code = "0001",
                        Emp_Name = "Admin",
                        Gender = "M",
                        Join_Date = Convert.ToDateTime("2020-06-28"),
                        Khan = "Dung Penh",
                        No_Num = "ST0001",
                        Phone1 = "010 101 010",
                        Phone2 = "096 222 3435",
                        Post_Id = 1,
                        Post_Str = "None",
                        Province = "Phnom Penh",
                        Sangkat = "Mean Jay",
                        Shift_Id = 1,
                        Shift_Str = "None",
                        Status = "Y",
                        St_Num = "271"

                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.Branches.Any())
            {
                System.Console.WriteLine("Adding Branch data - seeding...");
                dbContext.Branches.AddRange(
                    new Branch
                    {
                        Branch_En = "Head office",
                        Branch_Str = "Head office",
                        City = "Phnom Penh",
                        Company_Id = 1,
                        Company_Str = "CCNS",
                        Default = "Y",
                        Deleted = "N",
                        Khan = "Dung Penh",
                        No_Num = "ST0001",
                        Province = "Phnom Penh",
                        Sangkat = "Mean Jay",
                        Status = "Y",
                        St_Num = "271",
                        Whs_Id = 1,
                        Whs_Str = "None"

                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.Companies.Any())
            {
                System.Console.WriteLine("Adding Company data - seeding...");
                dbContext.Companies.AddRange(
                    new Company
                    {
                        City = "Phnom Penh",
                        Company_En = "CCNS",
                        Company_Str = "CCNS",
                        Default = "Y",
                        Deleted = "N",
                        Description = "Phnom Penh",
                        Email = "ccns@gmail.com",
                        Khan = "Dung Penh",
                        No_Num = "ST0001",
                        Phone1 = "010 101 010",
                        Phone2 = "096 222 3435",
                        Province = "Phnom Penh",
                        Sangkat = "Mean Jay",
                        Status = "Y",
                        St_Num = "271",
                        Wifi = "12345678"

                    });
                dbContext.SaveChanges();
            }
            if(!dbContext.Permissions.Any())
            {
                System.Console.WriteLine("Adding Permission data - seeding...");
                dbContext.Permissions.AddRange(
                    new UserPermission
                    {
                        Create = "Y",
                        Delete = "Y",
                        Update = "Y",
                        Read = "Y",
                        Level = 0,
                        Permis_En = "Read-Write",
                        Status = "Y",
                        Deleted = "N"
                    });
                dbContext.SaveChanges();
            }
            if (!dbContext.PermissionDetails.Any())
            {
                System.Console.WriteLine("Adding Permission Detail data - seeding...");
                dbContext.PermissionDetails.AddRange(
                    new UserPermissionDetail
                    {
                        Deleted = "N",
                        DocEntry = 1,
                        Level = 0,
                        Permis_Str = "Super Admin",
                        Perm_En = "Super Admin",
                        Role_Id = 1,
                        Role_Str = "SuperAdmin",
                        Status = "Y"
                    });
                dbContext.SaveChanges();
            }
            if (!dbContext.UserAccounts.Any())
            {
                System.Console.WriteLine("Adding User Account data - seeding...");
                dbContext.UserAccounts.AddRange(
                    new UserAccount
                    {
                        ConfirmPass = "B509A277F2C72469A920D90D46667763A88200BB",
                        Deleted = "N",
                        Email = "ccns@gmail.com",
                        Emp_Id = 1,
                        Emp_Name = "Admin",
                        New_Password = "B509A277F2C72469A920D90D46667763A88200BB",
                        Password = "B509A277F2C72469A920D90D46667763A88200BB",
                        Permis_Id = 1,
                        Phone = "010 101 010",
                        Role_Id = 1,
                        Status = "Y",
                        Username = "Admin"
                    });
                dbContext.SaveChanges();
            }

            else
            {
                System.Console.WriteLine("Already have data - not deeding");
            }
        }
    }
}