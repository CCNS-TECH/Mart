using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.Edm;

namespace resm_app.Models.BusinessObjects.Sections
{
    [Table("CCNS_CheckIn_Section",Schema = "dbo")]
    public class SectionCheckIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "int")]
        public int Pax { get; set; }
        
        [Column(TypeName = "int")]
        public int Floor { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Group section is required")]
        public long GSectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GSectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Section is required")]
        public long SectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Type section is required")]
        public long TypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TypeStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        
        [Column(TypeName = "time")]
        public TimeSpan? EndTime { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        
        [Column(TypeName = "int")]
        public int Duration { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CheckedInById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CheckedInByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CheckedInDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdatedInById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UpdatedByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CancelById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CancelByStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? CancelDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TransferFromSectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TransferFromSectionName { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TransferFromSectionTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TransferFromSectionTypeStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TransferToSectionId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TransferToSectionStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TransferToSectionTypeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TransferToSectionTypeStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? TransferDate { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? TransferTime { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TransferById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TransferByStr { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string CancelStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string TransferStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        
    }
}