using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class Context
{
    public IFileSystem? FileSystem { get; private set; }

    public string DirectoryName { get; private set; } = string.Empty;

    public StatusCommand Connect(string address, FileSystemMode fileSystemMode)
    {
        DirectoryName = MakeAbsolutePath(address);

        IFileSystem fileSystem = fileSystemMode switch
        {
            FileSystemMode.Local => new LocalFileSystem(),
            FileSystemMode.ImMemory => throw new NotImplementedException(),
            _ => throw new NotSupportedException($"Unsupported file system mode: {fileSystemMode}"),
        };

        FileSystem = fileSystem;

        return FileSystem.Connect(DirectoryName);
    }

    public StatusCommand Disconnect()
    {
        if (FileSystem != null)
        {
            StatusCommand statusDisconnect = FileSystem.Disconnect();
            FileSystem = null;
            DirectoryName = string.Empty;
            return statusDisconnect;
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand FileCopy(string sourceFilePath, string destinationFilePath)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Copy(MakeAbsolutePath(sourceFilePath), MakeAbsolutePath(destinationFilePath));
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand FileDelete(string filePath)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Delete(MakeAbsolutePath(filePath));
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand FileMove(string sourceFilePath, string destinationFilePath)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Move(MakeAbsolutePath(sourceFilePath), MakeAbsolutePath(destinationFilePath));
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand FileRename(string sourcePath, string newName)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Rename(MakeAbsolutePath(sourcePath), newName);
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand FileShow(FileShowMode fileSystemMode, string path)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Show(fileSystemMode, MakeAbsolutePath(path));
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand TreeGoto(string filePath)
    {
        if (FileSystem is not null)
        {
            return FileSystem.Exists(MakeAbsolutePath(filePath))
                ? new StatusCommand.Success()
                : new StatusCommand.Failure.ExecutionError.NotExist();
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    public StatusCommand TreeList(int depth)
    {
        if (FileSystem is not null)
        {
            return FileSystem.List(depth, DirectoryName);
        }

        return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
    }

    private string MakeAbsolutePath(string path)
    {
        return Path.IsPathRooted(path) ? path : Path.Combine(DirectoryName, path);
    }
}