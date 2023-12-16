namespace Northwind.Application.Regions.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Region ToDto(this Domain.Region? Region);
  public static partial Domain.Region FromDto(this Region Region);
  public static partial IList<Region> ProjectToDto(this IList<Domain.Region> q);
} 
