using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.Edm;

namespace resm_app.Models.BusinessObjects.Exchanges
{
    [Table("CCNS_Exchange",Schema = "dbo")]
    public class Exchange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string ExStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Dollar { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Riel { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Started { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Start_Time { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? End { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string End_Time { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Default { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DocDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Deleted_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Deleted_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Deleted_Date { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Created_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Created_By_Name { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Updated_Date { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Updated_By_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Updated_By_Name { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
    }
}