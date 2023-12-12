namespace Northwind.Application.Employees.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Employee>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Employee>
  {
    public async ValueTask<Shared.Models.Employee> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var employee = await db.Employees.FindAsync(query.Id, cancellationToken);
      var employeeDto = employee.ToDto();
      var result = ValueTask.FromResult(employeeDto);
      return await result;
    }
  }
}
