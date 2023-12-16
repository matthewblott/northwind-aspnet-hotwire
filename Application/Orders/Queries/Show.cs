namespace Northwind.Application.Orders.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Order>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Order>
  {
    public async ValueTask<Shared.Models.Order> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var order = await db.Orders.FindAsync(query.Id, cancellationToken);
      var orderDto = order.ToDto();
      var result = ValueTask.FromResult(orderDto);
      return await result;
    }
  }
}
