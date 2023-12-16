namespace Northwind.Application.Suppliers.Shared.Validators;

using FluentValidation;

public class SupplierValidator : AbstractValidator<Models.Supplier>
{
  public SupplierValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
