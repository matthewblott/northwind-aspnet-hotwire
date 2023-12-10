namespace northwind_aspnet_hotwire.Application.Weather;

public class Weather
{
  public DateTime Date { get; set; }
  public int TemperatureC { get; set; }
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
  public string? Summary { get; set; }
}