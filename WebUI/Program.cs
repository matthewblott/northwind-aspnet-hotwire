using FluentValidation;
using Northwind.Application.Employees.Shared.Models;
using Northwind.Application.Employees.Shared.Validators;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Data;
using Northwind.WebUI.Hubs;
using Northwind.WebUI.Services;

[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\{1}\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcPartialViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

ConfigureApplication(app);

Seed(app);

app.Run();

return;

static void RegisterServices(IHostApplicationBuilder builder)
{
  var services = builder.Services;
  var connectionString = $"Data Source={Path.Combine(builder.Environment.ContentRootPath, "Storage", "northwind.sqlite3")}";
    
  services.AddInfrastructure(connectionString);
  services.AddControllersWithViews().AddFeatureFolders().AddRazorRuntimeCompilation();
  services.AddHttpContextAccessor();
  services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
  services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
  services.AddSignalR();
}

static void Seed(IHost app)
{
  using var scope = app.Services.CreateScope();
  var dataContext = scope.ServiceProvider.GetRequiredService<NorthwindDbContext>();
  Northwind.Infrastructure.Data.Seed.SeedData(dataContext);
}

static void ConfigureApplication(WebApplication app)
{
  app.UseStaticFiles();
  app.UseRouting();
  app.UseAuthorization();
#pragma warning disable ASP0014
  app.UseEndpoints(endpoints =>
  {
    endpoints.MapControllers();
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
  });
#pragma warning restore ASP0014
      
  if (app.Environment.IsDevelopment())
  {
    app.UseSpa(spa =>
      spa.UseProxyToSpaDevelopmentServer("http://localhost:5173/"));
  }

  app.MapHub<AppHub>("/appHub");
    
}
