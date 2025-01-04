using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;

    public FileDeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public StatusCommand Execute(Context context)
    {
        return context.FileDelete(_filePath);
    }
}