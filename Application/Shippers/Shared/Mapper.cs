namespace Northwind.Application.Shippers.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Shipper ToDto(this Domain.Shipper? Shipper);
  public static partial Domain.Shipper FromDto(this Shipper Shipper);
  public static partial IList<Shipper> ProjectToDto(this IList<Domain.Shipper> q);
}
