namespace Northwind.Domain;

using System.ComponentModel.DataAnnotations;

public record Customer
{
  [Key]
  public required string Id { get; set; }
  public required string CompanyName { get; set; }
  public required string ContactName { get; set; } 
  public required string ContactTitle { get; set; } = string.Empty;
  public required string Phone { get; set; } = string.Empty;
  public string Fax { get; set; } = string.Empty;
}
