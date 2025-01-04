using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class FileShowHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 5 && commands[0] == "file" && commands[1] == "show" && commands[3] == "-m" &&
            commands[4] == "console")
        {
            return new FileShowCommand(FileShowMode.Console, commands[2]);
        }

        return NextHandler?.Handle(commands);
    }
}