using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Kdss
{
    [Table("CCNS_Kds")]
    public class Kds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Kds is required")]
        public string GKdsStr { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [NotMapped]
        public virtual List<Kds01> Kds01s { get; set; }
    }
}