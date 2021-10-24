using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resm_app.Models
{
    public class CheckAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Identity.IsAuthenticated;
            var userId = context.HttpContext.Session.GetString("OwnnerId");
            
            if (userId == null || !user)
            {
                context.Result = new RedirectResult("/Account/LogOut");
            }
        }
    }
}
