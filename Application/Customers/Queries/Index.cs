namespace Northwind.Application.Customers.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Customer>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Customer>>
  {
    public async ValueTask<IPagedList<Customer>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var customers = await db.Customers.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(customers);
    }
  }
}
