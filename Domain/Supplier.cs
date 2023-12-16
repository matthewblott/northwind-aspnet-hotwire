namespace Northwind.Domain;

public record Supplier
{
  public int Id { get; set; }
  public required string Name { get; set; }
}
