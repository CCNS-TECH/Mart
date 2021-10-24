using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_AsignUser",Schema = "dbo")]
    public class AsignUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "bigint")]
        public long ToId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ToName { get; set; }
        
        [Column(TypeName = "bigint")]
        public long FromId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string FromName { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long AsignById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string AsignStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdatedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string UpdateByStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long DeletedById { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string DeletedByStr { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime DocDate { get; set; }
    }
}