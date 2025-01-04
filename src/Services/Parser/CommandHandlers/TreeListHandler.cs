using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;

public class TreeListHandler : CommandHandlerBase
{
    public override ICommand? Handle(IList<string> commands)
    {
        if (commands.Count >= 2 && (commands[0] == "tree") & (commands[1] == "list"))
        {
            int depth = 1;
            if (commands.Count == 4 && commands[2] == "-d")
            {
                if (int.TryParse(commands[3], out depth))
                {
                    return new TreeListCommand(depth);
                }
            }

            return new TreeListCommand(depth);
        }

        return NextHandler?.Handle(commands);
    }
}