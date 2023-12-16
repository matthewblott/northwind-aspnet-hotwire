namespace Northwind.Application.Regions.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Update
{
  public sealed record Command : ICommand<(Region Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Region Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Region Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Region Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.RegionValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var region = command.Model.FromDto();

      db.Regions.Update(region);

      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
