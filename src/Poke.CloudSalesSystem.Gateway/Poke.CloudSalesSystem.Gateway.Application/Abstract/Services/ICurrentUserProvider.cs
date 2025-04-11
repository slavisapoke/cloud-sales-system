namespace Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

/// <summary>
/// Some authorization is required :)
/// </summary>
public interface ICurrentUserProvider
{
    UserContext GetCurrentUser();
}

public class UserContext
{
    public virtual bool IsAuthenticated => true;

    public UserContext(Guid customerId, string username)
    {
        CustomerId = customerId;
        Username = username;
    }

    public Guid CustomerId { get; init; }
    public string? Username { get; init; }
}

public class UnauthorizedUser : UserContext
{
    private static UnauthorizedUser _instance = new UnauthorizedUser();

    public override bool IsAuthenticated => false;

    private UnauthorizedUser() : base(Guid.Empty, string.Empty) { }

    public static UnauthorizedUser Instance => _instance;
}
