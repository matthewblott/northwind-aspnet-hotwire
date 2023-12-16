namespace Northwind.Application.OrderItems.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial OrderItem ToDto(this Domain.OrderItem? OrderItem);
  public static partial Domain.OrderItem FromDto(this OrderItem OrderItem);
  public static partial IList<OrderItem> ProjectToDto(this IList<Domain.OrderItem> q);
}
