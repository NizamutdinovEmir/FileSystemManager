using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _newName;

    public FileRenameCommand(string sourcePath, string newName)
    {
        _sourcePath = sourcePath;
        _newName = newName;
    }

    public StatusCommand Execute(Context context)
    {
        return context.FileRename(_sourcePath, _newName);
    }
}