using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.BusinessPartners;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Sections;

namespace resm_app.Models.BusinessObjects.Invoices
{
    [Table("CCNS_Invoice",Schema = "dbo")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long InvCode { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long OrderCode { get; set; }
        
        [Column(TypeName= "int")]
        public int Floor { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long SectionId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string SectionStr { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string Duration { get; set; }
        
        [Column(TypeName="decimal(18,6)")]
        public decimal FreeHour { get; set; }
        
        [Column(TypeName="decimal(18,6)")]
        public decimal TotalHour { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal SectionPrice { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal SectionAmount { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long GSectionId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string GSectionStr { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long SectionTypeId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string SectionTypeStr { get; set; }

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
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ServiceChargeUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ServiceChargeRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal OtherChargeUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal OtherChargeRiel { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long ShiftId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string ShiftStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long BookingId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string BookingStatus { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionRate { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComssionRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal ComissionById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ComissionByStr { get; set; }
        
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
        
        [Column(TypeName = "bigint")]
        [Required]
        public long CreateById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CreateByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        
        [Column(TypeName = "time")]
        public TimeSpan DocTime { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CloseById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CloseByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CloseDate { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string CancelStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string DocStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string PayStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string Deleted { get; set; }

        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }
        [Column(TypeName = "bigint")]
        public long CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PayDate { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string InvType { get; set; }

        [Column(TypeName ="time")]
        public TimeSpan? TimeIn { get; set; }

        [Column(TypeName ="time")]
        public TimeSpan? TimeOut { get; set; }
        
        [NotMapped]
        public IList<InvoiceDetail> InvoiceDetails { get; set; }
        [NotMapped]
        public Section Section { get; set; }
        [NotMapped]
        public BusinessPartner BusinessPartner  { get; set; }
        [NotMapped]
        public BookingSection BookingSection { get; set; }
        [NotMapped]
        public IList<Order> Orders { get; set; }
        
    }
}