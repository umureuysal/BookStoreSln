﻿using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using WebApi.Services;

namespace WebApi.Middleware
{
    public class CustomException
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _service;
        public CustomException(RequestDelegate next, ILoggerService service)
        {
            _next = next;
            _service = service;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _service.Write(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
                _service.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }

        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + " StatusCode: " + context.Response.StatusCode + "Error Message: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms ";
            _service.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);

        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomException>();
        }
    }
}
