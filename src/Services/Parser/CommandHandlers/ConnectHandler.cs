using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class ConnectHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 4 && commands[0] == "connect" && commands[2] == "-m" && commands[3] == "local")
        {
            return new ConnectCommand(commands[1], FileSystemMode.Local);
        }

        return NextHandler?.Handle(commands);
    }
}