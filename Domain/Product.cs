namespace Northwind.Domain;

public record Product
{
  public int Id { get; set; }
  public required string Name { get; set; }
}
