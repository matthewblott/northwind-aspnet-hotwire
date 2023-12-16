namespace Northwind.Application.Suppliers.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Update
{
  public sealed record Command : ICommand<(Supplier Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Supplier Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Supplier Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Supplier Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.SupplierValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var supplier = command.Model.FromDto();

      db.Suppliers.Update(supplier);

      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
