namespace Northwind.WebUI.Features.Employees;

using Mediator;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Employees.Queries;

public class EmployeesController(ISender mediator) : Controller
{
  public IActionResult Index([FromQuery] Query query)
  {
    var result = mediator.Send(query);
    var employees = result.Result;
      
    return View(employees);
  }

}
