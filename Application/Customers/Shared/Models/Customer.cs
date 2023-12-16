namespace Northwind.Application.Customers.Shared.Models;

public record Customer
{
  public string Id { get; set; }
  public string CompanyName { get; set; } = string.Empty;
  public string ContactName { get; set; } = string.Empty;
  public string ContactTitle { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Fax { get; set; } = string.Empty;
}
