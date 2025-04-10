
namespace Poke.CloudSalesSystem.Products.Application.Model;
public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProviderId { get; set; }
}
