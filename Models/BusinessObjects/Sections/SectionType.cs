using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Sections
{
    [Table("CCNS_SectionType",Schema = "dbo")]
    public class SectionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Type { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
    }
}