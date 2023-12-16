namespace Northwind.Domain;

public record Category
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
    
  public ICollection<Product> Products { get; private set; } = new HashSet<Product>();
}
