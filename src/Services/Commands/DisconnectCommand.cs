using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommand
{
    public StatusCommand Execute(Context context)
    {
        return context.Disconnect();
    }
}