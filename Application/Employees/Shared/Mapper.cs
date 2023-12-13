namespace Northwind.Application.Employees.Shared;

using Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class Mapper
{
  public static partial Employee ToDto(this Domain.Employee? employee);
  public static partial Domain.Employee FromDto(this Employee employee);
  public static partial IEnumerable<Domain.Employee> ProjectFromDto(this IQueryable<Employee> q);
  public static partial IEnumerable<Employee> ProjectToDto(this IQueryable<Domain.Employee> q);
} 
