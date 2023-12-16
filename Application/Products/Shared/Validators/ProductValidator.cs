namespace Northwind.Application.Products.Shared.Validators;

using FluentValidation;

public class ProductValidator : AbstractValidator<Models.Product>
{
  public ProductValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
