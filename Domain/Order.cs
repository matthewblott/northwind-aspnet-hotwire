namespace Northwind.Domain;

public record Order
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public string CustomerId { get; set; }
  public int EmployeeId { get; set; }
  public int ShipperId { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime RequiredDate { get; set; }
  public DateTime? ShippedDate { get; set; }
  public int? ShipVia { get; set; }
  public decimal? Freight { get; set; }
}
