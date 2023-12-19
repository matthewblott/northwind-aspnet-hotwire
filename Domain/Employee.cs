namespace Northwind.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public record Employee
{
  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required string Email { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateOnly HireDate { get; set; }
  public int ReportsTo { get; set; }
  public string Title { get; set; } = string.Empty;
  public string TitleOfCourtesy { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
    
  public Employee LineManager { get; set; }
  public ICollection<Employee> Subordinates { get; private set; } = new HashSet<Employee>();
}
