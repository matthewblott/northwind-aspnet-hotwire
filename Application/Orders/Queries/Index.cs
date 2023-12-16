namespace Northwind.Application.Orders.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Order>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Order>>
  {
    public async ValueTask<IPagedList<Order>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var orders = await db.Orders.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(orders);
    }
  }
}
