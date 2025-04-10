namespace Poke.CloudSalesSystem.Products.Application.Helpers;

/// <summary>
/// Cache key helper
/// </summary>
public static class CacheKeys
{
    public static string GetProducts(Guid providerId) =>
        $"products:{providerId}";
}
