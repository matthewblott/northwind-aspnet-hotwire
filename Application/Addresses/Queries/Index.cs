namespace Northwind.Application.Addresses.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Address>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Address>>
  {
    public async ValueTask<IPagedList<Address>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var addresses = await db.Addresses.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(addresses);
    }
  }
}
