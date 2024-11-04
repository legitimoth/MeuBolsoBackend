namespace MeuBolsoBackend;

public class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        await next(httpContext);

        if (httpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            await HandleUnauthorizedAsync(httpContext);
        }
        else if (httpContext.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            await HandleForbiddenAsync(httpContext);
        }
    }

    private static Task HandleUnauthorizedAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var response = ApiResponseDto<string>.FailureResponse(Message.UsuarioNaoAutenticado);
        return context.Response.WriteAsJsonAsync(response);
    }

    private static Task HandleForbiddenAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var response = ApiResponseDto<string>.FailureResponse(Message.UsuarioSemPermissao);
        return context.Response.WriteAsJsonAsync(response);
    }
}
