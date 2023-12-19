namespace Northwind.Domain;

public record Address
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string AddressLine1 { get; set; }
  public string AddressLine2 { get; set; } = string.Empty;
  public required string PostalTown { get; set; } = string.Empty;
  public required string County { get; set; } = string.Empty;
  public required string PostCode { get; set; } = string.Empty;
  public required string Country { get; set; } = string.Empty;
}
