namespace Northwind.Infrastructure;

using Application.Common.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<NorthwindDbContext>(options => options
      .UseInMemoryDatabase("Northwind")
      // .UseSqlite(connectionString)
      .EnableSensitiveDataLogging()
      .LogTo(Console.WriteLine)
      .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
    services.AddScoped<INorthwindDbContext>(provider => provider.GetRequiredService<NorthwindDbContext>());
      
    return services;
  }
}
