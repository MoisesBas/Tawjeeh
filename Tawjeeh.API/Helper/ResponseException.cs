using System;

namespace Tawjeeh.Api.Helper
{
    public class ResponseException : Exception
    {
        public ResponseException(string message)
            : base(message)
        {

        }
    }
}