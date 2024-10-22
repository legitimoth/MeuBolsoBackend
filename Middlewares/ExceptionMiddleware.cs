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

        string message;

        switch (exception)
        {
            case BusinessException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
                break;
            case NotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
                break;
            case ConflictException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                message = exception.Message;
                break;
            case ClaimNotFoundException:
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                message = exception.Message;
                break;
            case FormatException:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                message = exception.Message;
                break;
            case SettingsException:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                message = exception.Message;
                break;
            case HttpRequestException:
                message = exception.Message;
                context.Response.StatusCode = context.Response.StatusCode == StatusCodes.Status200OK ?
                    StatusCodes.Status503ServiceUnavailable :
                    context.Response.StatusCode;
                break;
            default:
                _logger.LogError(exception, Message.ErroInesperado);
                message = Message.ErroInesperado;
                break;
        }

        return context.Response.WriteAsJsonAsync(ApiResponseDto<string>.FailureResponse(message));
    }
}
