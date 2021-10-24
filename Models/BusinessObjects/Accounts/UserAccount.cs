using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.Models.BusinessObjects.Accounts
{
    [Table("CCNS_User",Schema = "dbo")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id {get;set;}
        
        [Column(TypeName = "bigint")]
        public long Emp_Id { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Emp_Name { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        [Required(ErrorMessage = "Enter your user")]
        public string Username { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password is not match")]
        public string ConfirmPass { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string New_Password { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Old_Password { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter your email address")]
        public string Email { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your phone")]
        public string Phone { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Enter your the role user")]
        public long? Role_Id { get; set; }
        
        [Column(TypeName = "bigint")]
        public long? Permis_Id { get; set; }
        
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter your date")]
        public DateTime? CreateDate { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required]
        public long CreateById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required]
        public string CreateByName { get; set; }
        
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? UpdateDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdateById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string UpdateByName { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long DeleteById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string DeleteByName { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Img { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Old_Img { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        
        [NotMapped]
        public List<UserPermission> UserPermissions { get; set; }
        
        [NotMapped]
        public  Employee Employee { get; set; }
        [NotMapped]
        public UserRole UserRole { get; set; }
        [NotMapped]
        public UserPermission UserPermission { get; set; }
        [NotMapped]
        public  UserPermissionDetail UserPermissionDetail { get; set; }
    }
}