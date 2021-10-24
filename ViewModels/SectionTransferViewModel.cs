using System;
using System.ComponentModel.DataAnnotations;

namespace resm_app.ViewModels
{
    public class SectionTransferViewModel
    {
        [Required]
        public long FromSectionId { get; set; }
        public string FromSectionStr { get; set; }
        [Required]
        public long ToSectionId { get; set; }
        public string ToSectionStr { get; set; }
        [Required]
        public long SectionTypeId { get; set; }
        public string SectionTypeStr { get; set; }
        
        public decimal SectionPrice { get; set; }
        
        public DateTime? TransferDate { get; set; }
        
        [Required]
        public long TransferById { get; set; }
        public string TransferByStr { get; set; }
        [Required]
        public string Description { get; set; }
        public  long ToGroupSectionId { get; set; }
        public string ToGroupSectionStr { get; set; }
    }
}