using System.Net;

namespace TUI.Error.Exceptions
{
    public class InvalidParameterException : ApiException
    {
        public InvalidParameterException(string message = "Invalid parameter(s).") : base(ErrorType.InvalidParameter, HttpStatusCode.BadRequest, message) { }
    }
}