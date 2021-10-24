using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Whs
{
    [Table("CCNS_Whs01",Schema = "dbo")]
    public class Whs01
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "bigint")]
        public long WhsId { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Item_Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Item_Str { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal InStock { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Deleted_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Deleted_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Deleted_Date { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The file is required")]
        public long Created_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Created_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Updated_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Updated_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Updated_By_Name { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
    }
}