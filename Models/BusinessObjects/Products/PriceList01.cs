using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Products
{
    [Table("CCNS_PriceList01",Schema = "dbo")]
    public class PriceList01
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName= "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "bigint")]
        public long PriceList_Id { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Item_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Item_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UoM_ID { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string UoM_Str { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price_USD { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price_Riel { get; set; }
        
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
        public string Status { get; set; }
        
        [NotMapped]
        public PriceList PriceList { get; set; }
    }
}