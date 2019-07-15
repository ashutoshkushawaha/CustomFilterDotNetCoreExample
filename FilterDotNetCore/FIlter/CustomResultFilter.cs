using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDotNetCore.FIlter
{
    public class CustomResultAttribute : Attribute, IResultFilter
    {
        string _value;
        public CustomResultAttribute(string value)
        {
            _value = value;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //  throw new NotImplementedException();
            return;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Author", new string[] { _value });
        }
    }
}
