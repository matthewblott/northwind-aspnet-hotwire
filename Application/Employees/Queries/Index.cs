namespace Northwind.Application.Employees.Queries;

using Common.Interfaces;
using Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class Mapper
{
  public static partial Index.Model To(this Employee model);
} 

public class Index
{
  public record Query : IQuery<IReadOnlyList<Model>>;

  public record Model
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, IReadOnlyList<Model>>
  {
    public ValueTask<IReadOnlyList<Model>> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var employees = db.Employees.ToList();
      var models = new List<Model>();

      employees.ForEach(emp => models.Add(emp.To()));

      IReadOnlyList<Model> list = models.ToList();
      
      return ValueTask.FromResult(list);
    }
  }
}
