// Middleware/CustomMiddleware.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddlewareApp.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Perform actions before the next middleware in the pipeline
            await context.Response.WriteAsync("Custom Middleware - Before\n");

            // Call the next middleware in the pipeline
            await _next(context);

            // Perform actions after the next middleware in the pipeline
            await context.Response.WriteAsync("Custom Middleware - After\n");
        }
    }
}