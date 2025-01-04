using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class FileDeleteHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 3 && commands[0] == "file" && commands[1] == "delete")
        {
            return new FileDeleteCommand(commands[2]);
        }

        return NextHandler?.Handle(commands);
    }
}