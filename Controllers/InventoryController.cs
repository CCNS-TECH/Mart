using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.Inventory;
using resm_app.Models.BusinessObjects.Products;
using resm_app.Models.BusinessObjects.Whs;
using resm_app.Models.IBusinessObject;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace resm_app.Controllers
{
    [Authorize]
    [CheckAuthorization]
    public class InventoryController : Controller
    {
        private readonly IProduct<Item> _product;
        private readonly IWhs<Whs> _whs;
        private readonly IInventory _inventory;
        private readonly IBusinessPartner _partner;
        private readonly ISeller _seller;
        public InventoryController(IProduct<Item> product,IWhs<Whs> whs,
                                    IInventory inventory,IBusinessPartner partner,
                                    ISeller seller)
        {
            _product = product;
            _whs = whs;
            _inventory = inventory;
            _partner = partner;
            _seller = seller;
        }

        // GET: /<controller>/
        [HttpGet("inventory/purchase")]
        public async Task<IActionResult> Purchase()
        {
            
            var bpns=await _partner.GetBusinessPartners();
            ViewBag.Whs = await _whs.GetWhss();
            ViewBag.Venders = bpns.Where(p => p.Type == "V");
            var items = await _product.GetItemAll();
            return View(items.Where(p=>p.Inv=="Y").ToList());
        }

        [HttpPost("inventory/purchase/post")]
        public async Task<IActionResult> SavePurchase(Purchase purchase,List<Batch> Batchs, List<Serial> Serials)
        {
            decimal ExchangeRate =decimal.Parse(HttpContext.Session.GetString("Riel"));
            long userid =long.Parse(HttpContext.Session.GetString("OwnnerId"));
            string username = HttpContext.Session.GetString("OwnnerName");

            var warehouse = await _whs.GetWhss();
            Whs whs = warehouse.FirstOrDefault(w => w.Default == "Y");
            Purchase pur = new Purchase
            {
                CreateById = userid,
                CreateByName = username,
                CreateDate = DateTime.Now,
                DepositedRiel = 0,
                DepositedUSD =0,
                DiscPrcnt =purchase.DiscPrcnt,
                DiscTotal = (purchase.SubTotalUSD* purchase.DiscPrcnt)/100,
                DocStatus = "Y",
                InvCode = purchase.InvCode,
                PchCode =purchase.PchCode,
                TaxPrcnt = purchase.TaxPrcnt,
                TaxTotal =  (purchase.TaxPrcnt*(purchase.SubTotalUSD- (purchase.SubTotalUSD * purchase.DiscPrcnt) / 100))/100,
                GrandTotalRiel = purchase.GrandTotalUSD * ExchangeRate,
                GrandTotalUSD = purchase.GrandTotalUSD,
                SubTotalUSD = purchase.SubTotalUSD,
                SubTotalRiel = purchase.SubTotalUSD*ExchangeRate,
                PurchaseDate = purchase.PurchaseDate,
                VendorId = purchase.VendorId,
                VendorStr = purchase.VendorStr
            };
            long Id_pur = await _inventory.Save_Purchase(pur);
            int line = 0;
            foreach (var p in purchase.purchase01s)
            {
                line++;
                var pur01 = new Purchase01
                {
                    Cost = p.Cost,
                    Currentcy = p.Currentcy,
                    DiscPrcnt = p.DiscPrcnt,
                    DiscTotal = (p.TotalLine * p.DiscPrcnt) / 100,
                    DocDate = DateTime.Now,
                    DocEntry = Id_pur,
                    GUoMId = p.GUoMId,
                    GUoMStr = p.GUoMStr,
                    ItemCode = p.ItemCode,
                    ItemId = p.ItemId,
                    ItemStr = p.ItemStr,
                    LineNum = line,
                    LineStatus = "Y",
                    Quantity = p.Quantity,
                    TotalLine = p.TotalLine,
                    UnitPrice = 0,
                    UoMId = p.UoMId,
                    UoMStr = p.UoMStr,
                    VendorId = p.VendorId,
                    VendorStr = p.VendorStr,
                    WhsId = whs.Id,
                    WhsStr = whs.Whs_En,
                    Deleted = "N"
                };
                int doc = await _inventory.Save_Purchase01(pur01);
            }
            foreach(var batch in Batchs) {
                if (batch.BatchNum != null)
                {
                    Batch bat = new Batch
                    {
                        BatchNum = batch.BatchNum,
                        CreatedById = userid,
                        CreatedByName = username,
                        CreatedDate = DateTime.Now,
                        ItemId = batch.ItemId,
                        ItemName = batch.ItemName,
                        EXP = batch.EXP,
                        Quantity = batch.Quantity,
                        Status = "Y",
                        UoMId = batch.UoMId,
                        GUoMId = batch.GUoMId
                    };
                    await _inventory.Save_Batch(bat);
                }
            }
            foreach (var serial in Serials)
            {
                if (serial.SerailNum != null)
                {
                    Serial ser = new Serial
                    {
                        SerailNum = serial.SerailNum,
                        CreatedById = userid,
                        CreatedByName = username,
                        CreatedDate = DateTime.Now,
                        ItemId = serial.ItemId,
                        ItemName = serial.ItemName,
                        MFG = serial.MFG,
                        Quantity = serial.Quantity,
                        Status = "Y"
                    };
                    await _inventory.Save_Serial(ser);

                }
            }

            return Ok();
        }
        public async Task<IActionResult> GoodsReceipt()
        {
            ViewBag.Whs = await _whs.GetWhss();
            var bpns=await _partner.GetBusinessPartners();
            ViewBag.Venders = bpns.Where(p => p.Type == "V");
            
            var listitem = await _product.GetItemAll();
            var item = listitem.Where(p => p.Inv == "Y" && p.InStock > 0).ToList();

            return View(item);
        }
        public async Task<IActionResult> GoodsIssue()
        {
            ViewBag.Whs = await _whs.GetWhss();
            var bpns = await _partner.GetBusinessPartners();
            ViewBag.Venders = bpns.Where(p => p.Type == "V");
            var listitem = await _product.GetItemAll();
            var item = listitem.Where(p => p.Inv == "Y" && p.InStock > 0).ToList();

            return View(item);
        }

        [HttpGet("/inventory/checkBatch")]
        public async Task<IActionResult> Check_Batch(long itemid,string batch)
        {
            var bat = await _inventory.GetBatch(itemid, batch);

            return Ok(bat);
        }
        [HttpGet("/inventory/checkSerial")]
        public async Task<IActionResult> Check_Serial(long itemid,string serial)
        {
            var ser = await _inventory.GetSerial(itemid, serial);

            return Ok(ser);
        }

        [HttpPost("/inventory/save_issue")]
        public async Task<IActionResult> SaveIssue(GoodsIssue goodsIssue, List<Batch> Batchs, List<Serial> Serials)
        {
            decimal ExchangeRate = decimal.Parse(HttpContext.Session.GetString("Riel"));
            long userid = long.Parse(HttpContext.Session.GetString("OwnnerId"));
            string username = HttpContext.Session.GetString("OwnnerName");

            var warehouse = await _whs.GetWhss();
            Whs whs = warehouse.FirstOrDefault(w => w.Default == "Y");
            GoodsIssue issue = new GoodsIssue
            {
                CreateById = userid,
                CreateByName = username,
                CreateDate = DateTime.Now,
                Amount = goodsIssue.Amount,
                Description = goodsIssue.Description               
            };
            long Id_issue = await _inventory.Save_Issue(issue);
            int line = 0;
            foreach (var p in goodsIssue.GoodsIssue01s)
            {
                line++;
                var issue01 = new GoodsIssue01
                {
                    Cost = p.Cost,
                    DocDate = p.DocDate,
                    DocEntry = Id_issue,
                    GUoMId = p.GUoMId,
                    GUoMStr = p.GUoMStr,
                    ItemCode = p.ItemCode,
                    ItemId = p.ItemId,
                    ItemStr = p.ItemStr,
                    LineNum = line,
                    Quantity = p.Quantity,
                    TotalLine = p.TotalLine,
                    UoMId = p.UoMId,
                    UoMStr = p.UoMStr,
                    VendorId = p.VendorId,
                    VendorStr = p.VendorStr,
                    WhsId = whs.Id,
                    WhsStr = whs.Whs_En,
                };
                int doc = await _inventory.Save_Issue01(issue01);
            }
            await Update_Batch_Serial(Batchs, Serials,"I");

            return Ok();
        }


        [HttpPost("/inventory/save_receipt")]
        public async Task<IActionResult> SaveReceipt(GoodsReceipt goodsreceipt, List<Batch> Batchs, List<Serial> Serials)
        {
            decimal ExchangeRate = decimal.Parse(HttpContext.Session.GetString("Riel"));
            long userid = long.Parse(HttpContext.Session.GetString("OwnnerId"));
            string username = HttpContext.Session.GetString("OwnnerName");

            var warehouse = await _whs.GetWhss();
            Whs whs = warehouse.FirstOrDefault(w => w.Default == "Y");
            GoodsReceipt receipt = new GoodsReceipt
            {
                CreateById = userid,
                CreateByName = username,
                CreateDate = DateTime.Now,
                Amount = goodsreceipt.Amount,
                Description = goodsreceipt.Description
            };
            long Id_issue = await _inventory.Save_Receipt(receipt);
            int line = 0;
            foreach (var p in goodsreceipt.GoodsReceipt01s)
            {
                line++;
                var receipt01 = new GoodsReceipt01
                {
                    Cost = p.Cost,
                    DocDate = p.DocDate,
                    DocEntry = Id_issue,
                    GUoMId = p.GUoMId,
                    GUoMStr = p.GUoMStr,
                    ItemCode = p.ItemCode,
                    ItemId = p.ItemId,
                    ItemStr = p.ItemStr,
                    LineNum = line,
                    Quantity = p.Quantity,
                    TotalLine = p.TotalLine,
                    UoMId = p.UoMId,
                    UoMStr = p.UoMStr,
                    VendorId = p.VendorId,
                    VendorStr = p.VendorStr,
                    WhsId = whs.Id,
                    WhsStr = whs.Whs_En,
                };
                int doc = await _inventory.Save_Receipt01(receipt01);
            }
            await Update_Batch_Serial(Batchs, Serials, "R");

            return Ok();
        }

        private async Task<int> Update_Batch_Serial(List<Batch> Batchs, List<Serial> Serials, string Type)
        {
            long userid = long.Parse(HttpContext.Session.GetString("OwnnerId"));
            string username = HttpContext.Session.GetString("OwnnerName");
            foreach (var batch in Batchs)
            {
                if (batch.BatchNum != null)
                {
                    Batch bat = new Batch
                    {
                        BatchNum = batch.BatchNum,
                        CreatedById = userid,
                        CreatedByName = username,
                        CreatedDate = DateTime.Now,
                        ItemId = batch.ItemId,
                        ItemName = batch.ItemName,
                        EXP = batch.EXP,
                        Quantity = batch.Quantity,
                        Status = "Y",
                        UoMId = batch.UoMId,
                        GUoMId = batch.GUoMId
                    };
                    await _inventory.Update_Batch(bat,Type);
                }
            }
            foreach (var serial in Serials)
            {
                if (serial.SerailNum != null)
                {
                    Serial ser = new Serial
                    {
                        SerailNum = serial.SerailNum,
                        CreatedById = userid,
                        CreatedByName = username,
                        CreatedDate = DateTime.Now,
                        ItemId = serial.ItemId,
                        ItemName = serial.ItemName,
                        MFG = serial.MFG,
                        Quantity = serial.Quantity,
                        Status = "Y"
                    };
                    await _inventory.Update_Serial(ser,Type);

                }
            }
            return 0;
        }

        public IActionResult PurchaseList() => View();
        [HttpGet("/purchase/list")]
        public async Task<IActionResult> GetPurchaseList(string from, string to)
        {
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                var prchs = await _seller.PurchaseLists(DateTime.Now.Date,DateTime.Now.Date.AddDays(1));
                var json = new
                {
                    draw = 1,
                    recordsTotal= prchs.Count,
                    recordsFiltered= prchs.Count,
                    data = prchs
                };
                return new JsonResult(json);
            }
            else
            {
                var dfrm = from.Split("/");
                var dto = to.Split("/");

                var datefrm = dfrm[2] + "-"+ dfrm[0] + "-" + dfrm[1];
                var dateto = dto[2]+ "-"+ dto[0] + "-" + dto[1];
                var prchs = await _seller.PurchaseLists(DateTime.Parse(datefrm),DateTime.Parse(dateto).AddDays(1));
                ViewBag.From = from;
                ViewBag.To = to;
                var json = new
                {
                    draw = 1,
                    recordsTotal= prchs.Count,
                    recordsFiltered= prchs.Count,
                    data = prchs
                };
                return new JsonResult(json);
            }
        }

        public IActionResult index(int menu)
        {
            HttpContext.Session.SetString("menu", menu.ToString());
            return View();
        }
    }
}
