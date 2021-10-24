using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Orders;

namespace resm_app.Models.BusinessObjects.Sections
{
    [Table("CNNS_Section",Schema = "dbo")]
    public class Section
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Section name is required")]
        public string SectionEn { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string SectionStr { get; set; }
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Group section is required")]
        public long GSectionId { get;  set;  }
        [Column(TypeName = "nvarchar(125)")]
        public string GSectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TypeId { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }
        [Column(TypeName = "bigint")]
        public long CreatedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CreateByStr { get; set; }
        [Column(TypeName = "bigint")]
        public long UpdatedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string UpdatedByStr { get; set; }
        [Column(TypeName = "bigint")]
        public long DeletedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string DeletedByStr { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string BookingStatus { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        [Column(TypeName = "bigint")]
        public long CheckInId { get; set; }
        
        [Column(TypeName = "bigint")]
        public long BookingId { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }
        
        public virtual GroupSection GroupSection { get; set; }
        
        [NotMapped]
        public virtual SectionCheckIn SectionCheckIn { get; set; }
        [NotMapped]
        public virtual List<BookingSection> BookingSections { get; set; }
        
        [NotMapped]
        public virtual BookingSection BookingSection { get; set; }
        
        [NotMapped]
        public SectionType SectionType { get; set; }
        [NotMapped]
        public  Order Order { get; set; }
        
        
        
    }
}