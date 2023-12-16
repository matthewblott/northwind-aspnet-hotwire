namespace Northwind.Application.Orders.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Order ToDto(this Domain.Order? Order);
  public static partial Domain.Order FromDto(this Order Order);
  public static partial IList<Order> ProjectToDto(this IList<Domain.Order> q);
}
