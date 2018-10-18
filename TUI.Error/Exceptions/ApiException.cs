using System;
using System.Net;
using Newtonsoft.Json;

namespace TUI.Error.Exceptions
{
    public class ApiException : Exception
    {
        public string Type { get; set; }

        public int HttpCode { get; set; }

        public ApiException(string type, HttpStatusCode httpCode, string message = null) : base(message)
        {
            Type = type;
            HttpCode = (int)httpCode;
        }

        public ApiException(string type, int httpCode, string message = null) : base(message)
        {
            Type = type;
            HttpCode = httpCode;
        }

        public ApiException(ErrorType type, HttpStatusCode httpCode, string message = null) : base(message)
        {
            Type = JsonConvert.SerializeObject(type).Trim('"');
            HttpCode = (int)httpCode;
        }

        public ApiException(ErrorType type, int httpCode, string message = null) : base(message)
        {
            Type = JsonConvert.SerializeObject(type).Trim('"');
            HttpCode = httpCode;
        }
    }
}