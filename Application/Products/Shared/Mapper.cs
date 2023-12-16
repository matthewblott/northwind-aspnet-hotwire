namespace Northwind.Application.Products.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Product ToDto(this Domain.Product? Product);
  public static partial Domain.Product FromDto(this Product Product);
  public static partial IList<Product> ProjectToDto(this IList<Domain.Product> q);
}
