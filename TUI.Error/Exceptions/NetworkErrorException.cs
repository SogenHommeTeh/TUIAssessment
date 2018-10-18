using System.Net;

namespace TUI.Error.Exceptions
{
    public class NetworkErrorException : ApiException
    {
        public NetworkErrorException(string message = "Internal network error.") : base(ErrorType.NetworkError, HttpStatusCode.InternalServerError, message) { }
    }
}