using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SimpleWebServer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimpleWebServer.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        { 
            var httpStatusCodeException = exception as HttpStatusCodeException;
            HttpStatusCode statusCode;
            string message;

            bool exceptionIsHttpStatusCodeException = httpStatusCodeException != null;

            if (exceptionIsHttpStatusCodeException)
            {
                statusCode = httpStatusCodeException.StatusCode;
                message = exception.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Unexpected server side error.";
            }

            var responseBody = JsonConvert.SerializeObject(new { message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(responseBody);
        }
    }
}
