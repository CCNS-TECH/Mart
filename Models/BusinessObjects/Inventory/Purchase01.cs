using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models.BusinessObjects.Inventory
{
    [Table("CCNS_Purchase01",Schema ="dbo")]
    public class Purchase01
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName ="bigint")]
        public long Id { get; set; }

        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }

        [Column(TypeName = "int")]
        public int LineNum { get; set; }

        [Column(TypeName = "bigint")]
        public long ItemId { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string ItemCode { get; set; }

        [Column(TypeName = "nvarchar(225)")]
        public string ItemStr { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Cost { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Currentcy { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscPrcnt { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscTotal { get; set; }

        [Column(TypeName = "bigint")]
        public long UoMId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string UoMStr { get; set; }

        [Column(TypeName = "bigint")]
        public long GUoMId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string GUoMStr { get; set; }

        [Column(TypeName = "bigint")]
        public long WhsId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string WhsStr { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalLine { get; set; }

        [Column(TypeName = "bigint")]
        public long VendorId { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string VendorStr { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocDate { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}
