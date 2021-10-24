using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace resm_app.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CCNS_Batch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNum = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaleQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaleUoMId = table.Column<long>(type: "bigint", nullable: false),
                    SaleUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    EXP = table.Column<DateTime>(type: "datetime", nullable: true),
                    MFG = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(125)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Batch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Booking_Section",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(7)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Pax = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GSectionId = table.Column<long>(type: "bigint", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    TypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    BookedById = table.Column<long>(type: "bigint", nullable: false),
                    BookedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    BookedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Hour = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Minute = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    EndHour = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    EndMinute = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ConfirmStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    ConfirmDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConfirmById = table.Column<long>(type: "bigint", nullable: false),
                    ConfirmByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    CancelById = table.Column<long>(type: "bigint", nullable: false),
                    CancelByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    LineStatus = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Booking_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Company",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Company_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(25)", maxLength: 12, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(25)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Wifi = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    No_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    St_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Sangkat = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Khan = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Old_Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Created_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Invoice01",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    OrderById = table.Column<long>(type: "bigint", nullable: false),
                    OrderByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LineNum = table.Column<int>(type: "int", nullable: false),
                    BaseLine = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    ItemStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ItemTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ItemTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SizeId = table.Column<long>(type: "bigint", nullable: false),
                    SizeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    WhsId = table.Column<long>(type: "bigint", nullable: false),
                    WhsStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    LineStatus = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    LineFree = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Invoice01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Kds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GKdsStr = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Kds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Serail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerailNum = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    ItemId = table.Column<long>(nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaleQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaleUoMId = table.Column<long>(type: "bigint", nullable: false),
                    SaleUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    MFG = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(125)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Serail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_AsignUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToId = table.Column<long>(type: "bigint", nullable: false),
                    ToName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    FromId = table.Column<long>(type: "bigint", nullable: false),
                    FromName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    AsignById = table.Column<long>(type: "bigint", nullable: false),
                    AsignStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdateByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_AsignUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_AutoNumber",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar125 = table.Column<string>(name: "nvarchar(125)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AutoKey = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Started = table.Column<long>(type: "bigint", nullable: false),
                    Next = table.Column<long>(type: "bigint", nullable: false),
                    End = table.Column<long>(type: "bigint", nullable: false),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_AutoNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_BusinessPartner",
                schema: "dbo",
                columns: table => new
                {
                    VendorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<long>(type: "bigint", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateById = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    UpdateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteById = table.Column<long>(type: "bigint", nullable: false),
                    DeleteByName = table.Column<string>(type: "nvarchar(125)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_BusinessPartner", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_CashIn",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashInById = table.Column<long>(type: "bigint", nullable: false),
                    CashInByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ReceivedById = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CashInDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShiftId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashInUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CashInRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PaymentCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_CashIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Category",
                schema: "dbo",
                columns: table => new
                {
                    CateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cate_En = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    Cate_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Category", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_CheckIn_Section",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pax = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    GSectionId = table.Column<long>(type: "bigint", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    TypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CheckedInById = table.Column<long>(type: "bigint", nullable: false),
                    CheckedInByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CheckedInDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedInById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelById = table.Column<long>(type: "bigint", nullable: false),
                    CancelByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransferFromSectionId = table.Column<long>(type: "bigint", nullable: false),
                    TransferFromSectionName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TransferFromSectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TransferFromSectionTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TransferToSectionId = table.Column<long>(type: "bigint", nullable: false),
                    TransferToSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TransferToSectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TransferToSectionTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransferTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransferById = table.Column<long>(type: "bigint", nullable: false),
                    TransferByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    TransferStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_CheckIn_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Commission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    ReceivedById = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentCode = table.Column<long>(type: "bigint", nullable: false),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Prcnt = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CommissionTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CommissionTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    AcceptById = table.Column<long>(type: "bigint", nullable: false),
                    AcceptByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    AcceptDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AcceptStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Commission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Dept",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Dept_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Dept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_DUOM",
                schema: "dbo",
                columns: table => new
                {
                    DUoM_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUoM_Id = table.Column<long>(type: "bigint", nullable: false),
                    UoM_Id = table.Column<long>(type: "bigint", nullable: false),
                    AltUoMName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    AltQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    BaseUoM_Id = table.Column<long>(type: "bigint", nullable: false),
                    BaseUoM_Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BaseQty = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_DUOM", x => x.DUoM_Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Emp",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Emp_Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Join_Date = table.Column<DateTime>(type: "date", nullable: true),
                    DoB = table.Column<DateTime>(type: "date", nullable: true),
                    Card_Num = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Shift_Id = table.Column<long>(type: "bigint", nullable: false),
                    Shift_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Dept_Id = table.Column<long>(type: "bigint", nullable: false),
                    Dept_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Post_Id = table.Column<long>(type: "bigint", nullable: false),
                    Post_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Created_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: true),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    No_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    St_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Sangkat = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    Khan = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Old_Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Emp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Exchange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Dollar = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Riel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Started = table.Column<DateTime>(type: "date", nullable: true),
                    Start_Time = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    End = table.Column<DateTime>(type: "date", nullable: true),
                    End_Time = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Exchange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_GoodsIssue",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_GoodsIssue", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_GoodsIssue01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    LineNum = table.Column<int>(nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ItemStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: true),
                    UoMStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: true),
                    GUoMStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    WhsId = table.Column<long>(type: "bigint", nullable: true),
                    WhsStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VendorId = table.Column<long>(type: "bigint", nullable: true),
                    VendorStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_GoodsIssue01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_GoodsReceipt",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_GoodsReceipt", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_GoodsReceipt01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    LineNum = table.Column<int>(nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ItemStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: true),
                    UoMStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: true),
                    GUoMStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    WhsId = table.Column<long>(type: "bigint", nullable: true),
                    WhsStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VendorId = table.Column<long>(type: "bigint", nullable: true),
                    VendorStr = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_GoodsReceipt01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Group_Section",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSectionEn = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Group_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_GUOM",
                schema: "dbo",
                columns: table => new
                {
                    GUoM_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUoM_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    GUoM_Foreign = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_GUOM", x => x.GUoM_Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Invoice",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvCode = table.Column<long>(type: "bigint", nullable: false),
                    OrderCode = table.Column<long>(type: "bigint", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FreeHour = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalHour = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SectionPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SectionAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GSectionId = table.Column<long>(type: "bigint", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SectionTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ServiceChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ServiceChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ShiftId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    ComissionPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComssionRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionById = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SubTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ReceivedUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ReceivedRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseById = table.Column<long>(type: "bigint", nullable: false),
                    CloseByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    PayStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InvType = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Invoice", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Item",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ItemEn = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    ItemStr = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    CateId = table.Column<long>(type: "bigint", nullable: false),
                    CateStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SubCateL0Id = table.Column<long>(type: "bigint", nullable: false),
                    SubCateL0Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SubCateL1Id = table.Column<long>(type: "bigint", nullable: false),
                    SubCateL1Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    InStock = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Inv = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    InvPch = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    InvSale = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    SaleUoMId = table.Column<long>(type: "bigint", nullable: false),
                    SaleUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    InvUoMId = table.Column<long>(type: "bigint", nullable: false),
                    InvUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    PchUoMId = table.Column<long>(type: "bigint", nullable: false),
                    PchUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TaxId = table.Column<long>(type: "bigint", nullable: false),
                    TaxStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    QrCodeId = table.Column<long>(type: "bigint", nullable: false),
                    QrCodeGuidStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    PriceListId = table.Column<long>(type: "bigint", nullable: false),
                    PriceListStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    PrintTo = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    ManageBy = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    OldImg = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_MenuPermission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    OrderBy = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Created_by = table.Column<long>(type: "bigint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<long>(type: "bigint", nullable: true),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_MenuPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Order",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<long>(type: "bigint", nullable: false),
                    CheckInId = table.Column<long>(type: "bigint", nullable: false),
                    CheckInStr = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GSectoinId = table.Column<long>(type: "bigint", nullable: false),
                    GSectoinStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SectionTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FreeHour = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalHour = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SectionPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SectionAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ServiceChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ServiceChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OrderById = table.Column<long>(type: "bigint", nullable: false),
                    OrderByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ShiftId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelById = table.Column<long>(type: "bigint", nullable: false),
                    CancelByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloseById = table.Column<long>(type: "bigint", nullable: false),
                    CloseByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Order", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Order01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ItemStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ItemTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UpdateById = table.Column<long>(type: "bigint", nullable: false),
                    UpdateByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelById = table.Column<long>(type: "bigint", nullable: false),
                    CancelByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BillStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    LineFree = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Order01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Payment",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCode = table.Column<long>(type: "bigint", nullable: false),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ShiftId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ServiceChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ServiceChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OtherChargeRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ReceivedUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ReceivedRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionPrcn = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ComissionById = table.Column<long>(type: "bigint", nullable: false),
                    ComissionByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceivedById = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    MethodTypeId = table.Column<long>(type: "bigint", nullable: false),
                    MethodTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CancelStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CancelById = table.Column<long>(type: "bigint", nullable: false),
                    CancelByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    PayType = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Received_USD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Received_Riel = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Payment", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Payment01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    InvCode = table.Column<long>(type: "bigint", nullable: false),
                    OrderCode = table.Column<long>(type: "bigint", nullable: false),
                    OrderById = table.Column<long>(type: "bigint", nullable: false),
                    OrderByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    GSectionId = table.Column<long>(type: "bigint", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    SectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SectionTypeStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    FreeHour = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    BaseLine = table.Column<int>(type: "int", nullable: false),
                    RefLine = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ItemStr = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    WhsId = table.Column<long>(type: "bigint", nullable: false),
                    WhsStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalDiscRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalTaxRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    LineFree = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Payment01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_PaymentMethod",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodEn = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    MethodStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Permission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permis_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Create = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Update = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Read = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Permission01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perm_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    Permis_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Role_Id = table.Column<long>(type: "bigint", nullable: false),
                    Role_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Permission01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Position",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Position_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Dept_Id = table.Column<long>(type: "bigint", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_PriceList",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceList_En = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    PriceList_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_PriceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_PriceList01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceList_Id = table.Column<long>(type: "bigint", nullable: false),
                    Item_Id = table.Column<long>(type: "bigint", nullable: false),
                    Item_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    UoM_ID = table.Column<long>(type: "bigint", nullable: false),
                    UoM_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Price_USD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Price_Riel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_PriceList01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Purchase",
                schema: "dbo",
                columns: table => new
                {
                    DocEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PchCode = table.Column<long>(type: "bigint", nullable: false),
                    InvCode = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DiscTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TaxTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SubTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SubTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DepositedUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DepositedRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    VendorStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreateById = table.Column<long>(type: "bigint", nullable: true),
                    CreateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeleteById = table.Column<long>(type: "bigint", nullable: true),
                    DeleteByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdateById = table.Column<long>(type: "bigint", nullable: true),
                    UpdateByName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Purchase", x => x.DocEntry);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Purchase01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocEntry = table.Column<long>(type: "bigint", nullable: false),
                    LineNum = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    ItemStr = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Currentcy = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    DiscPrcnt = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DiscTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    UoMId = table.Column<long>(type: "bigint", nullable: false),
                    UoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GUoMId = table.Column<long>(type: "bigint", nullable: false),
                    GUoMStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    WhsId = table.Column<long>(type: "bigint", nullable: false),
                    WhsStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TotalLine = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    VendorStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "date", nullable: false),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Purchase01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_QRCoders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidCode = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ItemStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_QRCoders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_SectionType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_SectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Shift",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    EndHour = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_SubCategoryL1",
                schema: "dbo",
                columns: table => new
                {
                    SubCateL1_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCateL1_En = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    SubCateL1_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    ColorL1 = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Cate_Id = table.Column<long>(type: "bigint", nullable: false),
                    Cate_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_SubCategoryL1", x => x.SubCateL1_Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_SubCategoryL2",
                schema: "dbo",
                columns: table => new
                {
                    SubCateL2_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCateL2_En = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    SubCateL2_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    ColorL2 = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    SubCateL1_Id = table.Column<long>(type: "bigint", nullable: false),
                    SubCateL1_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_SubCategoryL2", x => x.SubCateL2_Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Tax",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxStr = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Tax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_UoM",
                schema: "dbo",
                columns: table => new
                {
                    UoM_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UoM_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    UoM_Foreign = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_UoM", x => x.UoM_Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<long>(type: "bigint", nullable: false),
                    Emp_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    New_Password = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Old_Password = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Role_Id = table.Column<long>(type: "bigint", nullable: false),
                    Permis_Id = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByName = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateById = table.Column<long>(type: "bigint", nullable: false),
                    UpdateByName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeleteById = table.Column<long>(type: "bigint", nullable: false),
                    DeleteByName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Old_Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Whs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Whs_En = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    Whs_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    InStock = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Whs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Whs01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhsId = table.Column<long>(type: "bigint", nullable: false),
                    Item_Id = table.Column<long>(type: "bigint", nullable: false),
                    Item_Str = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    InStock = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Deleted_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Deleted_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Created_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Updated_By_Id = table.Column<long>(type: "bigint", nullable: false),
                    Updated_By_Name = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Whs01", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CNNS_CommissionExtension",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    CommissionPrcnt = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CommissionValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNNS_CommissionExtension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Branch",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_En = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Branch_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Company_Id = table.Column<long>(type: "bigint", nullable: false),
                    Company_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Whs_Id = table.Column<long>(type: "bigint", nullable: false),
                    Whs_Str = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    No_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    St_Num = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Sangkat = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Khan = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Old_Img = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CompanyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCNS_Branch_CCNS_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CCNS_Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_Kds01",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KdsStr = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    KdsGroupId = table.Column<long>(type: "bigint", nullable: false),
                    KdsGroupStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreateById = table.Column<long>(type: "bigint", nullable: false),
                    CreateStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    IPConfig = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    GetKdsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_Kds01", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCNS_Kds01_CCNS_Kds_GetKdsId",
                        column: x => x.GetKdsId,
                        principalTable: "CCNS_Kds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CCNS_CashOut",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashInId = table.Column<long>(type: "bigint", nullable: false),
                    CashOutById = table.Column<long>(type: "bigint", nullable: false),
                    CashOutByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    ReceivedById = table.Column<long>(type: "bigint", nullable: false),
                    ReceivedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    CashOutDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloseShiftId = table.Column<long>(type: "bigint", nullable: false),
                    CloseShiftStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashOutUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CashOutRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalCashInUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalCashInRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalCashOutUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalCashOutRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalUSD = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GrandTotalRiel = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CloseById = table.Column<long>(type: "bigint", nullable: false),
                    CloseByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PayCodeMin = table.Column<long>(type: "bigint", nullable: false),
                    PayCodeMax = table.Column<long>(type: "bigint", nullable: false),
                    SaleAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaleAmountReil = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_CashOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCNS_CashOut_CCNS_CashIn_CashInId",
                        column: x => x.CashInId,
                        principalSchema: "dbo",
                        principalTable: "CCNS_CashIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CNNS_Section",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionEn = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    SectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    GSectionId = table.Column<long>(type: "bigint", nullable: false),
                    GSectionStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreateByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByStr = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    LineStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    BookingStatus = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CheckInId = table.Column<long>(type: "bigint", nullable: false),
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    GroupSectionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNNS_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CNNS_Section_CCNS_Group_Section_GroupSectionId",
                        column: x => x.GroupSectionId,
                        principalSchema: "dbo",
                        principalTable: "CCNS_Group_Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CCNS_Branch_CompanyId",
                schema: "dbo",
                table: "CCNS_Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CCNS_CashOut_CashInId",
                schema: "dbo",
                table: "CCNS_CashOut",
                column: "CashInId");

            migrationBuilder.CreateIndex(
                name: "IX_CCNS_Kds01_GetKdsId",
                schema: "dbo",
                table: "CCNS_Kds01",
                column: "GetKdsId");

            migrationBuilder.CreateIndex(
                name: "IX_CNNS_Section_GroupSectionId",
                schema: "dbo",
                table: "CNNS_Section",
                column: "GroupSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CCNS_Batch");

            migrationBuilder.DropTable(
                name: "CCNS_Booking_Section");

            migrationBuilder.DropTable(
                name: "CCNS_Invoice01");

            migrationBuilder.DropTable(
                name: "CCNS_Serail");

            migrationBuilder.DropTable(
                name: "CCNS_AsignUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_AutoNumber",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Branch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_BusinessPartner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_CashOut",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_CheckIn_Section",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Commission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Dept",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_DUOM",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Emp",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Exchange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_GoodsIssue",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_GoodsIssue01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_GoodsReceipt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_GoodsReceipt01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_GUOM",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Invoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Item",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Kds01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_MenuPermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Order01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Payment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Payment01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_PaymentMethod",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Permission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Permission01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Position",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_PriceList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_PriceList01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Purchase",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Purchase01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_QRCoders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_SectionType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Shift",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_SubCategoryL1",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_SubCategoryL2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Tax",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_UoM",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Whs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Whs01",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CNNS_CommissionExtension",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CNNS_Section",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Company");

            migrationBuilder.DropTable(
                name: "CCNS_CashIn",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CCNS_Kds");

            migrationBuilder.DropTable(
                name: "CCNS_Group_Section",
                schema: "dbo");
        }
    }
}
