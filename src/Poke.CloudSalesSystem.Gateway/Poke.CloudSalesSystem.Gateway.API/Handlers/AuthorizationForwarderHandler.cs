using Poke.CloudSalesSystem.Gateway.API.Authorization;
using Poke.CloudSalesSystem.Gateway.Application.Abstract.Services;

namespace Poke.CloudSalesSystem.Gateway.API.Handlers;

/// <summary>
/// Dummy authorization handler sending dummy authorization payload to downstream services
/// </summary>
/// <param name="userProvider"></param>
/// <param name="httpContextAccessor"></param>
public class AuthorizationForwarderHandler(
    ICurrentUserProvider userProvider,
    IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{ 
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var context = httpContextAccessor.HttpContext;

        var user = userProvider.GetCurrentUser();

        if (user.IsAuthenticated)
        {
            context?.Request.Headers.Remove(AuthConstants.AUTH_HEADER);
            context?.Request.Headers.Append(AuthConstants.AUTH_HEADER, user.CustomerId.ToString());
        }
         
        return await base.SendAsync(request, cancellationToken);
    }
}
