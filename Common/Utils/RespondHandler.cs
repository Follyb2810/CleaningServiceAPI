using System.Net;

namespace CleaningServiceAPI.Common
{
    public class ApiResponse
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }

    public static class ResponseHandler
    {
        public static ApiResponse SuccessMessage(string message, HttpStatusCode statusCode = HttpStatusCode.OK, object? data = null)
        {
            return new ApiResponse
            {
                Message = message,
                StatusCode = (int)statusCode,
                Data = data
            };
        }

        public static ApiResponse ErrorMessage(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, object? data = null)
        {
            return new ApiResponse
            {
                Message = message,
                StatusCode = (int)statusCode,
                Data = data
            };
        }
    }
}