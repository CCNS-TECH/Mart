using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace resm_app.Models.BusinessObjects.Orders
{
    [Table("CCNS_Order01",Schema = "dbo")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "int")]
        public int LineNumber{get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long DocEntry { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long ItemId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ItemCode { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ItemStr { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ItemTypeStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Cost { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal UnitPrice { get; set; }
        
        [Column(TypeName = "nvarchar(5)")]
        public string Currency { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long UoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UoMStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long GUoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GUoMStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalDiscUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalDiscRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxRate { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal? TotalLine { get; set; }

        [Column(TypeName = "bigint")]
        public long UpdateById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UpdateByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CancelById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CancelByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CancelDate { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string CancelStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string LineStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string BillStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineFree { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [Required]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Description { get; set; }
        
        [NotMapped]
        public Order Order { get; set; }
    }
}