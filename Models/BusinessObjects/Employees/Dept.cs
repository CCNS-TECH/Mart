using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace resm_app.Models.BusinessObjects.Employees
{
    [Table("CCNS_Dept",Schema = "dbo")]
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public  long Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Dept_En { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Dept_Str { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Color { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
    }
}