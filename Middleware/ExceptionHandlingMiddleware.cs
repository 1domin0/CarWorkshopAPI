using System.Net;
using System.Text.Json;
using CarWorkshopAPI.Commands.Register;

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
            _logger.LogError(ex, ex.Message);
            await HandleException(context, ex);
        }
    }

    public static Task HandleException(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string message;

        switch (exception)
        {
            case InvalidOperationException:
                statusCode = HttpStatusCode.Conflict; //409
                message = exception.Message;
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                message = "Unauthorized";
                break;
            
            default:
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var response = new
        {
            error = message,
            status = (int)statusCode
        };
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}