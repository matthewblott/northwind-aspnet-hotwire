namespace Northwind.Application.Addresses.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Update
{
  public sealed record Command : ICommand<(Address Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Address Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Address Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Address Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.AddressValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var address = command.Model.FromDto();

      db.Addresses.Update(address);

      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
