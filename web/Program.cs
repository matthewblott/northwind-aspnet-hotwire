using aspnet_hotwire.Hubs;
using northwind_aspnet_hotwire.Services;

[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\{1}\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]
[assembly: JetBrains.Annotations.AspMvcPartialViewLocationFormat(@"~\Features\Shared\{0}.cshtml")]

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

ConfigureApplication(app);

app.Run();

static void RegisterServices(IHostApplicationBuilder builder)
{
  var services = builder.Services;
    
  services.AddControllersWithViews().AddFeatureFolders().AddRazorRuntimeCompilation();
  services.AddHttpContextAccessor();
  services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
  services.AddMediator();
  services.AddSignalR();
}

static void ConfigureApplication(WebApplication app)
{
  app.UseStaticFiles();
  app.UseRouting();
  app.UseAuthorization();
  app.UseEndpoints(endpoints =>
  {
    endpoints.MapControllers();
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
  });
      
  if (app.Environment.IsDevelopment())
  {
    app.UseSpa(spa =>
      spa.UseProxyToSpaDevelopmentServer("http://localhost:5173/"));
  }

  app.MapHub<AppHub>("/appHub");
    
}
