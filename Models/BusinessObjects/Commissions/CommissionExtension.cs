using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Commissions
{
    [Table("CNNS_CommissionExtension",Schema = "dbo")]
    public class CommissionExtension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName="bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string CommissionPrcnt { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CommissionValue { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}