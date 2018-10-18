using System.Net;
using Microsoft.AspNetCore.Mvc;
using TUI.Error.Responses;

namespace TUI.Error
{
    public class ApiErrorResult : ObjectResult
    {
        public ApiErrorResult(ApiResponse response)
            : base(response)
        {
            StatusCode = response.StatusCode;
        }

        public ApiErrorResult(HttpStatusCode statusCode, string message = null)
            : base(new ApiResponse(statusCode, message))
        {
            StatusCode = (int)statusCode;
        }

        public ApiErrorResult(int statusCode, string message = null)
            : base(new ApiResponse(statusCode, message))
        {
            StatusCode = statusCode;
        }
    }
}
