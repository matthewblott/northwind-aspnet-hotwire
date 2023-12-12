namespace Northwind.WebUI.Features.Employees;

using Mediator;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Queries;
using Northwind.Application.Employees.Commands;

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
    return View();
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
    var id = Convert.ToInt32(result);
      
    return RedirectToAction(nameof(Show), new { id } );
  }
    
  [HttpPost]
  public async Task<IActionResult> Update(Update.Command command)
  {
    var result = await mediator.Send(command);
     
    return View("Edit", result);
  }
  
}
