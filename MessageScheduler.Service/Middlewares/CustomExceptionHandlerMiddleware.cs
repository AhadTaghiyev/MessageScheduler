using MessageScheduler.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageScheduler.Service.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = 500;
            string msg = "Internal server error!";

            if (exception is ItemNotFoundException)
            {
                statusCode = 404;
            }

            msg = exception.Message;

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            string responseStr = JsonConvert.SerializeObject(new
            {
                code = statusCode,
                message = msg
            });
            return context.Response.WriteAsync(responseStr);
        }
    }
}
