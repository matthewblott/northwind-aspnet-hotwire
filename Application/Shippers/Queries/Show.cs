namespace Northwind.Application.Shippers.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Shipper>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Shipper>
  {
    public async ValueTask<Shared.Models.Shipper> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var shipper = await db.Shippers.FindAsync(query.Id, cancellationToken);
      var shipperDto = shipper.ToDto();
      var result = ValueTask.FromResult(shipperDto);
      return await result;
    }
  }
}
