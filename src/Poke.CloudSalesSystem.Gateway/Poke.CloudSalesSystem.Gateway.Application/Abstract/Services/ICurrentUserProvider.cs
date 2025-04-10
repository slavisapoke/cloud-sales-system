namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

/// <summary>
/// Some authorization is required :)
/// </summary>
public interface ICurrentUserProvider
{
    UserContext GetCurrentUser();
}

public record UserContext(Guid CustomerId, string Username);
