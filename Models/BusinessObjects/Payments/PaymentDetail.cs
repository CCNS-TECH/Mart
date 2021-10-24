using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Invoices;
using resm_app.Models.BusinessObjects.Orders;
using resm_app.Models.BusinessObjects.Sections;

namespace resm_app.Models.BusinessObjects.Payments
{
    [Table("CCNS_Payment01",Schema = "dbo")]
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long DocEntry { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long InvCode { get; set; }
        
        [Column(TypeName = "bigint")]
        public long OrderCode { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long OrderById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string OrderByStr { get; set; }
        
        [Column(TypeName = "int")]
        public int Floor { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long SectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string SectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long GSectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GSectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long SectionTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SectionTypeStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal FreeHour { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        
        [Column(TypeName = "int")]
        public int LineNumber { get; set; }
        
        [Column(TypeName = "int")]
        public int BaseLine { get; set; }
        
        [Column(TypeName = "int")]
        public int RefLine { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long ItemId { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public string ItemCode { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string ItemStr { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        public string ItemType { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Cost { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        public string Currency { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal UnitPrice { get; set; }
        
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
        
        [Column(TypeName = "bigint")]
        [Required]
        public long WhsId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string WhsStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalDiscUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalDiscRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TaxPrcnt { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TaxRate { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxUSD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalTaxRiel { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal? TotalLine { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineFree { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }
        
        [NotMapped]
        public Invoice Invoice { get; set; }
        [NotMapped]
        public Section Section { get; set; }
        [NotMapped]
        public Order Order { get; set; }
        

    }
}