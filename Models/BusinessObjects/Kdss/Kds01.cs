using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Kdss
{
    [Table("CCNS_Kds01",Schema = "dbo")]
    public class Kds01
    {
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Kds01 is required")]
        public string KdsStr { get; set; }
        
        [Column(TypeName = "nvarchar(3)")]
        public string Type {get;set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Group kds01 is required")]
        public long KdsGroupId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string KdsGroupStr { get; set; }
        
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
        
        [Column(TypeName = "nvarchar(35)")]
        public string IPConfig { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        public virtual Kds GetKds { get; set; }
    }
}