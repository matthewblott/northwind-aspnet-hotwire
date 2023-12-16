namespace Northwind.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;

public interface INorthwindDbContext
{
  DbSet<Address> Addresses { get; set; }
  DbSet<Category> Categories { get; set; }
  DbSet<Customer> Customers { get; set; }
  DbSet<Employee> Employees { get; set; }
  DbSet<Order> Orders { get; set; }
  DbSet<OrderItem> OrderItems { get; set; }
  DbSet<Product> Products { get; set; } 
  DbSet<Region> Regions { get; set; }
  DbSet<Shipper> Shippers { get; set; }
  DbSet<Supplier> Suppliers { get; set; }
  Task CommitAsync(CancellationToken cancellationToken);
}
