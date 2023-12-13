namespace Northwind.Application.Employees.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IReadOnlyList<Employee>>;

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IReadOnlyList<Employee>>
  {
    public ValueTask<IReadOnlyList<Employee>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      IReadOnlyList<Employee> employees = db.Employees.ProjectToDto().ToList();
      return ValueTask.FromResult(employees);
    }
  }
}
