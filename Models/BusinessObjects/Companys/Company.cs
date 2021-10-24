using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.Companys
{
    [Table("CCNS_Company")]
    public class Company
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
       public long Id { get; set; }
       [Column(TypeName = "nvarchar(225)")]
       public string Company_En { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Company_Str { get; set; }
       
       [Column(TypeName = "nvarchar(25)")]
       [MaxLength(12)]
       [DataType(DataType.PhoneNumber)]
       public string Phone1 { get; set; }
       
       [Column(TypeName = "nvarchar(25)")]
       [DataType(DataType.PhoneNumber)]
       [MaxLength(12)]
       public string Phone2 { get; set; }
       
       [Column(TypeName = "nvarchar(125)")]
       [DataType(DataType.EmailAddress)]
       public string Email { get; set; }
       
       [Column(TypeName = "nvarchar(25)")]
       public string Wifi { get; set; }
       [Column(TypeName = "nvarchar(225)")]
       public string No_Num { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string St_Num { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Sangkat { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Khan { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string City { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Province { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Img { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Old_Img { get; set; }
       
       [Column(TypeName = "date")]
       public DateTime? Created_Date { get; set; }
        
       [Column(TypeName = "date")]
       public DateTime? Updated_Date { get; set; }
        
       [Column(TypeName = "date")]
       public DateTime? Deleted_Date { get; set; }
        
       [Column(TypeName = "bigint")]
       public long? Created_By_Id { get; set; }
        
       [Column(TypeName = "nvarchar(125)")]
       public string Created_By_Name { get; set; }
        
       [Column(TypeName = "bigint")]
       public long? Updated_By_Id { get; set; }
        
       [Column(TypeName = "nvarchar(125)")]
       public string Updated_By_Name { get; set; }
        
       [Column(TypeName = "bigint")]
       public long? Deleted_By_Id { get; set; }
        
       [Column(TypeName = "nvarchar(125)")]
       public string Deleted_By_Name { get; set; }
       
       [Column(TypeName = "nvarchar(1)")]
       public string Deleted { get; set; }
       
       [Column(TypeName = "nvarchar(1)")]
       public string Default { get; set; }
       
       [Column(TypeName = "nvarchar(225)")]
       public string Description { get; set; }
       
       [Column(TypeName = "nvarchar(1)")]
       public string Status { get; set; }
       
       public virtual List<Branch>Branchs { get; set; }
    }
}