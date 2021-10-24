using System.Threading;
using Microsoft.EntityFrameworkCore;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.BusinessPartners;
using resm_app.Models.BusinessObjects.CashInOuts;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Commissions;
using resm_app.Models.BusinessObjects.Companys;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Kdss;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Payments;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Sections;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;

namespace resm_app.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public  virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserRole>UserRoles { get; set; }
        public virtual DbSet<UserPermission> Permissions { get; set; }
        public virtual DbSet<UserPermissionDetail> PermissionDetails { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Exchange> Exchanges { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategoryL1> SubCategoryL1s { get; set; }
        public virtual DbSet<SubCategoryL2> SubCategoryL2s { get; set; }
        
        public virtual DbSet<UoM> UoMs { get; set; }
        public virtual DbSet<GroupUoM>GroupUoMs { get; set; }
        public virtual DbSet<DefineUoM> DefineUoMs { get; set; }
        
        public virtual DbSet<Whs> Whss { get; set; }
        public virtual DbSet<Whs01> Whs01s { get; set; }
        public virtual DbSet<Tax> Taxs { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<PriceList01> PriceList01s { get; set; }
        
        public virtual DbSet<AsignUser> AsignUsers { get; set; }
        public virtual DbSet<Kds> Kdss { get; set; }
        public virtual DbSet<Kds01> Kds01s { get; set; }
        
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<QRCoders> QrCoderses { get; set; }
        
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<GroupSection> GroupSections { get; set; }
        public virtual DbSet<SectionType> SectoinTypes { get; set; }
        
        public virtual DbSet<SectionCheckIn> SectionCheckIns { get; set; }
        public virtual DbSet<BookingSection> BookingSections { get; set; }
        public virtual DbSet<AutoNumber> AutoNumbers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Invoice>Invoices { get; set; } 
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        
        public virtual  DbSet<CommissionExtension> CommissionExtensions { get; set; }
        public virtual  DbSet<Commission> Commissions { get; set; }
        
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Purchase01> Purchase01s{ get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Serial> Serials { get; set; }
        public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }
        public virtual DbSet<GoodsIssue> GoodsIssues { get; set; } 
        public virtual DbSet<GoodsIssue01> GoodsIssue01s { get; set; }
        public virtual DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public virtual DbSet<GoodsReceipt01> GoodsReceipt01s { get; set; }
        public virtual DbSet<CashIn> CashIns { get; set; }
        public virtual DbSet<CashOut> CashOuts { get; set; }

        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<SetPermission> SetPermissions { get; set; }
        

        
    }
}