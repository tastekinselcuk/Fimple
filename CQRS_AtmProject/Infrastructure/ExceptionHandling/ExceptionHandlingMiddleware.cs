using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQRS_AtmProject.Infrastructure.ExceptionHandling
{
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext); // request'i devam ettir
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex); // exception fırlatılırsa yakala
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        // Özelleşmiş response için hata tipi ve mesajı kontrol et
        switch (exception)
        {
            case NotFoundException notFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return context.Response.WriteAsync(new ErrorResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = notFoundException.Message
                }.ToString());

            case ValidationException validationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return context.Response.WriteAsync(new ErrorResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = validationException.Message
                }.ToString());

            default:
                // Genel bir hata için (500 Internal Server Error)
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return context.Response.WriteAsync(new ErrorResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred. Please try again later."
                }.ToString());
        }
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this); // JSON formatında döndür
    }
}

}