namespace Northwind.Application.Employees.Commands;

using Common.Interfaces;
using FluentValidation.Results;
using Mediator;
using Shared;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<(int Id, IEnumerable<ValidationFailure> Errors)>
  {
     public Employee Model{ get; set; } 
  }
    
  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, (int Id, IEnumerable<ValidationFailure> Errors)>
  {
    public ValueTask<(int Id, IEnumerable<ValidationFailure> Errors)> Handle(Command command, CancellationToken cancellationToken)
    {
      var validator = new Shared.Validators.EmployeeValidator();
      var result = validator.Validate(command.Model);

      IEnumerable<ValidationFailure> errors = result.Errors;
        
      if (!result.IsValid)
      {
        return ValueTask.FromResult((-1, errors));
      }
        
      var employee = command.Model.FromDto();
      
      employee.Id = db.Employees.Count() + 1;
             
      db.Employees.Add(employee);
        
      db.CommitAsync(cancellationToken);
      
      return ValueTask.FromResult((employee.Id, errors));
    }
  }

}
