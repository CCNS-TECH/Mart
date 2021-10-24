using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Prefixs
{
    [Table("CCNS_AutoNumber",Schema = "dbo")]
    public class AutoNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column("nvarchar(125)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        [Required]
        public string Prefix{ get; set; }
        
        [Column(TypeName = "nvarchar(5)")]
        [Required]
        public string AutoKey { get; set; }
        [Column(TypeName = "bigint")]
        [Required]
        public long Started { get; set; } 
        [Column(TypeName = "bigint")]
        [Required]
        public long Next { get; set; }
        [Required]
        [Column(TypeName = "bigint")]
        public long End { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}