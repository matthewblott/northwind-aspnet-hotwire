namespace Northwind.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;

public interface INorthwindDbContext
{
  DbSet<Employee> Employees { get; set; }
  Task CommitAsync(CancellationToken cancellationToken);
}
