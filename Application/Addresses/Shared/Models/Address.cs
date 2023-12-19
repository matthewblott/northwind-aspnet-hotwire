namespace Northwind.Application.Addresses.Shared.Models;

public record Address
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string AddressLine1 { get; set; }
  public string? AddressLine2 { get; set; }
  public string PostalTown { get; set; }
  public string County { get; set; }
  public string PostCode { get; set; }
  public string Country { get; set; }
}
