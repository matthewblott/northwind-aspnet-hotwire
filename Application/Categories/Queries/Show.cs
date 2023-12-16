namespace Northwind.Application.Categories.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Category>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Category>
  {
    public async ValueTask<Shared.Models.Category> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var category = await db.Categories.FindAsync(query.Id, cancellationToken);
      var categoryDto = category.ToDto();
      var result = ValueTask.FromResult(categoryDto);
      return await result;
    }
  }
}
