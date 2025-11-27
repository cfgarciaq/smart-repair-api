using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace SmartRepairApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next; // Next middleware in the pipeline
        private readonly ILogger<GlobalExceptionMiddleware> _logger; // Logger for logging exceptions

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Main middleware invocation
        public async Task InvokeAsync(HttpContext context)
        {
            // Try to process the request
            try
            {
                await _next(context);
            }
            // Handle FluentValidation exceptions
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            // Handle all other exceptions
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        // Handle FluentValidation exceptions
        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            // For validation errors, return a 400 Bad Request with details
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            // Group errors by property name
            var errors = exception.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            // Serialize the error response
            var result = JsonSerializer.Serialize(new
            {
                status = context.Response.StatusCode,
                errors,
                path = context.Request.Path,
                timestamp = DateTime.UtcNow
            });

            // Write the response
            return context.Response.WriteAsync(result);
        }

        // Handle unexpected exceptions
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // For unexpected exceptions, return a generic error response
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Log the exception details (already done in InvokeAsync)
            var result = JsonSerializer.Serialize(new
            {
                status = context.Response.StatusCode,
                errors = new
                {
                    Server = new[] { exception.Message }
                },
                path = context.Request.Path,
                timestamp = DateTime.UtcNow
            });

            // Write the response
            return context.Response.WriteAsync(result);
        }
    }
}
