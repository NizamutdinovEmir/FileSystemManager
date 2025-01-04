using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ConsoleParser
{
    private readonly ICommandHandler _handler;

    public ConsoleParser(ICommandHandler handler)
    {
        _handler = handler;
    }

    public ICommand Parse(string command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        IList<string> args = new List<string>(
            command.Split(" ", StringSplitOptions.RemoveEmptyEntries));

        ICommand? handledCommand = _handler.Handle(args);

        if (handledCommand == null)
        {
            throw new InvalidOperationException($"Unknown command: {command}");
        }

        return handledCommand;
    }
}