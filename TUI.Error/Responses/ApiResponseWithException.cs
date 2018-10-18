using TUI.Error.Exceptions;

namespace TUI.Error.Responses
{
	public class ApiResponseWithException : ApiResponse
	{
		public ApiError Error { get; }

		public ApiResponseWithException(ApiException exception, string message = null) : base(exception.HttpCode, message)
		{
			Error = ApiError.FromException(exception);
		}
	}
}