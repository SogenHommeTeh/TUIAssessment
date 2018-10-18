using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TUI.Error.Filters;

namespace TUI.Error
{
    public static class ErrorHandlerCollectionExtensions
    {
        public static IServiceCollection AddErrorHandler(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<ValidationModelFilter>();
                options.Filters.Add<ExceptionFilterAttribute>();
            });
            return services;
        }
    }
}
