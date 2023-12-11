namespace Northwind.Application.Weather.Queries;

// Riok.Mapperly.Abstractions;

using Domain;
using Mediator;

public record Query(int Count = 5) : IQuery<IReadOnlyList<Weather>>;
 
