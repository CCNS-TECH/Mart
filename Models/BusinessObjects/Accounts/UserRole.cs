using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_Role",Schema = "dbo")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Role_En { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [NotMapped]
        public List<UserPermission> UserPermissions { get; set; }
    }
}