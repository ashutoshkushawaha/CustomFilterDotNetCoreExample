using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FilterDotNetCore.FIlter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var mess = context.Exception.Message;
            var exceptionType = context.Exception.GetType();

            //if (exceptionType is MyCustomException) //Checking for my custom exception type
            //{
            //    message = context.Exception.Message;
            //}

            //You can enable logging error

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(new  { Message = mess, StatusCode = response.StatusCode });
        }
    }
}