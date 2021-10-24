using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public decimal? Food { get; set; }
        
        public decimal FoodQty { get; set; }
        public decimal? Beverage { get; set; }
        
        public decimal BeverageQty { get; set; }
        public decimal Service { get; set; }
        public decimal OtherCharge { get; set; }
        public decimal SectionAmount { get; set; }
        
        public Employee Employee { get; set; }
    }
}