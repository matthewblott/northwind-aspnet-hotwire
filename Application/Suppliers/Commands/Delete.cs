namespace Northwind.Application.Suppliers.Commands;

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
      var supplier = db.Suppliers.Find(command.Id);

      db.Suppliers.Remove(supplier);
      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult(Unit.Value);
    }
  }

}
