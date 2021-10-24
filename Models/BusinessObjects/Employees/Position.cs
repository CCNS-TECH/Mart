using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace resm_app.Models.BusinessObjects.Employees
{
    [Table("CCNS_Position",Schema = "dbo")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Position_En { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Position_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Dept_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Color { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
    }
}