using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class DisconnectHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count == 1 && commands[0] == "disconnect")
        {
            return new DisconnectCommand();
        }

        return NextHandler?.Handle(commands);
    }
}