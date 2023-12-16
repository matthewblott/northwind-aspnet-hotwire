namespace Northwind.Application.Orders.Commands;

using Common.Interfaces;
using Mediator;

public class Delete
{
  public sealed record Command : ICommand
  {
    public int Id { get; set; }
  }

  public sealed class Handler(INorthwindDbContext db) : ICommandHandler<Command>
  {
    public ValueTask<Unit> Handle(Command command, CancellationToken cancellationToken)
    {
      var order = db.Orders.Find(command.Id);

      db.Orders.Remove(order);
      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult(Unit.Value);
    }
  }

}
