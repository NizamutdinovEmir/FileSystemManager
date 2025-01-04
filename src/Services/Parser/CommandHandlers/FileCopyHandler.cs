using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class FileCopyHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 4 && commands[0] == "file" && commands[1] == "copy")
        {
            return new FileCopyCommand(commands[2], commands[3]);
        }

        return NextHandler?.Handle(commands);
    }
}