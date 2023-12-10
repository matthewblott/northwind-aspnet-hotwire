namespace northwind_aspnet_hotwire.Application.Weather;

using Mediator;

public class QueryHandler : IQueryHandler<Query, IReadOnlyList<Weather>>
{
  private static readonly string[] _summaries =
  {
    "Freezing",
    "Bracing",
    "Chilly",
    "Cool",
    "Mild",
    "Warm",
    "Balmy",
    "Hot",
    "Sweltering",
    "Scorching"
  };
    
  public ValueTask<IReadOnlyList<Weather>> Handle(Query query,
    CancellationToken cancellationToken)
  {
      
    IReadOnlyList<Weather> result = Enumerable
      .Range(1, query.Count)
      .Select(
        index =>
          new Weather
          {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
          }
      )
      .ToArray();

    return ValueTask.FromResult(result);
  }
}
