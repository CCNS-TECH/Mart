using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Sections;

namespace resm_app.Models.BusinessObjects.Payments
{
    [Table("CCNS_Payment",Schema="dbo")]
    public class Payment
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DocEntry { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long PaymentCode { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal DiscPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalDiscUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalDiscRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TaxPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalTaxUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalTaxRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ExchangeRate { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long ShiftId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string ShiftStr { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ServiceChargeUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ServiceChargeRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal OtherChargeUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal OtherChargeRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal SubTotalUSD { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal SubTotalRiel { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal GrandTotalUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal GrandTotalRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ReceivedUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ReceivedRiel { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionPrcn { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionRate { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionRiel { get; set; }
        
        [Column(TypeName = "bigint")]
        public long ComissionById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ComissionByStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long BookingId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string BookingStatus { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? PaidDate { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long ReceivedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ReceivedByStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long MethodTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string MethodTypeStr { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string DocStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string CancelStatus { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CancelDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CancelById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CancelByStr { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string PayType { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Received_USD { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Received_Riel { get; set; }

        [NotMapped]
        public IList<PaymentDetail> PaymentDetails { get; set; }
        [NotMapped]
        public Section Section { get; set; }
        [NotMapped]
        public BookingSection BookingSection { get; set; }
        [NotMapped]
        public IList<Invoice> Invoices { get; set; }
    }
}