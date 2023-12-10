namespace northwind_aspnet_hotwire.Application.Weather;

using Mediator;

public record Query(int Count = 5) : IQuery<IReadOnlyList<Weather>>;
