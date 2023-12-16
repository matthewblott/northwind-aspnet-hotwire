namespace Northwind.Application.Regions.Shared.Validators;

using FluentValidation;

public class RegionValidator : AbstractValidator<Models.Region>
{
  public RegionValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
