using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TreeSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Printers.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public StatusCommand Connect(string path)
    {
        if (Exists(path))
        {
            return new StatusCommand.Success();
        }

        return new StatusCommand.Failure.ExecutionError.NotExist();
    }

    public StatusCommand Disconnect()
    {
        return new StatusCommand.Success();
    }

    public StatusCommand Copy(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
        {
            return new StatusCommand.Failure.SyntaxError();
        }

        if (Exists(sourcePath))
        {
            try
            {
                File.Copy(sourcePath, destinationPath);
                return new StatusCommand.Success();
            }
            catch (FileNotFoundException)
            {
                return new StatusCommand.Failure.ExecutionError();
            }
            catch (IOException)
            {
                return new StatusCommand.Failure.ExecutionError.FileNameDuplicate();
            }
        }

        return new StatusCommand.Failure.ExecutionError.NotExist();
    }

    public StatusCommand Delete(string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            return new StatusCommand.Failure.SyntaxError();
        }

        if (Exists(destinationPath))
        {
            try
            {
                File.Delete(destinationPath);
                return new StatusCommand.Success();
            }
            catch (IOException)
            {
                return new StatusCommand.Failure.ExecutionError();
            }
        }

        return new StatusCommand.Failure.ExecutionError.NotExist();
    }

    public StatusCommand Move(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
        {
            return new StatusCommand.Failure.SyntaxError.InvalidCommand();
        }

        if (!Exists(sourcePath))
        {
            return new StatusCommand.Failure.ExecutionError.NotExist();
        }

        try
        {
            File.Move(sourcePath, destinationPath);
            return new StatusCommand.Success();
        }
        catch (FileNotFoundException)
        {
            return new StatusCommand.Failure.ExecutionError.NotExist();
        }
        catch (UnauthorizedAccessException)
        {
            return new StatusCommand.Failure.ExecutionError();
        }
        catch (IOException)
        {
            return new StatusCommand.Failure.ExecutionError();
        }
        catch (Exception)
        {
            return new StatusCommand.Failure.ExecutionError();
        }
    }

    public StatusCommand Rename(string path, string newName)
    {
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(newName))
        {
            return new StatusCommand.Failure.SyntaxError();
        }

        string newPath = Path.Combine(Path.GetDirectoryName(path) ?? string.Empty, newName);

        try
        {
            if (File.Exists(path))
            {
                File.Move(path, newPath);
            }
            else if (Directory.Exists(path))
            {
                Directory.Move(path, newPath);
            }
            else
            {
                return new StatusCommand.Failure.ExecutionError.NotExist();
            }

            return new StatusCommand.Success();
        }
        catch (Exception)
        {
            return new StatusCommand.Failure.ExecutionError();
        }
    }

    public StatusCommand Show(FileShowMode mode, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return new StatusCommand.Failure.SyntaxError();
        }

        if (Exists(path))
        {
            try
            {
                IPrinterForShow printer;
                if (mode == FileShowMode.Console)
                {
                    if (File.Exists(path))
                    {
                        printer = new PrinterForShowFile();
                    }
                    else if (Directory.Exists(path))
                    {
                        printer = new PrinterForShowDirectory();
                    }
                    else
                    {
                        return new StatusCommand.Failure.ExecutionError.NotExist();
                    }

                    printer.Show(path);
                    return new StatusCommand.Success();
                }
            }
            catch (Exception)
            {
                return new StatusCommand.Failure.ExecutionError();
            }
        }

        return new StatusCommand.Failure.ExecutionError.NotExist();
    }

    public bool Exists(string path)
    {
        return File.Exists(path) || Directory.Exists(path);
    }

    public StatusCommand List(int depth, string directory)
    {
        if (string.IsNullOrWhiteSpace(directory))
        {
            return new StatusCommand.Failure.ExecutionError.NotConnectionToFileSystem();
        }

        try
        {
            var factory = new FileSystemComponentFactory();
            IFileSystemComponent root = factory.Create(directory);

            var visitor = new ConsoleVisitor(depth);
            root.Accept(visitor);

            return new StatusCommand.Success();
        }
        catch (Exception)
        {
            return new StatusCommand.Failure.ExecutionError();
        }
    }
}