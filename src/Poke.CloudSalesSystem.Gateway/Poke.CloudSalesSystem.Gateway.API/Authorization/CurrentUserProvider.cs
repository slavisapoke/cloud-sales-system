using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.API.Authorization;

/// <summary>
/// Some kind of authorization whatever we agree...
/// </summary>
public class CurrentUserProvider (IHttpContextAccessor httpAccessor): ICurrentUserProvider
{
    public UserContext GetCurrentUser()
    {
        var customerId = httpAccessor.HttpContext?.Request.Headers["KIND_OF_AUTHORIZATION"];

        if (!Guid.TryParse(customerId, out Guid customerGuid))
        {
            throw new UnauthorizedAccessException("Missing header KIND_OF_AUTHORIZATION");
        }

        return new UserContext(customerGuid, "customer@precednik.rs");
    }
}
