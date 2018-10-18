using TUI.Error.Exceptions;

namespace TUI.Error.Responses
{
	public class ApiError
	{
		public string Type { get; set; }
		
		public string Message { get; set; }
		
		public static ApiError FromException(ApiException exception)
		{
			return new ApiError
			{
				Type = exception.Type,
				Message = exception.Message
			};
		}
	}
}