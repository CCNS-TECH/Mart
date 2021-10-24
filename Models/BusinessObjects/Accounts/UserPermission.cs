using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_Permission",Schema = "dbo")]
    public class UserPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Permis_En { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Create { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Update { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Delete { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Read { get; set; }
        
        [Column(TypeName = "int")]
        public int Level { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [NotMapped]
        public  List<UserPermissionDetail> PermissionDetails { get; set; }
    }
}