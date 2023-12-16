namespace Northwind.Application.Products.Commands;

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
      var region = db.Products.Find(command.Id);

      db.Products.Remove(region);
      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult(Unit.Value);
    }
  }

}
