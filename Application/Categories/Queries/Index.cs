namespace Northwind.Application.Categories.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Category>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Category>>
  {
    public async ValueTask<IPagedList<Category>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var categories = await db.Categories.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(categories);
    }
  }
}
