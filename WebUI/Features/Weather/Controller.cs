using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Features.Weather;

using Application.Weather.Queries;
using Mediator;
using Northwind.Domain;

[ApiController]
[Route("[controller]")]
public class Controller(ISender mediator) : ControllerBase
{
  [Route("~/weather")] 
  public ValueTask<IReadOnlyList<Weather>> Bar([FromQuery] Query forecast) => mediator.Send(forecast);
}
