using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Sections
{
    [Table("CCNS_Group_Section",Schema = "dbo")]
    public class GroupSection
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Group section is required")]
        public string GSectionEn { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string GSectionStr { get; set; }
        [Column(TypeName = "int")]
        public int Floor { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Type { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
    }
}