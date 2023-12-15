namespace Northwind.Application.Employees.Shared.Validators;

using FluentValidation;

public class EmployeeValidator : AbstractValidator<Models.Employee>
{
  public EmployeeValidator()
  {
    RuleFor(x => x.Email).NotEmpty().Length(5, 50);
    RuleFor(x => x.FirstName).NotEmpty().Length(2, 50);
    RuleFor(x => x.LastName).NotEmpty().Length(2, 50);
  }
}
