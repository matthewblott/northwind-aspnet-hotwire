namespace Northwind.WebUI.Features.Employees;

using Application.Employees.Shared.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Queries;
using Northwind.Application.Employees.Commands;
using Index = Application.Employees.Queries.Index;

public class EmployeesController(ISender mediator) : Controller
{
  public async Task<ViewResult> Index([FromQuery] Index.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }

  [Route("[controller]/{id:int}")]
  public async Task<ViewResult> Show(Show.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }
    
  public IActionResult New()
  {
    return View(new Employee());
  }
    
  [Route("[controller]/{id:int}/edit")]
  public async Task<IActionResult> Edit(Show.Query query)
  {
    var result = await mediator.Send(query);
    return View(result);
  }

  [HttpPost] 
  public async Task<IActionResult> Create(Create.Command command)
  {
    var result = await mediator.Send(command);
    var id = Convert.ToInt32(result.Model.Id);

    if (id >= 1)
    {
      return RedirectToAction(nameof(Show), new {id});
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
  public async Task<IActionResult> Update(Update.Command command)
  {
    var result = await mediator.Send(command);

    if (!result.Errors.Any())
    {
      return RedirectToAction(nameof(Show), new {id = Convert.ToInt32(result.Model.Id)});
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
  public async Task<IActionResult> Delete(Delete.Command command)
  {
    await mediator.Send(command);
    return RedirectToAction(nameof(Index));
  }
}
