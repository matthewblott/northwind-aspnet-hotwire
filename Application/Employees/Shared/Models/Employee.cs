namespace Northwind.Application.Employees.Shared.Models;

public record Employee
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateOnly HireDate { get; set; }
  public string Title { get; set; }
}
