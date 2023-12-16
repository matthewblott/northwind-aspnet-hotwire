namespace Northwind.Application.Orders.Shared.Models;

public record Order
{
  public int Id { get; set; }
  public string Name { get; set; }
}
