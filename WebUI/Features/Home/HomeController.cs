namespace Northwind.WebUI.Features.Home;

using Microsoft.AspNetCore.Mvc;

public class Foo
{
  public string Name { get; set; }
}

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
  
    
  public IActionResult Foo()
  {
    return View("Foo");
  }
  
  [HttpPost]  
  public IActionResult Foo(Foo foo)
  {
    foo.Name += "bar";
    return View(foo);
  }
    
}
