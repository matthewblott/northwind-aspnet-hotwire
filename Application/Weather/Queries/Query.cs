namespace Northwind.Application.Weather.Queries;

using Domain;
using Mediator;

public record Query(int Count = 5) : IQuery<IReadOnlyList<Weather>>;
