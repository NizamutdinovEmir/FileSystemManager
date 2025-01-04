using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler handler);

    ICommand? Handle(IList<string> commands);
}