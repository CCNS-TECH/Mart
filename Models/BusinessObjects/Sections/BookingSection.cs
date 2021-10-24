using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Sections
{
    [Table("CCNS_Booking_Section")]
    public class BookingSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Customer is required")]
        public long CustomerId { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string CustomerStr { get; set; }
        
        [Column(TypeName ="nvarchar(7)")]
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName ="nvarchar(25)")]
        public string Phone1 { get; set; }
        
        [Column(TypeName ="nvarchar(25)")]
        public string Phone2 { get; set; }
        
        [Column(TypeName ="int")]
        public int Pax { get; set; }
        
        [Column(TypeName ="int")]
        public int Floor { get; set; }
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Section is required")]
        public long SectionId { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string SectionStr { get; set; }
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Group section is required")]
        public long GSectionId { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string GSectionStr { get; set; }
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Type section is required")]
        public long TypeId { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string TypeStr { get; set;}
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Booking by name is required")]
        public long BookedById { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string BookedByName { get; set; }
        
        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "Create by name is required")]
        public long CreatedById { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string CreatedByName { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime? BookedDate { get; set; }
        
        [Column(TypeName ="datetime")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName ="bigint")]
        public long UpdatedById { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string UpdatedByStr { get; set; }
        
        [Column(TypeName ="datetime")]
        public DateTime? StartDate { get; set; }
        
        [Column(TypeName ="time")]
        public TimeSpan? StartTime { get; set; }
        
        [Column(TypeName ="nvarchar(2)")]
        public  int Hour { get; set; }
        
        [Column(TypeName ="nvarchar(2)")]
        public  int Minute { get; set; }
        
        [Column(TypeName ="nvarchar(2)")]
        public  int EndHour { get; set; }
        
        [Column(TypeName ="nvarchar(2)")]
        public  int EndMinute { get; set; }
        
        
        [Column(TypeName ="time")]
        public TimeSpan? EndTime { get; set; }
        
        [Column(TypeName ="nvarchar(1)")]
        public string ConfirmStatus { get; set; }
        
        [Column(TypeName ="datetime")]
        public DateTime? ConfirmDate { get; set; }
        
        [Column(TypeName ="bigint")]
        public long ConfirmById { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string ConfirmByStr { get; set; }
        
        [Column(TypeName ="nvarchar(1)")]
        public string CancelStatus { get; set; }
        
        [Column(TypeName ="datetime")]
        public DateTime? CancelDate { get; set; }
        
        [Column(TypeName ="time")]
        public TimeSpan? CancelTime { get; set; }
        
        [Column(TypeName ="bigint")]
        public long CancelById { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string CancelByStr { get; set; }
        
        [Column(TypeName ="nvarchar(125)")]
        public string LineStatus { get; set; }
        
        [Column(TypeName ="nvarchar(225)")]
        public string Description { get; set; }
        
        [Column(TypeName ="nvarchar(1)")]
        public string Deleted { get; set; }
        
        [NotMapped]
        public Section Section { get; set; }
        
    }
}