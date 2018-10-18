using System;
using System.Net;

namespace TUI.Error.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(Guid id, string message = "Not found (id:'{0}').") : base(ErrorType.NotFound, HttpStatusCode.NotFound, string.Format(message, id)) { }

        public NotFoundException(int id, string message = "Not found (id:'{0}').") : base(ErrorType.NotFound, HttpStatusCode.NotFound, string.Format(message, id)) { }

        public NotFoundException(string message = "Not found.") : base(ErrorType.NotFound, HttpStatusCode.NotFound, message) { }
    }
}