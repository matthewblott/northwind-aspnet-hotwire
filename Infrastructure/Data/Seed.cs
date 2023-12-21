namespace Northwind.Infrastructure.Data;

using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Domain;

public abstract class Seed
{
  public static void SeedData(NorthwindDbContext context)
  {
    var faker = new Faker();
      
    // Address
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Addresses.Add(new Address
      {
        AddressLine1 = faker.Address.StreetAddress(),
        AddressLine2 = faker.Address.SecondaryAddress(),
        PostalTown = faker.Address.City(),
        County = faker.Address.County(),
        Country = faker.Address.Country(),
        Name = faker.Name.FullName(),
        PostCode = faker.Address.ZipCode(),
      });
    }
    
    // Categories
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Categories.Add(new Category
      {
        Name = faker.Commerce.ProductName(),
        Description = faker.Commerce.ProductDescription(),
      });
    }
    
    // Customer
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
    
    // Products
    foreach (var _ in Enumerable.Range(1, 50))
    {
      context.Products.Add(new Product
      {
        Code = faker.Commerce.Product(),  
        Name = faker.Commerce.ProductName(),
        QuantityPerUnit = string.Empty,
      });
    }

    context.SaveChangesAsync();
    context.CommitAsync();
  }
}
