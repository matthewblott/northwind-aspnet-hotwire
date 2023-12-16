namespace Northwind.Application.Customers.Queries;

using Common.Interfaces;
using Mediator;
using Shared;

public class Show
{
  public record Query : IQuery<Shared.Models.Customer>
  {
    public string Id { get; set; }
  }

  public class Handler(INorthwindDbContext db) : IQueryHandler<Query, Shared.Models.Customer>
  {
    public async ValueTask<Shared.Models.Customer> Handle(Query query,
      CancellationToken cancellationToken)
    {
      var customer = await db.Customers.FindAsync(query.Id, cancellationToken);
      var customerDto = customer.ToDto();
      var result = ValueTask.FromResult(customerDto);
      return await result;
    }
  }
}
