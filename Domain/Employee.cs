namespace Northwind.Domain;

public record Employee
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}
