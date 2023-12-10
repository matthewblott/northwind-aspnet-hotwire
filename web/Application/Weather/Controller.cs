using Microsoft.AspNetCore.Mvc;

namespace northwind_aspnet_hotwire.Application.Weather;

using Mediator;

[ApiController]
[Route("[controller]")]
public class Controller(ISender mediator) : ControllerBase
{
  [Route("~/weather")] 
  public ValueTask<IReadOnlyList<Weather>> Bar([FromQuery] Query forecast) => mediator.Send(forecast);
}
