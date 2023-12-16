namespace Northwind.Application.Customers.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Update
{
  public sealed record Command : ICommand<(Customer Model, IEnumerable<ValidationFailure> Errors)>
  {
    public Customer Model{ get; set; } 
  }
    
  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (Customer Model, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(Customer Model, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.CustomerValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;
        
      if (!result.IsValid)
      {
        return ValueTask.FromResult((command.Model, errors));
      }
        
      var customer = command.Model.FromDto();
        
      db.Customers.Update(customer);
        
      db.CommitAsync(cancellationToken);
      
      return ValueTask.FromResult((command.Model, errors));
    }
  }

}
