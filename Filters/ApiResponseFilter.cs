using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeuBolsoBackend;

public class ApiResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value is not ApiResponse<object>)
        {
            var apiResponse = new ApiResponse<object>(objectResult.Value, true);

            context.Result = new ObjectResult(apiResponse)
            {
                StatusCode = objectResult.StatusCode
            };
        }

        await next();
    }
}
