using Microsoft.AspNetCore.Mvc;

namespace northwind_aspnet_hotwire.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

}
