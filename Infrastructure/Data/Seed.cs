namespace Northwind.Infrastructure.Data;

using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Domain;

public abstract class Seed
{
  public static void SeedData(NorthwindDbContext context)
  {
    var faker = new Faker();

    //Customer
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Customers.Add(new Customer
      {
        Id = Guid.NewGuid().ToString(),   
        CompanyName = faker.Company.CompanyName(),
        ContactName = faker.Name.FullName(),
        ContactTitle = faker.Name.JobTitle(),
        Phone = faker.Phone.PhoneNumber(),
      });
    }

    // Employees
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Employees.Add(new Employee
      {
        Email = faker.Internet.Email(),
        BirthDate = DateOnly.FromDateTime(faker.Person.DateOfBirth),
        HireDate = DateOnly.FromDateTime(faker.Date.Past()),
        Title = faker.Name.JobTitle(),
        FirstName = faker.Name.FirstName(),
        LastName = faker.Name.LastName(),
      });
    }

    // Regions 
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Regions.Add(new Region
      {
        Name = faker.Address.CountryOfUnitedKingdom(),
      });
    }
    context.CommitAsync();
  }
}
