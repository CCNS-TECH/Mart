using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_SetPermission", Schema = "dbo")]
    public class SetPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }

        [Column(TypeName = "bigint")]
        public long MenuId { get; set; }

        [Column(TypeName = "bigint")]
        public long UserId { get; set; }

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

        //[NotMapped]
        //public IList<MenuPermission> Menu { get; set; }
    }
}
