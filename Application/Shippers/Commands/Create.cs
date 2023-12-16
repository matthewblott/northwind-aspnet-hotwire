namespace Northwind.Application.Shippers.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<(Shipper Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Shipper Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Shipper Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Shipper Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.ShipperValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var shipper = command.Model.FromDto();

      db.Shippers.Add(shipper);

      db.CommitAsync(cancellationToken);
      command.Model.Id = shipper.Id;
      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
