using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_Permission01",Schema = "dbo")]
    public class UserPermissionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Perm_En { get; set; }
        [Column(TypeName = "bigint")]
        public long DocEntry { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Permis_Str { get; set; }
        [Column(TypeName = "bigint")]
        public long Role_Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public  string Role_Str { get; set; }
        
        [Column(TypeName = "int")]
        public int Level { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}