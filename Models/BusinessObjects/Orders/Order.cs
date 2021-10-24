using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Sections;

namespace resm_app.Models.BusinessObjects.Orders
{
    [Table("CCNS_Order",Schema = "dbo")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long OrderCode { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long CheckInId { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string CheckInStr { get; set; }
        
        [Column(TypeName = "int")]
        public int Floor { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long SectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long GSectoinId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GSectoinStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long SectionTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SectionTypeStr { get; set; }

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
        
        [Column(TypeName = "bigint")]
        public long BookingId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string BookingStatus { get; set; }
        
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
        
        [Column(TypeName = "bigint")]
        [Required]
        public long OrderById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string OrderByStr { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long ShiftId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string ShiftStr { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        
        [Column(TypeName = "time")]
        public TimeSpan DocTime { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdatedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UpdatedByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CancelById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CancelByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CancelDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CloseById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CloseByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public  DateTime? CloseDate { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string CancelStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string DocStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string OrderStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string OrderType { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? TimeIn { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? TimeOut { get; set; }

        [NotMapped]
        public IList<OrderDetail> OrderDetails { get; set; }
        [NotMapped]
        public Section Section { get; set; }
        [NotMapped]
        public BookingSection BookingSection { get; set; }
        
    }
}