namespace Poke.CloudSalesSystem.Products.Application.Constants;

public static class CacheExpirationTime
{
    //Product catalogs could easily be cached for more than hour
    public const int PRODUCT_EXPIRATION_IN_MINUTES = 60;
}
