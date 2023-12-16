namespace Northwind.Application.Shippers.Commands;

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
      var shipper = db.Shippers.Find(command.Id);

      db.Shippers.Remove(shipper);
      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult(Unit.Value);
    }
  }

}
