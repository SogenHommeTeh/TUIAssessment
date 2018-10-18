using System.Net;

namespace TUI.Error.Exceptions
{
    public class AircraftAlreadyFlyingException : ApiException
    {
        public AircraftAlreadyFlyingException(string message = "Aircraft already flying.") : base(ErrorType.AircraftAlreadyFlying, HttpStatusCode.BadRequest, message) { }
    }
}