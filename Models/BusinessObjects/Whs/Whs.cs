using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Whs
{
    [Table("CCNS_Whs",Schema = "dbo")]
    public class Whs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public  long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Whs_En { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Whs_Str { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal InStock { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Default { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Address { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Remark { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Deleted_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Deleted_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Deleted_Date { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Created_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Created_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Updated_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Updated_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Updated_By_Name { get; set; }
    }
}