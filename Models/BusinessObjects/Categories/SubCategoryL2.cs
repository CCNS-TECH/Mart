using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Categories
{
    [Table("CCNS_SubCategoryL2",Schema = "dbo")]
    public class SubCategoryL2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long SubCateL2_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required(ErrorMessage = "The file is required")]
        public string SubCateL2_En { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string SubCateL2_Str { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string ColorL2 { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The file is required")]
        public long SubCateL1_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string SubCateL1_Str { get; set; }
        
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
        
        [Column(TypeName = "date")]
        public DateTime? Deleted_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Deleted_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Deleted_By_Name { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        
        [NotMapped]
        public SubCategoryL1 SubCategoryL1 { get; set; }
        
    }
}