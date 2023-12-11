namespace Northwind.Application.Employees.Commands;

using Common.Interfaces;
using FluentValidation;
using Mediator;
using Shared.Models;

public class Create
{
  public sealed record Command : IRequest<int>
  {
     public string FirstName { get; set; }
  }
    
  public class Validator : AbstractValidator<Employee>
  {
    public Validator()
    {
      RuleFor(x => x.FirstName).Length(1, 40);
    }
  }

  public sealed class Handler(INorthwindDbContext db) : IRequestHandler<Command, int>
  {
    public ValueTask<int> Handle(Command command, CancellationToken cancellationToken)
    {
      var employee = new Domain.Employee
      {
        FirstName = command.FirstName
      };

      db.Employees.Add(employee);
      var id = employee.Id;       
        
      return ValueTask.FromResult(id);
    }
  }

}
