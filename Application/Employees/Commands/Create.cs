namespace Northwind.Application.Employees.Commands;

using Common.Interfaces;
using FluentValidation;
using Mediator;
using Shared.Models;

public class Create
{
  public sealed record Command : ICommand<int>
  {
     public string FirstName { get; set; }
     public string LastName { get; set; }
  }
    
  public class Validator : AbstractValidator<Employee>
  {
    public Validator()
    {
      RuleFor(x => x.FirstName).Length(1, 40);
    }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, int>
  {
    public ValueTask<int> Handle(Command command, CancellationToken cancellationToken)
    {
      var newId = db.Employees.Count() + 1;
      
      var employee = new Domain.Employee
      {
        Id = newId,
        FirstName = command.FirstName,
        LastName = command.LastName,
      };

      db.Employees.Add(employee);
      
      var id = employee.Id;
        
      db.CommitAsync(cancellationToken);
        
      return ValueTask.FromResult(id);
    }
  }

}
