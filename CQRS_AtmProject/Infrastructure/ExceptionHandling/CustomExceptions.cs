using System;

namespace CQRS_AtmProject.Infrastructure.ExceptionHandling
{
    // Base custom exception class
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string? ErrorCode { get; set; }

        public CustomException(string message, int statusCode = 500, string? errorCode = null) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }

    // Specific exception for not found
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) : base(message, 404, "NotFound")
        {
        }
    }

    // Specific exception for validation errors
    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message, 400, "ValidationError")
        {
        }
    }

    // Specific exception for unauthorized access
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException(string message) : base(message, 401, "Unauthorized")
        {
        }
    }
}
