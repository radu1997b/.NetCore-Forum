using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Cross_cutting.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Cross_cutting.ExceptionHandlingFilter
{
    public class ErrorHandlerAttribute : ExceptionFilterAttribute
    {

        private IHostingEnvironment _hostingEnvironment;
        public ErrorHandlerAttribute(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (_hostingEnvironment.IsDevelopment())
                return;
            string message;
            if(context.Exception is HttpStatusCodeException)
            {
                var exception = context.Exception as HttpStatusCodeException;
                context.HttpContext.Response.StatusCode = exception.StatusCode;
                message = exception.Message;
            }
            else if (context.Exception is ArgumentOutOfRangeException)
            {
                var exception = context.Exception as ArgumentOutOfRangeException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = "No content";
            }
            else if(context.Exception is KeyNotFoundException)
            {
                var exception = context.Exception as KeyNotFoundException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                message = "Resource not found";
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                message = "Internal Server Error";
                //TODO Log stack trace in a file
            }
            context.Result = new ContentResult
            {
                Content = $"Status code:{context.HttpContext.Response.StatusCode}\n" +
                          $"Message:{message}"
            };
        }
    }
}
