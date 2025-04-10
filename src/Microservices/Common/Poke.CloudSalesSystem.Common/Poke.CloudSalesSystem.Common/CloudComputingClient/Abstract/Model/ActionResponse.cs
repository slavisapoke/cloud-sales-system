
namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

public class ActionResponse
{
    public bool IsSuccess { get; init; }
    public string? Message { get; init; } 
    public DateTimeOffset? CancelledAt { get; init; }

    public static ActionResponse Success(string message) =>
        new()
        {
            Message = message,
            CancelledAt = DateTime.Now,
            IsSuccess = true
        };

    public static ActionResponse Failure(string message) =>
        new ()
        {
            Message = message,
            IsSuccess = false
        };
}
