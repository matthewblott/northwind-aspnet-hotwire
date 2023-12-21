namespace Northwind.Application.Products.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Product ToDto(this Domain.Product? product);
  public static partial Domain.Product FromDto(this Product product);
  public static partial IEnumerable<Product> ProjectToDto(this IList<Domain.Product> q);
}
