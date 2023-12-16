namespace Northwind.Application.OrderItems.Shared.Validators;

using FluentValidation;

public class OrderItemValidator : AbstractValidator<Models.OrderItem>
{
  public OrderItemValidator()
  {
    RuleFor(x => x.Name).NotEmpty().Length(2, 50);
  }
}
