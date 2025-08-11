using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Error
{
    public class ErrorHandler
    {

    }
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(message, 404) { }
    }

    public class ConflictException : ApiException
    {
        public ConflictException(string message) : base(message, 409) { }
    }

    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message, 400) { }
    }

}