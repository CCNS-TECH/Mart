using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;
using resm_app.Models.Repositories;
using resm_app.Services;

namespace resm_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Provide a secret key to Encrypt and Decrypt the Token
            services.AddAntiforgery(options => options.HeaderName = "MY-XSRF-TOKEN");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
            });
            //Add service Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
                opt.AccessDeniedPath = "/Accounts/LogOut";
                opt.LoginPath = "/Accounts/LogOut";
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAuthorization();
            services.AddDistributedMemoryCache();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddResponseCaching();



            services.AddTransient<IAccount, AccountRepository>();
            services.AddTransient<ICompany<Company>, CompanyRepository>();
            services.AddTransient<IExchRate<Exchange>, ExchangeRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IShift<Shift>, ShiftRepository>();
            services.AddTransient<IDept, DeptRepository>();
            services.AddTransient<ICategory<Category>, CategoryRespository>();
            services.AddTransient<ISubCategory<SubCategoryL1>, CategoryRespository>();
            services.AddTransient<ISubcategoryL2<SubCategoryL2>,CategoryRespository>();
            services.AddTransient<IUoM<UoM>, UoMRepository>();
            services.AddTransient<IGroupUoM<GroupUoM>, UoMRepository>();
            services.AddTransient<IDefineUoM<DefineUoM>, UoMRepository>();
            services.AddTransient<IWhs<Whs>, WhsRepository>();
            services.AddTransient<IWhsDetail<Whs01>, WhsRepository>();
            services.AddTransient<IProduct<Item>, ProductRepository>();
            services.AddTransient<IPriceList<PriceList>, PriceListRepository>();
            services.AddTransient<IPriceListDetail<PriceList01>, PriceListRepository>();
            services.AddTransient<ITax<Tax>, TaxReposiotory>();
            services.AddTransient<Ikds<Kds>, KdsRepository>();
            services.AddTransient<IQRCode<QRCoders>, ProductRepository>();
            services.AddTransient<ISection<Section>, SectionRepository>();
            services.AddTransient<IGroupSection<GroupSection>, SectionRepository>();
            services.AddTransient<IBookingSection<BookingSection>, CheckInRepository>();
            services.AddTransient<ICheckInSection<SectionCheckIn>, CheckInRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IInvoice, InvoiceRepository>();
            services.AddTransient<IPayment, PaymentRepository>();
            services.AddTransient<ICommission, CommissionRepository>();
            services.AddTransient<IInventory, InventoryRepository>();
            services.AddTransient<ISeller, ReportRepository>();
            services.AddTransient<IBusinessPartner, BusinessPartnerRepository>();
            services.AddTransient<ICashInOut, CashInOutRepository>();
            //service injection
            services.TryAddTransient<CategoryService>();
            services.TryAddTransient<UoMService>();
            services.TryAddTransient<UserAccountService>();
            services.TryAddTransient<PriceListService>();
            services.TryAddTransient<TaxService>();
            services.TryAddTransient<KdsService>();
            services.TryAddTransient<SectionService>();
            services.TryAddTransient<ItemService>();
            services.TryAddTransient<EmployeeSerivce>();
            services.TryAddTransient<DashboardService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext contexts)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                     //pattern: "{controller=Account}/{action=Login}/{id?}");
                     pattern: "{controller=Account}/{action=Login}/{id?}");
            });
            SeederData.SeedData(contexts);
        }
    }
}
