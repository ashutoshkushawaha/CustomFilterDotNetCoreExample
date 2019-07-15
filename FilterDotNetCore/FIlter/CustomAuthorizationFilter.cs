using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDotNetCore.FIlter
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute() : base(typeof(CustomAuthorizationFilter))
        {
            Arguments = new object[] { };
        }
    }
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
      

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if(context.HttpContext.User.Identity.Name!="admin@filter.com")
            {
                //context.Result = new UnauthorizedResult();
                context.Result = new JsonResult(new { Message = "not authorized", StatusCode = "401" });
            }
            
        }
    }
}
