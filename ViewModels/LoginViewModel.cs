using System.Collections.Generic;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Employees;

namespace resm_app.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public  string Username { get; set; }
        public string Password { get; set; }
        
        public string Access_Level { get; set; }
        
        public string Read_Only { get; set; }
        
        public bool Remember { get; set; }
        public List<UserAccount> UserProfiles { get; set; }
    }
}