using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDotNetCore.FIlter
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //  throw new NotImplementedException();
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var routValue = context.ActionDescriptor.RouteValues.ToList();
            var action = routValue[0].Value.ToLower();// == "contact";
            var controller = routValue[1].Value.ToLower();// == "home";
            if (action=="contact" && controller == "home")
            {
                context.Result = new JsonResult(new { Message = "Home/Contact is not allowed",Error=true });
            }
        }
    }
}
