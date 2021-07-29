using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskManager.Web.Models;

namespace TaskManager.Web
{
    internal sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, nameof(HttpStatusCode.InternalServerError));

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var response = new ErrorResponse(
                new[] {"Something went wrong."},
                context.Response.StatusCode);

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}