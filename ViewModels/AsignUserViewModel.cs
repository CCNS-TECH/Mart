using System;
using Microsoft.OData.Edm;

namespace resm_app.ViewModels
{
    public class AsignUserViewModel
    {
        public long ToId { get; set; }
        public string ToName { get; set; }
        public long FromId { get; set; }
        public string FromName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long AsignById { get; set; }
        public string AsignStr { get; set; }
        public long UpdatedById { get; set; }
        public string UpdateByStr { get; set; }
        public long DeletedById { get; set; }
        public string DeletedByStr { get; set; }
        public DateTime DocDate { get; set; }
    }
}