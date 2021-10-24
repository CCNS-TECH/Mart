using System;
namespace resm_app.ViewModels
{
    public class PaymentReportViewModel
    {
         public long DocEntry { get; set; }
        public long PaymentCode { get; set; }
        public decimal DiscPrcnt { get; set; }
        public decimal TotalDiscUSD { get; set; }
        public decimal TotalDiscRiel { get; set; }
        public decimal TaxPrcnt { get; set; }
        public decimal TotalTaxUSD { get; set; }
        public decimal TotalTaxRiel { get; set; }
        public decimal ExchangeRate { get; set; }
        public long ShiftId { get; set; }
        public string ShiftStr { get; set; }
        public decimal ServiceChargeUSD { get; set; }
        public decimal ServiceChargeRiel { get; set; }
        public decimal OtherChargeUSD { get; set; }
        public decimal OtherChargeRiel { get; set; }
        public decimal SubTotalUSD { get; set; }
        public decimal SubTotalRiel { get; set; }
        public decimal GrandTotalUSD { get; set; }
        public decimal GrandTotalRiel { get; set; }
        public decimal ReceivedUSD { get; set; }
        public decimal ReceivedRiel { get; set; }
        public decimal ComissionPrcn { get; set; }
        public decimal ComissionRate { get; set; }
        public decimal ComissionUSD { get; set; }
        public decimal ComissionRiel { get; set; }
        public long ComissionById { get; set; }
        public string ComissionByStr { get; set; }
        public long BookingId { get; set; }
        public string BookingStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public TimeSpan PaidTime { get; set; }
        public long ReceivedById { get; set; }
        public string ReceivedByStr { get; set; }
        public long MethodTypeId { get; set; }
        public string MethodTypeStr { get; set; }
        public string DocStatus { get; set; }
        public string CancelStatus { get; set; }
        public DateTime? CancelDate { get; set; }
        public long CancelById { get; set; }
        public string CancelByStr { get; set; }
        public string Deleted { get; set; }
        public string Description { get; set; }
        
       
        public string PayType { get; set; }
        
    }
}
