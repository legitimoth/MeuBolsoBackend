using System.Net.Mime;

namespace MeuBolsoBackend;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;

        int statusCode;
        string message;

        switch (exception)
        {
            case BusinessException:
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
                break;
            case NotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
                break;
            case ConflictException:
                statusCode = StatusCodes.Status409Conflict;
                message = exception.Message;
                break;
            case ClaimNotFoundException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = exception.Message;
                break;
            case FormatException:
                statusCode = StatusCodes.Status500InternalServerError;
                message = exception.Message;
                break;
            default:
                _logger.LogError(exception, "Ocorreu um erro inesperado.");
                statusCode = StatusCodes.Status500InternalServerError;
                message = Message.ErroInesperado;
                break;
        }

        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsJsonAsync(ApiResponseDto<string>.FailureResponse(message));
    }
}
