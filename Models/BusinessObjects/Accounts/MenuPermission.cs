using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_MenuPermission",Schema ="dbo")]
    public class MenuPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }

        [Column(TypeName ="bigint")]
        public long ParentId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Controller { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Action { get; set; }

        [Column(TypeName = "int")]
        public int? OrderBy { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Icon { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string Type { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        public string Status { get; set; }

        [Column(TypeName = "bigint")]
        public long Created_by { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Created_At { get; set; }

        [Column(TypeName = "bigint")]
        public long? Updated_by { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Update_At { get; set; }
    }
}
