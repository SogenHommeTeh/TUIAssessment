using Microsoft.AspNetCore.Builder;

namespace TUI.Error
{
    public static class ErrorHandlerAppBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
