using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class TreeGotoHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 3 && commands[0] == "tree" && commands[1] == "goto")
        {
            return new TreeGOTOCommand(commands[2]);
        }

        return NextHandler?.Handle(commands);
    }
}