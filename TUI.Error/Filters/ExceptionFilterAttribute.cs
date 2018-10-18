using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using TUI.Error.Exceptions;
using TUI.Error.Responses;

namespace TUI.Error.Filters
{
	public class ExceptionFilterAttribute : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
            if (context.Exception is ApiException exception)
            {
                var response = new ApiResponseWithException(exception);

                context.Result = new ApiErrorResult(response);
                return;
            }

            context.Result = new ApiErrorResult(HttpStatusCode.InternalServerError, context.Exception.Message);
        }
    }
}