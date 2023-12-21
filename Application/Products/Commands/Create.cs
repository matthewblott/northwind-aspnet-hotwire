namespace Northwind.Application.Products.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<(Product Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Product Model { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Product Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Product Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.ProductValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;

      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }

      var product = command.Model.FromDto();

      db.Products.Add(product);

      db.CommitAsync(cancellationToken);
      command.Model.Id = product.Id;
      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
