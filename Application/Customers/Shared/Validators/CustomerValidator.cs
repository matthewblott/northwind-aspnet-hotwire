namespace Northwind.Application.Customers.Shared.Validators;

using FluentValidation;

public class CustomerValidator : AbstractValidator<Models.Customer>
{
  public CustomerValidator()
  {
    RuleFor(x => x.Id).NotEmpty().Length(2, 50);
    RuleFor(x => x.CompanyName).NotEmpty().Length(2, 50);
    RuleFor(x => x.ContactName).NotEmpty().Length(2, 50);
  }
}
