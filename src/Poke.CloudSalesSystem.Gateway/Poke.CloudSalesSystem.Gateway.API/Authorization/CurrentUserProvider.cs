using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.API.Authorization;


/// <summary>
/// Some kind of authorization whatever we agree...
/// </summary>
public class CurrentUserProvider (IHttpContextAccessor httpAccessor): ICurrentUserProvider
{
    public UserContext GetCurrentUser()
    {
        var customerId = httpAccessor.HttpContext?.Request.Headers[AuthConstants.AUTH_HEADER];

        if (!Guid.TryParse(customerId, out Guid customerGuid))
        {
            return UnauthorizedUser.Instance;
        }

        return new UserContext(customerGuid, "customer@precednik.rs");
    }
}


public static class AuthConstants
{
    public const string AUTH_HEADER = "KIND_OF_AUTHORIZATION";
}