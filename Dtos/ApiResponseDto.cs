namespace MeuBolsoBackend;

public class ApiResponseDto<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public ApiResponseDto(T? data, bool success)
    {
        Data = data;
        Success = success;
    }

    public ApiResponseDto(List<string> errors)
    {
        Success = false;
        Errors = errors;
    }

    public static ApiResponseDto<T> SuccessResponse(T data)
    {
        return new ApiResponseDto<T>(data, true);
    }

    public static ApiResponseDto<T> FailureResponse(List<string> errors)
    {
        return new ApiResponseDto<T>(errors);
    }

    public static ApiResponseDto<T> FailureResponse(string error)
    {
        return new ApiResponseDto<T>([error]);
    }
}
