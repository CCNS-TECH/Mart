using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models;
using resm_app.Models.BusinessObjects.CashInOuts;
using resm_app.Models.BusinessObjects.Prefixs;
using resm_app.Models.IBusinessObject;

namespace resm_app.Controllers
{
    [Authorize]
    //[CheckAuthorization]
    public class CashInOutsController : Controller
    {
        private readonly ICashInOut _cashInOut;
        private readonly IPayment _IPayment;

        public CashInOutsController(ICashInOut cashInOut,IPayment payment)
        {
            _cashInOut = cashInOut;
            _IPayment = payment;
        }
        //[HttpGet("cashIn/create")]
        public IActionResult CashIn()
        {
            return View();
        }

        //[HttpPost("cashIn/post")]
        [HttpPost]
        public async Task<IActionResult> CashInMoney(CashIn cashIn)
        {
            var payment = await _IPayment.GetPayments();

            if(payment.Count == 0 || payment == null) { 
                List<AutoNumber> auto = await _cashInOut.GetAutoNumbers();
                var No = auto.Where(a => a.AutoKey == "R").FirstOrDefault();
                cashIn.PaymentCode = No.Next;
            }
            else
            {
                cashIn.PaymentCode = payment.Max(p => p.PaymentCode);
            }


            if (ModelState.IsValid)
            {
                cashIn.CashInDate = DateTime.Now;
                cashIn.DocStatus = "O";
                cashIn.Delete = "N";
                var cashInId = await _cashInOut.InsertCashInAsync(cashIn);
                if (cashInId > 0)
                   await AddCashOutAsync(cashIn,cashInId);
                return RedirectToAction(nameof(CashIn));
            }
            return RedirectToAction(nameof(CashIn));
        }


        //[HttpGet("cashOut/create")]
        public IActionResult CashOut()
        {
            return View();
        }
        //[HttpPost("cashOut/post")]
        [HttpPost]
        public async Task<IActionResult> CashOutMoney(CashOut cashOut)
        {
            var CashIn = await _cashInOut.GetCashInAsync();
            var payment = (await _IPayment.GetPayments()).Where(pay=>pay.DocStatus=="C").ToList();
            cashOut.PayCodeMin = CashIn.Min(c => c.PaymentCode);
            if(payment.Count == 0)
                cashOut.PayCodeMin = CashIn.Max(c => c.PaymentCode);
            else
                cashOut.PayCodeMax = payment.Max(p => p.PaymentCode);
            cashOut.CashOutDate = DateTime.Now;

            var paid = payment.Where(p => p.PaymentCode > cashOut.PayCodeMin && p.PaymentCode <= cashOut.PayCodeMax);
            cashOut.SaleAmount = paid.Sum(p => p.GrandTotalUSD);
            cashOut.SaleAmountReil = paid.Sum(p => p.GrandTotalRiel);
            cashOut.TotalCashInUSD = CashIn.Where(_ => _.CashInById == cashOut.CashOutById).Sum(_ => _.TotalUSD);


            if (ModelState.IsValid)
            {
                var eff= await _cashInOut.UpdateCashOutAsync(cashOut);
                 if (eff > 0)
                     await UpdateCashInAsync(cashOut);
                 
                return RedirectToAction(nameof(CashOut));
            }
            return RedirectToAction(nameof(cashOut));
        }
        private async Task<int> AddCashOutAsync(CashIn cashIn,long cashInId)
        {
            var cashOut = new CashOut
            {
                CashInId = cashInId,
                CloseShiftId=cashIn.ShiftId,
                CloseShiftStr = cashIn.ShiftStr,
                TotalCashInUSD = cashIn.TotalUSD,
                TotalCashInRiel = cashIn.TotalRiel,
                ExchangeRate = cashIn.ExchangeRate,
                CashOutById = cashIn.CashInById,
                DocStatus = "O",
                Delete = "N"
            };
            return await _cashInOut.InsertCashOutAsync(cashOut);
        }

        private async Task<int> UpdateCashInAsync(CashOut cashOut)
        {
            var cashIn = new CashIn
            {
                Id = cashOut.CashInId
            };
            return await _cashInOut.UpdateCashInAsync(cashIn);
        }
        public async Task<IActionResult> Check_CashIn()
        {
            var id = int.Parse(HttpContext.Session.GetString("OwnnerId"));
            var dataCashin = await _cashInOut.GetCashInAsync();
            if (dataCashin != null)
            {
                var cashin = dataCashin.Where(c=>c.CashInById==id);
                if (cashin.Count() > 0)
                {
                    return Ok(true);
                }
            }
            

            return Ok(false);

        }

    }
}