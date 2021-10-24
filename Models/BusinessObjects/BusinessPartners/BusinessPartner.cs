using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models.BusinessObjects.BusinessPartners
{
    [Table("CCNS_BusinessPartner", Schema ="dbo")]
    public class BusinessPartner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long VendorId { get; set; }
        [Column(TypeName = "bigint")]
        public long PriceListId { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        [Required]
        public string VendorName { get; set; }
        [Column(TypeName = "nvarchar(7)")]
        [Required]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public string Phone1 { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string Phone2 { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        [Required]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Type { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Delete { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "bigint")]
        [Required]
        public long CreateById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CreateByName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public long UpdateById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string UpdateByName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }
        [Column(TypeName = "bigint")]
        public long DeleteById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string DeleteByName { get; set; }
    }
}
