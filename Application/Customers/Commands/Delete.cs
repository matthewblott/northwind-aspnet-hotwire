namespace Northwind.Application.Customers.Commands;

using Common.Interfaces;
using Mediator;

public class Delete
{
  public sealed record Command : ICommand
  {
     public string Id{ get; set; } 
  }
    
  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command> 
  {
    public ValueTask<Unit> Handle(Command command, CancellationToken cancellationToken)
    {
      var customer = db.Customers.Find(command.Id);
        
      db.Customers.Remove(customer);
      db.CommitAsync(cancellationToken);
        
      return ValueTask.FromResult(Unit.Value);
    }
  }

}
