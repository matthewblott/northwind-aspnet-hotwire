namespace Northwind.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Application.Common.Interfaces;
using Domain;

public class NorthwindDbContext : DbContext, INorthwindDbContext, IDbContextTransaction
{
  public DbSet<Address> Addresses { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Employee> Employees { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Product> Products { get; set; } 
  public DbSet<Region> Regions { get; set; }
  public DbSet<Shipper> Shippers { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  private IDbContextTransaction? _currentTransaction;

  public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options) { }

  public void Commit()
  {
    CommitAsync();
  }

  public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    try
    {
      SaveChangesAsync(cancellationToken).ConfigureAwait(false);

      if (_currentTransaction != null)
      {
        _currentTransaction!.CommitAsync(cancellationToken);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      Rollback();
      throw;
    }
    finally
    {
      if (_currentTransaction != null)
      {
        _currentTransaction.Dispose();
        _currentTransaction = null;
      }
    }

    return Task.CompletedTask;
  }

  public void Rollback()
  {
    RollbackAsync();
  }

  public Task RollbackAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    try
    {
      _currentTransaction?.RollbackAsync(cancellationToken);
    }
    finally
    {
      if (_currentTransaction != null)
      {
        _currentTransaction.Dispose();
        _currentTransaction = null;
      }

    }

    return Task.CompletedTask;
  }

  public Guid TransactionId { get; }
}
