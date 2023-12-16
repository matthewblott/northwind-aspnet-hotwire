namespace Northwind.WebUI.Features.Customers;

using Application.Customers.Shared.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Customers.Queries;
using Northwind.Application.Customers.Commands;
using Index = Application.Customers.Queries.Index;

public class CustomersController(ISender mediator) : Controller
{
  public async Task<ViewResult> Index([FromQuery] Index.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }

  [Route("[controller]/{id}")]
  public async Task<ViewResult> Show(Show.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }
  
  [Route($"[controller]/{nameof(New)}")]
  public IActionResult New()
  {
    return View(new Customer());
  }

  [Route("[controller]/{id}/" + nameof(Edit))]
  public async Task<IActionResult> Edit(Show.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }

  [HttpPost]
  [Route($"[controller]/{nameof(Create)}")]
  public async Task<IActionResult> Create(Create.Command command)
  {
    var result = await mediator.Send(command);
    var id = result.Model.Id;

    if (!result.Errors.Any())
    {
      return RedirectToAction(nameof(Show), new { id });
    }

    foreach (var error in result.Errors)
    {
      ModelState.Remove(error.PropertyName);
      ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
    }
    
    HttpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
    return View("New", result.Model);
  }

  [HttpPost]
  [Route($"[controller]/{nameof(Update)}")]
  public async Task<IActionResult> Update(Update.Command command)
  {
    var result = await mediator.Send(command);
    var id = command.Model.Id;
    
    if (!result.Errors.Any())
    {
      return RedirectToAction(nameof(Show), new { id });
    }

    foreach (var error in result.Errors)
    {
      ModelState.Remove(error.PropertyName);
      ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
    }

    HttpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
    return View("Edit", result.Model);
  }

  [HttpPost]
  [Route($"[controller]/{nameof(Delete)}")]
  public async Task<IActionResult> Delete(Delete.Command command)
  {
    await mediator.Send(command);
    return RedirectToAction(nameof(Index));
  }
}
