namespace Northwind.Infrastructure.Data;

using Domain;

public abstract class Seed
{
  public static void SeedData(NorthwindDbContext context)
  {
    context.Employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Wayne", });
    context.Employees.Add(new Employee { Id = 2, FirstName = "Gary", LastName = "Cooper", });
    context.Employees.Add(new Employee { Id = 3, FirstName = "Julie", LastName = "Andrews", });
    context.Employees.Add(new Employee { Id = 4, FirstName = "Marilyn", LastName = "Monroe", });
    context.CommitAsync();
  }
}
