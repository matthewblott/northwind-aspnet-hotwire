namespace Northwind.Application.Orders.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<(Order Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Order Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Order Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Order Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.OrderValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var order = command.Model.FromDto();

      db.Orders.Add(order);

      db.CommitAsync(cancellationToken);
      command.Model.Id = order.Id;
      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
