using MessageScheduler.Service.Middlewares;
using Microsoft.AspNetCore.Builder;


namespace MessageScheduler.Service.Extensions
{
    public static class ExceptionHandlerExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

}
