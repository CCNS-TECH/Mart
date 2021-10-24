using System;
using System.ComponentModel.DataAnnotations;

namespace resm_app.ViewModels
{
    public class CreditPaymentViewModel
    {
        public long Id { get; set; }
        [Required]
        public string InvCode { get; set; }
        public long PaymentCode {get; set; }
        [Required]
        public long CustomerId { get; set; }
        public string CustomerStr { get; set; }
        [Required]
        public long SectionId { get; set; }
        public string SectionStr { get; set; }
        public long BookingId { get; set; }
        public string BookingStatus { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public decimal CommissionPrcnt { get; set; }
        public decimal CommissionRate { get; set; }
        public string Description { get; set; }
        public decimal GrandTotalUSD  {get; set; }
        public decimal GrandTotalRiel {get; set; }
        public decimal CommissionTotalUSD { get; set; }
        public decimal CommissionTotalRiel { get; set; }
        
        public long CommissionById { get; set; }
        public string CommissionByStr { get; set; }
        [Required]
        public long CreateById { get; set; }
        public string CreateByStr { get; set; }
        public long ShiftId { get; set; }
        public string ShiftStr { get; set; }
        public long MethodTypeId { get; set; }
        public string MethodTypeStr { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        
    }
}