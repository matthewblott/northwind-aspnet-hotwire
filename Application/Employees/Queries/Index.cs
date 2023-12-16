namespace Northwind.Application.Employees.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Employee>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Employee>>
  {
    public async ValueTask<IPagedList<Employee>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var employees = await db.Employees.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(employees);
    }
  }
}
