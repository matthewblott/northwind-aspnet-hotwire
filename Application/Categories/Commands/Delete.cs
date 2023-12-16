namespace Northwind.Application.Categories.Commands;

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
      var category = db.Categories.Find(command.Id);

      db.Categories.Remove(category);
      db.CommitAsync(cancellationToken);

      return ValueTask.FromResult(Unit.Value);
    }
  }

}
