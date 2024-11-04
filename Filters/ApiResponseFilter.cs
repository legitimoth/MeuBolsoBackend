using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeuBolsoBackend;

public class ApiResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult && !IsApiResponseDto(objectResult.Value))
        {
            var apiResponse = new ApiResponseDto<object>(objectResult.Value, true);

            context.Result = new ObjectResult(apiResponse)
            {
                StatusCode = objectResult.StatusCode
            };
        }

        await next();
    }
    
    private bool IsApiResponseDto(object? value)
    {
        if (value == null) return false;
        var type = value.GetType();
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApiResponseDto<>);
    }
}
