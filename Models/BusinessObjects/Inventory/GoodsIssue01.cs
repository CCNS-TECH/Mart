using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Inventory
{
    [Table("CCNS_GoodsIssue01", Schema = "dbo")]
    public class GoodsIssue01
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }
        public int? LineNum { get; set; }
        [Column(TypeName = "bigint")]
        public long ItemId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ItemCode { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ItemStr { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Cost {get;set;}
        [Column(TypeName = "bigint")]
        public long? UoMId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string UoMStr { get; set; }
        [Column(TypeName = "bigint")]
        public long? GUoMId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string GUoMStr { get; set; }
        [Column(TypeName = "bigint")]
        public long? WhsId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string WhsStr { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalLine { get; set; }
        [Column(TypeName = "bigint")]
        public long? VendorId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string VendorStr { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DocDate { get; set; }
    }
}