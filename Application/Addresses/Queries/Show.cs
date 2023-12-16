namespace Northwind.Application.Addresses.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Address>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Address>
  {
    public async ValueTask<Shared.Models.Address> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var address = await db.Addresses.FindAsync(query.Id, cancellationToken);
      var addressDto = address.ToDto();
      var result = ValueTask.FromResult(addressDto);
      return await result;
    }
  }
}
