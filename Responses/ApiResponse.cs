namespace MeuBolsoBackend;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public ApiResponse(T? data, bool success)
    {
        Data = data;
        Success = success;
    }

    public ApiResponse(List<string> errors)
    {
        Success = false;
        Errors = errors;
    }

    public static ApiResponse<T> SuccessResponse(T data)
    {
        return new ApiResponse<T>(data, true);
    }

    public static ApiResponse<T> FailureResponse(List<string> errors)
    {
        return new ApiResponse<T>(errors);
    }

    public static ApiResponse<T> FailureResponse(string error)
    {
        return new ApiResponse<T>([error]);
    }
}
