using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Companys
{
    [Table("CCNS_Branch",Schema = "dbo")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Branch_En { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Branch_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Company_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public  string Company_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Whs_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Whs_Str { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string No_Num { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string St_Num { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Sangkat { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Khan { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string City { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Province { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Img { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Old_Img { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Default { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        
        [NotMapped]
        public  Company Company { get; set; }
    }
}