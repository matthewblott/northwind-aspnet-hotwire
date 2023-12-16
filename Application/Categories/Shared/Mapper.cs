namespace Northwind.Application.Categories.Shared;

using Models;
using Riok.Mapperly.Abstractions;
using X.PagedList;

[Mapper]
public static partial class Mapper
{
  public static partial Category ToDto(this Domain.Category? Category);
  public static partial Domain.Category FromDto(this Category Category);
  public static partial IList<Category> ProjectToDto(this IList<Domain.Category> q);
}
