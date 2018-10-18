using System.Net;

namespace TUI.Error.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message = "Forbidden.") : base(ErrorType.Forbidden, HttpStatusCode.Forbidden, message) { }
    }
}