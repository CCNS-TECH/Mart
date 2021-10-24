using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.IBusinessObject;
using resm_app.ViewModels;

namespace resm_app.Infrastructures.Token
{
    public class TokenProvider
    {
        public string LoginUser(UserAccount usr)
        {
            //Get user details for the user who is trying to login
            
            //Authenticate User, Check if it’s a registered user in Database 
            if (usr == null)
                return null;
            
            if (!string.IsNullOrEmpty(usr.Username))
            {
                var key = Encoding.ASCII.GetBytes
                    ("YC2uK@eyAeGaD-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv"); 
                //Generate Token for user 
                var JWToken = new JwtSecurityToken( 
                    issuer: "http://localhost:5000/",
                    audience: "http://localhost:5000/",
                    claims:new List<Claim> {new Claim(ClaimTypes.Name, usr.Username),
                                        new Claim("USERID",usr.Username),
                                        new Claim("EMAILID",usr.Email),
                                        new Claim("PHONE",usr.Employee.Phone1),
                                        new Claim("ACCESS_LEVEL",usr.UserPermission.Permis_En.ToUpper()),
                                        new Claim("READ_ONLY",usr.UserPermission.Read.ToUpper())
                    },
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token  
                    signingCredentials: new SigningCredentials
                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }
        private IEnumerable GetUserClaims(UserAccount user)
        {
            IEnumerable claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Emp_Name),
                new Claim("USERID", user.Username),
                new Claim("EMAILID", user.Email),
                new Claim("PHONE", user.Phone),
                new Claim("ACCESS_LEVEL", user.UserPermission.Permis_En.ToUpper()),
                new Claim("READ_ONLY", user.UserPermission.Read.ToUpper())
            };
            return claims;
        }  
    }
}