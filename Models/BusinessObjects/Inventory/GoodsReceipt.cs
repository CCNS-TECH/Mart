using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models.BusinessObjects.Inventory
{
    [Table("CCNS_GoodsReceipt", Schema ="dbo")]
    public class GoodsReceipt
    {
        [Key]
        [Column(TypeName ="bigint")]
        public long DocEntry { get; set; }
        [Column(TypeName = "bigint")]
        public long CreateById { get; set; }
        [Column(TypeName ="nvarchar(255)")]
        public string CreateByName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        [NotMapped]
        public IList<GoodsReceipt01> GoodsReceipt01s { get; set; }
    }
}
