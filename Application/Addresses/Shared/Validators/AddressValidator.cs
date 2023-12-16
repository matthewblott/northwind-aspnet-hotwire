namespace Northwind.Application.Addresses.Shared.Validators;

using FluentValidation;

public class AddressValidator : AbstractValidator<Models.Address>
{
  public AddressValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
