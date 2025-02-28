// Middleware/AnotherCustomMiddleware.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddlewareApp.Middleware
{
    public class AnotherCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Another Custom Middleware - Before\n");
            await _next(context);
            await context.Response.WriteAsync("Another Custom Middleware - After\n");
        }
    }
}