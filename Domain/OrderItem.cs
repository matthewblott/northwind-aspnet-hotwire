namespace Northwind.Domain;

public record OrderItem
{
  public int Id { get; set; }
  public required string Name { get; set; }
}
