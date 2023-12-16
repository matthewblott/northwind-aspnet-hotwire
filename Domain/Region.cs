namespace Northwind.Domain;

public record Region
{
  public int Id { get; set; }
  public required string Name { get; set; }
}
