using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Taxs
{
    [Table("CCNS_Tax",Schema = "dbo")]
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Tax Name is required")]
        public string TaxStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "Rate is required")]
        public decimal Rate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DeletedDate{ get; set; }
        
        [Column(TypeName = "bigint")]
        public long CreateById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CreateStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdatedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UpdatedByStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long DeletedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string DeletedByStr { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Default { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}