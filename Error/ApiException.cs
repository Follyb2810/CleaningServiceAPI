using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Error
{
    public abstract class ApiException : Exception
    {
        public int StatusCode { get; }
        protected ApiException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}