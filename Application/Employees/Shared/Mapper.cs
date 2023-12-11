namespace Northwind.Application.Employees.Shared;

using Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class Mapper
{
  public static partial Employee ToDto(this Domain.Employee employee);
  public static partial Domain.Employee FromDto(this Employee employee);
} 
