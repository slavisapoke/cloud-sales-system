namespace Poke.CloudSalesSystem.Common.Contracts;

public class ApiResponse<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public int ErrorCode { get; set; }
    public IReadOnlyCollection<string> Errors { get; set; } = [];

    public static ApiResponse<T> Success(T value) =>
        new()
        {
            IsSuccess = true,
            Value = value
        };

    public static ApiResponse<T> Fail(List<string> errors) =>
        new()
        {
            Errors = errors
        };
}
