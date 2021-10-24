using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.UoMs
{
    [Table("CCNS_DUOM", Schema = "dbo")]
    public class DefineUoM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long DUoM_Id { get; set; }

        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The Group UoM Id is required")]
        public long GUoM_Id { get; set; }

        [Column(TypeName ="bigint")]
        [Required(ErrorMessage = "The UoM Id is required")]
        public long UoM_Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "The Alt UoM Name is required")]
        public string AltUoMName { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "The Alt Qty is required")]
        public decimal AltQty { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The Base UoM Id is required")]
        public long BaseUoM_Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string BaseUoM_Name { get; set; }

        [Column(TypeName ="decimal(18,6)")]
        [Required(ErrorMessage = "The Base Qty is required")]
        public decimal BaseQty { get; set; }

        [Column(TypeName = "bit")]
        public bool Used { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "The create by id  is required")]
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
        
        [NotMapped]
        public UoM UoM { get; set; }

        [NotMapped]
        public GroupUoM GroupUoM { get; set; }
        
    }
}
