namespace Northwind.Application.Shippers.Shared.Validators;

using FluentValidation;

public class ShipperValidator : AbstractValidator<Models.Shipper>
{
  public ShipperValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
