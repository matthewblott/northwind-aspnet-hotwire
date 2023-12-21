namespace Northwind.Application.Categories.Queries;

using Common.Interfaces;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Models;

public class Search
{
  public record Query : IQuery<IReadOnlyList<Category>>
  {
    public string Q { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IReadOnlyList<Category>>
  {
    public async ValueTask<IReadOnlyList<Category>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var categories = db.Categories
        .Where(x => x.Name.Contains(query.Q) || x.Description.Contains(query.Q));

      var categoriesAsList = categories?.ToList();
        
      var dtoCategories = categoriesAsList?.ProjectToDto().ToList();

      IReadOnlyList<Category> result = dtoCategories ?? [];
        
      return await ValueTask.FromResult(result);
    }
  }
  
}
