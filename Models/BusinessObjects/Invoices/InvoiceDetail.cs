using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Products;

namespace resm_app.Models.BusinessObjects.Invoices
{
    [Table("CCNS_Invoice01")]
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName= "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long DocEntry { get; set; }
        [Column(TypeName= "bigint")]
        [Required]
        public long OrderById { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string OrderByStr { get; set; }
        
        [Column(TypeName= "datetime")]
        [Required]
        public DateTime? DocDate { get; set; }
        
        [Column(TypeName= "int")]
        public int LineNum { get; set; }
        
        [Column(TypeName= "int")]
        public int BaseLine { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long ItemId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        [Required]
        public string ItemCode { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string ItemStr { get; set; }
        
        [Column(TypeName= "bigint")]
        public long ItemTypeId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string ItemTypeStr { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        [Required]
        public decimal Quantity { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal Cost { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string Currency { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        [Required]
        public decimal UnitPrice { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long SizeId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string SizeStr { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long UoMId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string UoMStr { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long GUoMId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string GUoMStr { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? DiscPrcnt { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TotalDiscUSD { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TotalDiscRiel { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TaxPrcnt { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TaxRate { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TotalTaxUSD { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        public decimal? TotalTaxRiel { get; set; }
        
        [Column(TypeName= "decimal(18,6)")]
        [Required]
        public decimal? TotalLine { get; set; }
        
        [Column(TypeName= "bigint")]
        [Required]
        public long WhsId { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        public string WhsStr { get; set; }
        
        [Column(TypeName= "nvarchar(125)")]
        [Required]
        public string LineStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineFree { get; set; }
        
        [Column(TypeName= "nvarchar(1)")]
        [Required]
        public string Deleted { get; set; }
        
        [Column(TypeName= "nvarchar(225)")]
        public string Description { get; set; }
        
        [NotMapped]
        public  Item Item { get; set; }
    }
}