namespace Northwind.Application.Regions.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Region>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Region>
  {
    public async ValueTask<Shared.Models.Region> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var region = await db.Regions.FindAsync(query.Id, cancellationToken);
      var regionDto = region.ToDto();
      var result = ValueTask.FromResult(regionDto);
      return await result;
    }
  }
}
