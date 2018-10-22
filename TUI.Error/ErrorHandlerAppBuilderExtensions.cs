using Microsoft.AspNetCore.Builder;

namespace TUI.Error
{
    public static class ErrorHandlerAppBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            return app;
        }
    }
}
