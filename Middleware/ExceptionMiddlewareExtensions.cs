namespace SmartRepairApi.Middleware
{
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        // Extension method to add the GlobalExceptionMiddleware to the application pipeline
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            // Use the GlobalExceptionMiddleware
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
