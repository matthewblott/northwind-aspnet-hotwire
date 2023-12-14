namespace Northwind.Application.Employees.Shared.Validators;

using FluentValidation;

public class EmployeeValidator : AbstractValidator<Models.Employee>
{
  public EmployeeValidator()
  {
    RuleFor(x => x.FirstName).Length(2, 20);
    RuleFor(x => x.LastName).Length(2, 20);
  }
}
