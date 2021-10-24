using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models.BusinessObjects.Inventory
{
    [Table("CCNS_Purchase",Schema ="dbo")]
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }

        [Column(TypeName ="bigint")]
        public long PchCode { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string InvCode { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscPrcnt { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscTotal { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TaxPrcnt { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TaxTotal { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal SubTotalUSD { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal SubTotalRiel { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DepositedUSD { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DepositedRiel { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalUSD { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalRiel { get; set; }

        [Column(TypeName = "bigint")]
        public long VendorId { get; set; }

        [Column(TypeName ="nvarchar(125)")]
        public string VendorStr { get; set; }

        [Column(TypeName = "bigint")]
        public long? CreateById { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string CreateByName { get; set; }

        [Column(TypeName = "bigint")]
        public long? DeleteById { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string DeleteByName { get; set; }

        [Column(TypeName = "bigint")]
        public long? UpdateById { get; set; }

        [Column(TypeName = "nvarchar(125)")]
        public string UpdateByName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string DocStatus { get; set; }

        public DateTime PurchaseDate { get; set; }
        [NotMapped]
        public IList<Purchase01> purchase01s { get; set; }
    }
}
