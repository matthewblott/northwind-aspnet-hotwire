using Microsoft.AspNetCore.Mvc;

namespace northwind_aspnet_hotwire.Features.Home;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
