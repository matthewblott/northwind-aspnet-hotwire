namespace Northwind.Application.Employees.Commands;

using Common.Interfaces;
using FluentValidation;
using Mediator;
using Queries;
using Shared.Models;
using Mapper = Shared.Mapper;

public class Update
{
  public sealed record Command : ICommand<Employee>
  {
     public int Id { get; set; } 
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

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command, Employee>
  {
    public ValueTask<Employee> Handle(Command command, CancellationToken cancellationToken)
    {
      var employee = db.Employees.Find(command.Id);

      employee.FirstName = command.FirstName;
      employee.LastName = command.LastName; 

      db.Employees.Update(employee);
        
      db.CommitAsync(cancellationToken);

      var empDto = Mapper.ToDto(employee);
        
      return ValueTask.FromResult(empDto);
    }
  }

}
