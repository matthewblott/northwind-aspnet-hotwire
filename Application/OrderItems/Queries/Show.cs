namespace Northwind.Application.OrderItems.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.OrderItem>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.OrderItem>
  {
    public async ValueTask<Shared.Models.OrderItem> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var order = await db.OrderItems.FindAsync(query.Id, cancellationToken);
      var orderDto = order.ToDto();
      var result = ValueTask.FromResult(orderDto);
      return await result;
    }
  }
}
