namespace Northwind.Application.Suppliers.Queries;

using Common.Interfaces;
using Mediator;
using Shared.Models;
using X.PagedList;
using static Shared.Mapper;

public class Index
{
  public record Query : IQuery<IPagedList<Supplier>>
  {
    public int Page { get; set; } = 1;
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IPagedList<Supplier>>
  {
    public async ValueTask<IPagedList<Supplier>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var suppliers = await db.Suppliers.ToList().ProjectToDto().ToPagedListAsync(query.Page, 10, cancellationToken);
      return await ValueTask.FromResult(suppliers);
    }
  }
}
