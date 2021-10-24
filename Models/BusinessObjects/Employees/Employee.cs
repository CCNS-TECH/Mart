using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using resm_app.Models.BusinessObjects.Accounts;

namespace resm_app.Models.BusinessObjects.Employees
{
    [Table("CCNS_Emp",Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(8)")]
        [MaxLength(8)]
        [Required(ErrorMessage = "Enter your user code")]
        public string Emp_Code { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [MaxLength(125)]
        [Required(ErrorMessage = "Enter your user name")]
        public string Emp_Name { get; set; }
        
        [Column(TypeName = "nvarchar(8)")]
        [MaxLength(8)]
        [Required(ErrorMessage = "Select your gender")]
        public string Gender { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Join_Date { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DoB { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        [MaxLength(25)]
        public string Card_Num { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Enter your phone")]
        public string Phone1 { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Phone2 { get; set; }
        
        
        [Column(TypeName = "bigint")]
        public long Shift_Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Shift_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Dept_Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Dept_Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long Post_Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string Post_Str { get; set; }
        
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
        
        [Column(TypeName = "nvarchar(225)")]
        public string No_Num { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string St_Num { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required(ErrorMessage = "Enter your commune/sangkat")]
        public string Sangkat { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required(ErrorMessage = "Enter your district/khan")]
        public string Khan { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string City { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Province { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Img { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Old_Img { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [MaxLength(1)]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        [MaxLength(1)]
        public string Status { get; set; }
        
        [NotMapped]
        public UserAccount UserAccount { get; set; }
        [NotMapped]
        public List<UserAccount>UserAccounts { get; set; }
        [NotMapped]
        public  Shift Shift { get; set; }
    }
}