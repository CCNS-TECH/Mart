using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Employees
{
    [Table("CCNS_Shift",Schema = "dbo")]
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Shift_Str { get; set; }
        
        [Column(TypeName = "int")]
        public int Hour { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string StartHour { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string EndHour { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}