namespace Northwind.Application.Categories.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<(Category Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Category Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Category Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Category Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.CategoryValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var category = command.Model.FromDto();

      db.Categories.Add(category);

      db.CommitAsync(cancellationToken);
      command.Model.Id = category.Id;
      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
