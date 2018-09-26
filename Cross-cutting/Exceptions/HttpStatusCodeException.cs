using System;
using System.Collections.Generic;
using System.Text;

namespace Cross_cutting.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }
        public HttpStatusCodeException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
