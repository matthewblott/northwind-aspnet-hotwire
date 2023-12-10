namespace northwind_aspnet_hotwire.Application.Employees.Queries;
  
using Mediator;

public record Query : IQuery<IReadOnlyList<Employee>>;
