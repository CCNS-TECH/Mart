using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.UoMs
{
    [Table("CCNS_GUOM",Schema ="dbo")]
    public class GroupUoM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long GUoM_Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "The Group UoM Name is required")]
        public string GUoM_Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string GUoM_Foreign { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The create by id is required")]
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
    }
}
