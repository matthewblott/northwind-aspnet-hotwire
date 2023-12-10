namespace northwind_aspnet_hotwire.Application.Employees.Queries;

using Mediator;

public class QueryHandler : IQueryHandler<Query, IReadOnlyList<Employee>>
{
  public ValueTask<IReadOnlyList<Employee>> Handle(Query query,
    CancellationToken cancellationToken)
  {
    IReadOnlyList<Employee> employees = new List<Employee>
    {
      new()
      {
        Id = 1,
        FirstName = "John",
        LastName = "Wayne",
      },
      new()
      {
        Id  = 2,
        FirstName = "Gary",
        LastName = "Cooper",
      },
    };
      
    return ValueTask.FromResult(employees);
  }
}
