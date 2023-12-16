namespace Northwind.Application.Regions.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Region>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Region>>
  {
    public async ValueTask<IPagedList<Region>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var regions = await db.Regions.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(regions);
    }
  }
}
