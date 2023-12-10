using Microsoft.AspNetCore.Mvc;
using Mediator;

namespace northwind_aspnet_hotwire.Features.Employees;

using Application.Employees.Queries;

public class EmployeesController(ISender mediator) : Controller
{
  public IActionResult Index([FromQuery] Query query)
  {
    var result = mediator.Send(query);
    var employees = result.Result;
      
    return View(employees);
  }

}
