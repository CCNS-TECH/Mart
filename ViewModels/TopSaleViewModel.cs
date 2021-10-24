using System;

namespace resm_app.ViewModels
{
    public class TopSaleViewModel
    {
        public int Id { get; set; }
        public long DocEntry { get; set; }
        public long OrderById { get; set; }
        public string OrderByStr { get; set; }
        public DateTime DocDate { get; set; }
        public int LineNum { get; set; }
        public int BaseLine { get; set; }
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemStr { get; set; }
        public long ItemTypeId { get; set; }
        public string ItemTypeStr { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public string Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public long SizeId { get; set; }
        public string SizeStr { get; set; }
        public long UoMId { get; set; }
        public string UoMStr { get; set; }
    }
}