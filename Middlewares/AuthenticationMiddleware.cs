namespace MeuBolsoBackend;

public class AuthenticationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);

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
        var response = ApiResponse<string>.FailureResponse(Message.UsuarioNaoAutenticado);
        return context.Response.WriteAsJsonAsync(response);
    }

    private static Task HandleForbiddenAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var response = ApiResponse<string>.FailureResponse(Message.UsuarioSemPermissao);
        return context.Response.WriteAsJsonAsync(response);
    }
}
