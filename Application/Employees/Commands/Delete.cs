namespace Northwind.Application.Employees.Commands;

using Common.Interfaces;
using Mediator;

public class Delete
{
  public sealed record Command : ICommand
  {
     public int Id{ get; set; } 
  }
    
  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command> 
  {
    public ValueTask<Unit> Handle(Command command, CancellationToken cancellationToken)
    {
      var employee = db.Employees.Find(command.Id);
        
      db.Employees.Remove(employee);
      db.CommitAsync(cancellationToken);
        
      return ValueTask.FromResult(Unit.Value);
    }
  }

}
