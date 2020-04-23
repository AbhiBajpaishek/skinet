using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } 
        public string Message { get; set; } 

        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode=statusCode;
            Message=message?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch{
                400 => "Bad Request made by you",
                401 => "Not Authorized ",
                404 => "Not Found Error",
                500 => "Internal Server Error",
                _   => null
            };
        }
    }
}