using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly FileSystemMode _filesystem;

    public ConnectCommand(string address, FileSystemMode filesystem)
    {
        _address = address;
        _filesystem = filesystem;
    }

    public StatusCommand Execute(Context context)
    {
        return context.Connect(_address, _filesystem);
    }
}