using Microsoft.AspNetCore.Builder;
using Training.Service.Middleware;

namespace Training.Service.Extensions
{
    public static class GlobalExceptionMiddleware
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
