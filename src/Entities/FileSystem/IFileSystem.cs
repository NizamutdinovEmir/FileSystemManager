using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFileSystem
{
    StatusCommand Connect(string path);

    StatusCommand Disconnect();

    StatusCommand Copy(string sourcePath, string destinationPath);

    StatusCommand Delete(string destinationPath);

    StatusCommand Move(string sourcePath, string destinationPath);

    StatusCommand Rename(string path, string newName);

    StatusCommand Show(FileShowMode mode, string path);

    bool Exists(string path);

    StatusCommand List(int depth, string directory);
}