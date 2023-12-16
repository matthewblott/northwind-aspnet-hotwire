namespace Northwind.Domain;

public record Shipper
{
  public int Id { get; set; }
  public required string Name { get; set; }
}

