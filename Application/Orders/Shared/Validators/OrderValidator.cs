namespace Northwind.Application.Orders.Shared.Validators;

using FluentValidation;

public class OrderValidator : AbstractValidator<Models.Order>
{
  public OrderValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
