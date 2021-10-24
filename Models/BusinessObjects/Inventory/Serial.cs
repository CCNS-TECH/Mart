using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models.BusinessObjects.Inventory
{
    [Table("CCNS_Serail")]
    public class Serial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName= "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string SerailNum { get; set; }
        public long ItemId { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string ItemName { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal SaleQty { get; set; }
        [Column(TypeName= "bigint")]
        public long SaleUoMId { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string SaleUoMStr { get; set; }
        [Column(TypeName= "bigint")]
        public long UoMId { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string UoMStr { get; set; }
        [Column(TypeName= "datetime")]
        public DateTime? MFG { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName= "bigint")]
        public long DeletedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string DeletedByName { get; set; }
        [Column(TypeName= "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName= "bigint")]
        public long CreatedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CreatedByName { get; set; }
        [Column(TypeName= "datetime")]
        public DateTime? DeletedDate { get; set; }
        [Column(TypeName= "bigint")]
        public long? UpdatedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string UpdateByName { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string Status { get; set; }

    }
}
