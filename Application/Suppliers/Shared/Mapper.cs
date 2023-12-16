namespace Northwind.Application.Suppliers.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Supplier ToDto(this Domain.Supplier? Supplier);
  public static partial Domain.Supplier FromDto(this Supplier Supplier);
  public static partial IList<Supplier> ProjectToDto(this IList<Domain.Supplier> q);
}
