using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Exchanges;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.UoMs;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class ProductsController : Controller
    {
        private readonly IProduct<Item> _product;
        private readonly IPriceList<PriceList> _priceList;
        private readonly IWhs<Whs> _whs;
        private readonly IWhsDetail<Whs01> _whsDetail;
        private readonly IPriceListDetail<PriceList01> _priceListDetail;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IExchRate<Exchange> _rate;
        private readonly IUoM<UoM> _uom;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProduct<Item> product,
                                  IPriceList<PriceList> priceList,
                                  IWhs<Whs> whs,
                                  IWhsDetail<Whs01> whsDetail,
                                  IPriceListDetail<PriceList01> priceListDetail,
                                  IWebHostEnvironment hostingEnvironment,
                                  IExchRate<Exchange> exchRate,
                                  IUoM<UoM> uom,
                                  ILogger<ProductsController> logger)
        {
            _product = product;
            _priceList = priceList;
            _whs = whs;
            _priceListDetail = priceListDetail;
            _hostingEnvironment = hostingEnvironment;
            _whsDetail = whsDetail;
            _rate = exchRate;
            _uom = uom;
            _logger = logger;
        }
        [HttpGet("/price-list/list")]
        public async Task<IActionResult> AddPriceList()
        {
            ViewBag.PriceList = await _priceList.GetPriceListAll();
            return View();
        }
        [HttpPost("/price-list/list")]
        public async Task<IActionResult> AddPriceList(PriceList priceList)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                priceList.Created_By_Id = usId;
                priceList.Created_By_Name = usName;
                priceList.Created_Date = DateTime.Now;
                priceList.Status = "Y";
                await _priceList.InsertPriceList(priceList);
                return Redirect("/price-list/list");
            }
            return View();
        }
        [HttpGet("/price-list/edit")]
        public async Task<IActionResult> EditPriceList(long id)
        {
            return View(await _priceList.GetPriceList(id));
        }
        [HttpPost("/price-list/edit")]
        public async Task<IActionResult> EditPriceList(long id, PriceList priceList)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                priceList.Updated_By_Id = usId;
                priceList.Updated_By_Name = usName;
                priceList.Updated_Date = DateTime.Now;
                id = priceList.Id;

                await _priceList.UpdatePriceList(id, priceList);
                return Redirect("/price-list/list");
            }
            return View();
        }
        [HttpPost("/price-list/delete/{id}")]
        public async Task<IActionResult> DeletePriceList(long id)
        {
            var psd = new PriceList();
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                psd.Deleted_By_Id = usId;
                psd.Deleted_By_Name = usName;
                psd.Deleted_Date = DateTime.Now;
                psd.Status = "N";

                await _priceList.DeletePriceList(id, psd);
                return Redirect("/price-list/list");
            }
            return Ok();
        }
        [HttpPost("/price-list/set/{id}")]
        public async Task<IActionResult> SetDefault(long id)
        {
            var priceList = new PriceList();
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            priceList.Updated_By_Id = usId;
            priceList.Updated_By_Name = usName;
            priceList.Updated_Date = DateTime.Now;

            await _priceList.SetPriceList(id, priceList);
            return Ok();
        }

        [HttpGet("/item/create")]
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost("/item/create")]
        public async Task<IActionResult> AddItem([FromForm] Item item, IFormFile Img)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            if (ModelState.IsValid)
            {
                string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);

                if (item.Inv == "true")
                    item.Inv = "Y";
                else
                    item.Inv = "N";

                if (item.InvSale == "true")
                    item.InvSale = "Y";
                else
                    item.InvSale = "N";

                if (item.InvPch == "true")
                    item.InvPch = "Y";
                else
                    item.InvPch = "N";

                if (Img != null)
                    item.Img = await SaveFile(Img);
                else
                    item.Img = "default.png";
                if (item.QrCodeId != long.Parse(0.ToString()))
                {
                    var qrcode = new QRCoders();

                    qrcode.GuidCode = "";//GenerateQRCode(fileGuid);

                    qrcode.Date = DateTime.Now;
                    qrcode.Deleted = "N";
                    qrcode.ItemStr = item.ItemEn;

                    item.QrCodeId = 0;//await _qrcode.InsertQRCode(qrcode);
                    item.QrCodeGuidStr = fileGuid;
                }
                item.CreatedById = usId;
                item.CreatedByName = usName;
                item.CreatedDate = DateTime.Now;
                item.Status = "Y";
                item.Deleted = "N";
                item.UpdatedById = 0;
                item.DeletedById = 0;

                var count = await _product.InsertItem(item);
                if (count > 0)
                {
                    await InsertWhs01(item);
                    await InsertPriceList(item);
                }
                return Redirect("/item/create");
            }
            return View();
        }

        async Task<int> InsertWhs01(Item item)
        {
            var eff = 0;
            var whscount = await _whs.GetWhss();
            if (whscount.Count > 0)
            {
                foreach (var wh in whscount)
                {
                    var whsd = new Whs01
                    {
                        WhsId = wh.Id,
                        Item_Id = item.Id,
                        Item_Str = item.ItemStr,
                        InStock = 0,
                        Created_Date = DateTime.Now,
                        Created_By_Id = item.CreatedById,
                        Created_By_Name = item.CreatedByName
                    };
                    eff = await _whsDetail.InsertWhs01(whsd);
                }
            }
            return eff;
        }

        async Task<int> InsertPriceList(Item item)
        {
            var eff = 0;
            var riel = decimal.Parse(HttpContext.Session.GetString("Riel"));
            var countprls = await _priceList.GetPriceListAll();
            var countuoms = await _uom.Get_DefineUoM(item.GUoMId);
            if (countprls.Count > 0)
            {
                foreach (var pls in countprls)
                {
                    if (countuoms.Count > 0)
                    {
                        foreach (var uom in countuoms)
                        {
                            var pricels = new PriceList01
                            {
                                PriceList_Id = pls.Id,
                                Item_Id = item.Id,
                                Item_Str = item.ItemStr,
                                Price_USD = item.SalePrice,
                                Price_Riel = item.SalePrice * riel,
                                UoM_ID = uom.UoM_Id,
                                UoM_Str = uom.AltUoMName,
                                Created_Date = DateTime.Now,
                                Created_By_Id = item.CreatedById,
                                Created_By_Name = item.CreatedByName
                            };
                            eff = await _priceListDetail.InsertPriceList01(pricels);
                        }
                    }
                }
            }
            return eff;
        }
        
        async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/products");
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);


                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch
            {
                Response.StatusCode = 400;
                return null;

            }
        }

        [HttpPost("/ImportExport")]
        public async Task<IActionResult> OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        var item = new Item
                        {
                            ItemCode = row.Cells[1].ToString(),
                            ItemEn = row.Cells[2].ToString(),
                            ItemStr = row.Cells[3].ToString(),
                            CateId = long.Parse(row.Cells[4].ToString()),
                            CateStr = row.Cells[5].ToString(),
                            SubCateL0Id = long.Parse(row.Cells[6].ToString()),
                            SubCateL0Str = row.Cells[7].ToString(),
                            SubCateL1Id = long.Parse(row.Cells[8].ToString()),
                            SubCateL1Str = row.Cells[9].ToString(),
                            InStock = decimal.Parse(row.Cells[10].ToString()),
                            GUoMId = long.Parse(row.Cells[11].ToString()),
                            GUoMStr = row.Cells[12].ToString(),
                            Inv = row.Cells[13].ToString(),
                            InvPch = row.Cells[14].ToString(),
                            InvSale = row.Cells[15].ToString(),
                            SaleUoMId = long.Parse(row.Cells[16].ToString()),
                            SaleUoMStr = row.Cells[17].ToString(),
                            InvUoMId = long.Parse(row.Cells[18].ToString()),
                            InvUoMStr = row.Cells[19].ToString(),
                            PchUoMId = long.Parse(row.Cells[20].ToString()),
                            PchUoMStr = row.Cells[21].ToString(),
                            TaxId = long.Parse(row.Cells[22].ToString()),
                            TaxStr = row.Cells[23].ToString(),
                            TaxRate = Decimal.Parse(row.Cells[24].ToString()),
                            Cost = Decimal.Parse(row.Cells[25].ToString()),
                            SalePrice = Decimal.Parse(row.Cells[26].ToString()),
                            QrCodeId = long.Parse(row.Cells[27].ToString()),
                            QrCodeGuidStr = row.Cells[28].ToString(),
                            Barcode = row.Cells[29].ToString(),
                            PriceListId = long.Parse(row.Cells[30].ToString()),
                            PriceListStr = row.Cells[31].ToString(),
                            PrintTo = row.Cells[32].ToString(),
                            ManageBy = row.Cells[33].ToString(),
                            ItemType = row.Cells[34].ToString(),
                            Img = row.Cells[35].ToString(),
                            Status = row.Cells[36].ToString(),
                            Deleted = row.Cells[37].ToString()

                        };
                        int checkitem = await _product.CheckItem(item.ItemCode);
                        if (checkitem != 0)
                        {
                            if (item.QrCodeId != long.Parse(0.ToString()))
                            {
                                string fileGuid = Guid.NewGuid().ToString().Substring(0, 4);
                                var qrcode = new QRCoders();

                                qrcode.GuidCode = "";// GenerateQRCode(fileGuid);

                                qrcode.Date = DateTime.Now;
                                qrcode.Deleted = "N";
                                qrcode.ItemStr = item.ItemEn;

                                item.QrCodeId = 0; //await _qrcode.InsertQRCode(qrcode);
                                item.QrCodeGuidStr = fileGuid;
                            }
                            if (item.Img != "")
                                item.Img = item.Img;
                            else
                                item.Img = "default.png";

                            item.CreatedById = usId;
                            item.CreatedByName = usName;
                            item.CreatedDate = DateTime.Now;
                            item.Status = "Y";
                            item.Deleted = "N";
                            item.UpdatedById = 0;
                            item.DeletedById = 0;

                            var count = await _product.InsertItem(item);
                            if (count > 0)
                            {
                                await InsertWhs01(item);
                                await InsertPriceList(item);
                            }
                        }
                    }
                }
            }
            return Ok(Response.StatusCode);
        }

        [HttpGet("item/lists")]
        public async Task<IActionResult> ItemList()
        {
            return View(await _product.GetItemAll());
        }

        [HttpGet("item/edit")]
        public async Task<IActionResult> EditItem(long id)
        {
            var item = await _product.GetItem(id);
            item.Inv = item.Inv == "Y" ? "true" : "false";

            item.InvSale = item.InvSale == "Y" ? "true" : "false";

            item.InvPch = item.InvPch == "Y" ? "true" : "false";

            return View(item);
        }
        [HttpPost("item/edit")]
        public async Task<IActionResult> EditItem(long id, Item item, IFormFile Img)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");

            if (ModelState.IsValid)
            {
                if (item.Inv == "true")
                    item.Inv = "Y";
                else
                    item.Inv = "N";

                if (item.InvSale == "true")
                    item.InvSale = "Y";
                else
                    item.InvSale = "N";

                if (item.InvPch == "true")
                    item.InvPch = "Y";
                else
                    item.InvPch = "N";

                id = item.Id;
                if (Img == null)
                    item.Img = item.OldImg;
                else
                    item.Img = await SaveFile(Img);

                item.UpdatedById = usId;
                item.UpdatedByName = usName;
                item.UpdatedDate = DateTime.Now;

                var eff = await _product.UpdateItem(id, item);
                if (eff > 0)
                {
                    var priceLists = await _priceListDetail.GetPriceList01All();
                    var count = priceLists.Where(p => p.Item_Id == id).ToList();
                    var whss = await _whsDetail.GetWhs01s();
                    var whscount = whss.Where(p => p.Item_Id == id).ToList();

                    foreach (var prls in count)
                    {
                        var priceList = new PriceList01()
                        {
                            Updated_By_Id = usId,
                            Updated_By_Name = usName,
                            Updated_Date = DateTime.Now,
                            Item_Id = item.Id,
                            Item_Str = item.ItemStr,

                        };
                        await _priceListDetail.UpdatePriceList01(prls.Id, priceList);
                    }
                    foreach (var wh in whscount)
                    {

                        var whs01 = new Whs01
                        {
                            Deleted_By_Id = usId,
                            Deleted_By_Name = usName,
                            Deleted_Date = DateTime.Now,
                            Item_Id = item.Id,
                            Item_Str = item.ItemStr
                        };

                        await _whsDetail.UpdateWhs01(wh.Id, whs01);
                    }

                    return RedirectToAction("ItemList", "Products");
                }
            }
            return View();
        }

        [HttpPost("item/delete/{id}")]
        public async Task<IActionResult> ItemDelete(long id)
        {
            var usId = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var usName = HttpContext.Session.GetString("OwnnerName");
            var priceList = new PriceList01()
            {
                Updated_By_Id = usId,
                Updated_By_Name = usName,
                Updated_Date = DateTime.Now
            };
            var whs01 = new Whs01
            {
                Deleted_By_Id = usId,
                Deleted_By_Name = usName,
                Deleted_Date = DateTime.Now
            };
            var item = new Item
            {
                DeletedById = usId,
                DeletedByName = usName,
                DeletedDate = DateTime.Now
            };

            var eff = await _product.DeleteItem(id, item);
            if (eff > 0)
            {
                var priceLists = await _priceListDetail.GetPriceList01All();
                var count = priceLists.Where(p => p.Item_Id == id).ToList();
                var whss = await _whsDetail.GetWhs01s();
                var whscount = whss.Where(p => p.Item_Id == id).ToList();

                foreach (var prls in count)
                {
                    await _priceListDetail.DeletePriceListRang(prls.Id, priceList);
                }
                foreach (var wh in whscount)
                {
                    await _whsDetail.DeleteWhs01Rang(wh.Id, whs01);
                }
            }
            return Ok(Response.StatusCode);
        }

        [HttpGet]
        public IActionResult Index(int menu)
        {
            HttpContext.Session.SetString("menu", menu.ToString());
            return View();
        }
    }
}
