using System.Net;
using System.Text.Json;
using CarWorkshopAPI.Commands.Register;
using Microsoft.VisualBasic.CompilerServices;

namespace CarWorkshopAPI.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate _next, ILogger<ExceptionHandlingMiddleware> _logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            await HandleException(context, ex);
        }
    }

    public static Task HandleException(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        object responseBody;
        string message;

        switch (exception)
        {
            case FluentValidation.ValidationException valEx:
                statusCode = HttpStatusCode.BadRequest;
                responseBody = new
                {
                    message = "Validation failed",
                    status = (int)statusCode,
                    errors = valEx.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray())
                };
                break;
            case InvalidOperationException:
                statusCode = HttpStatusCode.Conflict; //409
                message = exception.Message;
                responseBody = new {error = message, status = (int)statusCode};
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized; //401
                message = "Unauthorized";
                responseBody = new {error = message, status = (int)statusCode};
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound; //404
                message = exception.Message;
                responseBody = new {error = message, status = (int)statusCode};
                break;
            default:
                statusCode = HttpStatusCode.InternalServerError; //500
                message = "An unexpected error";
                responseBody = new {error = message, status = (int)statusCode};
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(responseBody));
    }
}