namespace Northwind.Application.Shippers.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Shipper>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Shipper>>
  {
    public async ValueTask<IPagedList<Shipper>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var shippers = await db.Shippers.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(shippers);
    }
  }
}
