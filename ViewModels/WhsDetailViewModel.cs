using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.ViewModels
{
    public class WhsDetailViewModel
    {
        public long Id { get; set; }
        
        
        public long DocEntry { get; set; }
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemStr { get; set; }
        public string ItemType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public long UoMId { get; set; }
        public string UoMStr { get; set; }
        public long GUoMId { get; set; }
        public string GUoMStr { get; set; }
        public long WhsId { get; set; }
        public string WhsStr { get; set; }
        
        
    }
}