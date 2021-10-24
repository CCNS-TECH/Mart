using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.ViewModels
{
    public class CheckInViewModel
    {
        public long Id { get; set; }
        public int Pax { get; set; }
        public int Floor { get; set; }
        public long GSectionId { get; set; }
        public string GSectionStr { get; set; }
        public long SectionId { get; set; }
        public string SectionStr { get; set; }
        public long TypeId { get; set; }
        public string TypeStr { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? EndDate { get; set; }
        public int Duration { get; set; }
        public long CheckedInById { get; set; }
        public string CheckedInByStr { get; set; }
        public DateTime? CheckedInDate { get; set; }
        public long UpdatedInById { get; set; }
        public string UpdatedByStr { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long CancelById { get; set; }
        public string CancelByStr { get; set; }
        public DateTime? CancelDate { get; set; }
        public long TransferFromSectionId { get; set; }
        public string TransferFromSectionName { get; set; }
        public long TransferFromSectionTypeId { get; set; }
        public string TransferFromSectionTypeStr { get; set; }
        public long TransferToSectionId { get; set; }
        public string TransferToSectionStr { get; set; }
        public long TransferToSectionTypeId { get; set; }
        public string TransferToSectionTypeStr { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? TransferTime { get; set; }
        public long TransferById { get; set; }
        public string TransferByStr { get; set; }
        public string Description { get; set; }
        public string CancelStatus { get; set; }
        public string TransferStatus { get; set; }
        public string LineStatus { get; set; }
        public string Deleted { get; set; }
    }
}