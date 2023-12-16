namespace Northwind.Application.Addresses.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Address ToDto(this Domain.Address? address);
  public static partial Domain.Address FromDto(this Address address);
  public static partial IList<Address> ProjectToDto(this IList<Domain.Address> q);
}
