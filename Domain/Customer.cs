namespace Northwind.Domain;

public class Customer
{
  public int Id { get; set; }
  public required string CompanyName { get; set; }
  public required string ContactName { get; set; }
  public required string ContactTitle { get; set; }
  public string Region { get; set; } = string.Empty;
  public required string Phone { get; set; }
  public string Fax { get; set; } = string.Empty;
}
