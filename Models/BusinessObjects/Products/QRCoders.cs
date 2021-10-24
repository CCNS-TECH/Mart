using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Products
{
    [Table("CCNS_QRCoders",Schema = "dbo")]
    public class QRCoders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GuidCode { get; set; }
        
        
        [Column(TypeName = "nvarchar(125)")]
        public string ItemStr { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}