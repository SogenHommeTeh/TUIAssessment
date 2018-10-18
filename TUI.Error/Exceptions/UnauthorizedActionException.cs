using System.Net;

namespace TUI.Error.Exceptions
{
    public class UnauthorizedActionException : ApiException
    {
        public UnauthorizedActionException(string message = "Unauthorized action(s).") : base(ErrorType.UnauthorizedAction, HttpStatusCode.Unauthorized, message) { }
    }
}