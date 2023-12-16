namespace Northwind.Application.Suppliers.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Supplier>
  {
    public int Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Supplier>
  {
    public async ValueTask<Shared.Models.Supplier> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var supplier = await db.Suppliers.FindAsync(query.Id, cancellationToken);
      var supplierDto = supplier.ToDto();
      var result = ValueTask.FromResult(supplierDto);
      return await result;
    }
  }
}
