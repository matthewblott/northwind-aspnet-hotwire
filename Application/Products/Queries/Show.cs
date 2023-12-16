namespace Northwind.Application.Products.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Product>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Product>
  {
    public async ValueTask<Shared.Models.Product> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var product = await db.Products.FindAsync(query.Id, cancellationToken);
      var productDto = product.ToDto();
      var result = ValueTask.FromResult(productDto);
      return await result;
    }
  }
}
