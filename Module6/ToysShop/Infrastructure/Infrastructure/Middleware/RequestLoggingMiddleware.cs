using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                _logger.LogInformation($"Received request: {context.Request.Method}. Response Status: {context.Response.StatusCode} Path: {context.Request.Path}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error");
            }
        }
    }
}
