using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShowCommand : ICommand
{
    private readonly FileShowMode _fileSystem;
    private readonly string _filePath;

    public FileShowCommand(FileShowMode fileSystem, string filePath)
    {
        _fileSystem = fileSystem;
        _filePath = filePath;
    }

    public StatusCommand Execute(Context context)
    {
        return context.FileShow(_fileSystem, _filePath);
    }
}