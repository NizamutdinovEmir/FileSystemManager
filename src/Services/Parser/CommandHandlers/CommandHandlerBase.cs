using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public abstract class CommandHandlerBase : ICommandHandler
{
    protected ICommandHandler? NextHandler { get; private set; }

    public ICommandHandler AddNext(ICommandHandler handler)
    {
        if (NextHandler == null)
        {
            NextHandler = handler;
        }
        else
        {
            NextHandler.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(IList<string> commands);
}