namespace Northwind.Application.Employees.Queries;

using Domain;
using Mediator;

public record Query : IQuery<IReadOnlyList<Employee>>;
