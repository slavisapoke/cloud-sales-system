
namespace Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

public class CancelSubscriptionResponse
{
    public bool IsSuccess { get; init; }
    public string? Message { get; init; } 
    public DateTimeOffset? CancelledAt { get; init; }

    public static CancelSubscriptionResponse Success() =>
        new()
        {
            Message = "Subscription canceled successfully",
            CancelledAt = DateTime.Now,
            IsSuccess = true
        };

    public static CancelSubscriptionResponse Success(string message) =>
        new()
        {
            Message = message,
            CancelledAt = DateTime.Now,
            IsSuccess = true
        };

    public static CancelSubscriptionResponse Failure(string message) =>
        new ()
        {
            Message = message,
            IsSuccess = false
        };
}
