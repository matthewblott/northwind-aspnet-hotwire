namespace Northwind.Application.Products.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Product>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Product>>
  {
    public async ValueTask<IPagedList<Product>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var products = await db.Products.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(products);
    }
  }
}
