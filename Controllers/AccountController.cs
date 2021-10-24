using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using resm_app.Infrastructures.Encrypts;
using resm_app.Infrastructures.Token;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        private readonly IAccount _account;
        private readonly ICompany<Company> _company;
        private readonly IExchRate<Exchange> _exchange;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccount account, ICompany<Company> company, IExchRate<Exchange> exchange, ILogger<AccountController> logger)
        {
            _account = account;
            _company = company;
            _exchange = exchange;
            _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            try
            {
                var company = await _company.GetCompanyDefault();
                ViewBag.logo = company.Img;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
          
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            bool isUservalid = false;
            login.Password = PassHashing.EncryptPass(login.Password);
            
            if (ModelState.IsValid)
            {
                TokenProvider _tokenProvider = new TokenProvider();
                
                var usr = await _account.Login(login);
                
                //Authenticate user
                var userToken =  _tokenProvider.LoginUser(usr);
                if (userToken != null)
                {
                    //Save token in session object
                    HttpContext.Session.SetString("KJeWTYoken", userToken);
                }
                
                if (usr != null)
                    isUservalid = true;
                
                if(isUservalid)
                {
                    await UserProfile(usr);
                    var claims = new List<Claim> {new Claim(ClaimTypes.Name, usr.Username)};
                    var roles = usr.UserRole.Role_En.Split(",");
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    return RedirectToAction("Dashboard", "Home");
                }
                ViewBag.Info = "error";
                ModelState.AddModelError("", "Username and Password is incorrect!");
            }
            return View();
        }
       
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login),"Account");
        }

        [HttpGet("/account/list")]
        public async Task<IActionResult> CreateUserAccount()
        {
            ViewBag.AccList = await _account.AccLists();
            return View();
        }
        [HttpPost("/account/list")]
        public async Task<IActionResult> CreateUserAccount(UserAccount account)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            
            ModelState.Remove("Email");
            ModelState.Remove("Phone");
            ModelState.Remove("CreateDate");
            ModelState.Remove("CreateById");
            ModelState.Remove("CreateByName");

            account.Password = PassHashing.EncryptPass(account.Password);
            account.CreateDate = DateTime.Now;
            account.CreateById = usId;
            account.CreateByName = usName;
            account.Email = "none@gmail.com";
            account.Phone = "00 0000 0000";
            account.Deleted = "N";
            account.Status = "Y";

            if (ModelState.IsValid)
            {
                 await _account.InsertAcc(account);
                //await _account.MenuUserAutoAdd(userId, 0);

                return Redirect("/account/list");
            }
            ViewBag.AccList = await _account.AccLists();
            return View();
        }
        [HttpPost("/user/account/change-usr")]
        public async Task<IActionResult> ASignUser(AsignUser asignUser)
        {
            var usId=int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName=HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                var str = asignUser.AsignStr.Split("-");
                asignUser.FromId =int.Parse(str[0]);
                asignUser.FromName = str[1];
                asignUser.UpdatedDate = DateTime.Now;
                asignUser.UpdatedById = usId;
                asignUser.UpdateByStr = usName;
                
                var eff = await _account.AsignAccount(asignUser);

                if (eff > 0)
                {

                    asignUser.CreatedDate = asignUser.UpdatedDate;
                    asignUser.AsignById = asignUser.UpdatedById;
                    asignUser.AsignStr = asignUser.UpdateByStr;
                    asignUser.DocDate = DateTime.Now;

                    await _account.InsertAsignUser(asignUser);
                    return Ok();
                }
                else
                    return Ok(BadRequest("404"));
            }
            return View(nameof(CreateUserAccount));
        }

        async Task<bool> UserProfile(UserAccount account)
        {
            var company = await _company.GetCompanyDefault();
            var exchange = await _exchange.GetDefaultExchagne();
            if (account.Email == null)
                account.Email = "None";
            
            if (account.Employee.Img == "")
                account.Employee.Img = "user-200.png";

            HttpContext.Session.SetString("UserId", account.Id.ToString());
            HttpContext.Session.SetString("OwnnerId", account.Employee.Emp_Code);
            HttpContext.Session.SetString("OwnnerName", account.Username);
            HttpContext.Session.SetString("ShiftId", account.Employee.Shift.Id.ToString());
            HttpContext.Session.SetString("ShiftStr", account.Employee.Shift.Shift_Str);
            HttpContext.Session.SetString("Email", account.Email);
            HttpContext.Session.SetString("Phone",account.Employee.Phone1);
            HttpContext.Session.SetString("Mobile",account.Employee.Phone2);
            HttpContext.Session.SetString("Img", account.Employee.Img);
            HttpContext.Session.SetString("Logo",company.Img);
            HttpContext.Session.SetString("CompanyPhone1", company.Phone1);
            HttpContext.Session.SetString("CompanyPhone2", company.Phone2);
            HttpContext.Session.SetString("CompanyName", company.Company_En);
            HttpContext.Session.SetString("Wifi", company.Wifi);
            HttpContext.Session.SetString("CompanyEmail", company.Email);
            HttpContext.Session.SetString("No_Num", company.No_Num);
            HttpContext.Session.SetString("St_Num", company.St_Num);
            HttpContext.Session.SetString("Sangkat", company.Sangkat);
            HttpContext.Session.SetString("Khan", company.Khan);
            HttpContext.Session.SetString("City", company.City);
            HttpContext.Session.SetString("Province", company.Province);
            HttpContext.Session.SetString("Description", company.Description);
            HttpContext.Session.SetString("Role",account.UserRole.Role_En);
            HttpContext.Session.SetString("Riel", exchange.Riel.ToString());

            return true;
        }
        [HttpGet]
        public async Task<IActionResult> LockScreen()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MenuPermission()
        {
            try
            {
                ViewBag.Menu = await _account.GetMenus();
                //ViewBag.Module = menus.Where(_ => _.Type == "Module" && _.Status =="A").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MenuPermission(MenuPermission menu)
        {
            try
            {
                menu.Status = menu.Status switch
                {
                    "true" => "A",
                    "D" => "D",
                    _ => "C",
                };
                if (menu.Id == 0)
                {
                    menu.Created_At = DateTime.Now;
                    menu.Created_by = long.Parse(HttpContext.Session.GetString("OwnnerId"));
                    //return await _account.AddMenu(menu);
                    //await _account.MenuUserAutoAdd(0, menuId);
                }
                else
                {
                    menu.Update_At = DateTime.Now;
                    menu.Updated_by = long.Parse(HttpContext.Session.GetString("OwnnerId"));
                    //await _account.AddMenu(menu);
                }
                await _account.AddMenu(menu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.Menu = await _account.GetMenus();
            //ViewBag.Module = menus.Where(_ => _.Type == "Module" && _.Status == "A").ToList();
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> get_parent_menu(string type)
        {
            try
            {
                var menus = await _account.GetMenus();
                var main = menus.Where(_ => _.Type == type && _.Status == "A").ToList();

                return Json(main);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        [HttpGet]
        public async Task<MenuPermission> GetMenubyId(long Id)
        {
            try
            {
                var menus = await _account.GetMenus();
                return menus.FirstOrDefault(_ => _.Id == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> SetPermission()
        {
            ViewBag.AccList = await _account.AccLists();
            ViewBag.Menu = await _account.GetMenus();

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetMenuWithUser(long UserId)
        {
            try
            {
                var menu = await _account.GetMenuByUser(UserId);
                
                return Json(menu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> SavePermission(List<SetPermission> permission)
        {
            try
            {
                await _account.SavePermission(permission);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok();
            }

        }

    }
}