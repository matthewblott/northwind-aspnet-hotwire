namespace Northwind.Application.Categories.Shared.Validators;

using FluentValidation;

public class CategoryValidator : AbstractValidator<Models.Category>
{
  public CategoryValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
