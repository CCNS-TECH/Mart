using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Payments
{
    [Table("CCNS_PaymentMethod",Schema = "dbo")]
    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string MethodEn { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string MethodStr { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public  string Deleted { get; set; }
    }
}