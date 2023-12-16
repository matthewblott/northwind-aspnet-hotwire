namespace Northwind.Application.Customers.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Customer ToDto(this Domain.Customer? Customer);
  public static partial Domain.Customer FromDto(this Customer Customer);
  public static partial IList<Customer> ProjectToDto(this IList<Domain.Customer> q);
} 
