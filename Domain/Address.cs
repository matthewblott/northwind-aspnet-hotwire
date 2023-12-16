namespace Northwind.Domain;

public record Address
{
  public int Id { get; set; }
  public required string Name { get; set; }
}
