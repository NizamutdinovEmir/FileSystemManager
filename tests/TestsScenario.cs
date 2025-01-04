using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser.CommandHandlers;
using Xunit;

namespace Lab4.Tests;

public class TestsScenario
{
    [Fact]
    public void ConnectToFileSystem()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);

        try
        {
            string command = $"connect {tempDirectory} -m local";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }

    [Fact]
    public void DisconnectFileSystem()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new DisconnectHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandDisconnect = "disconnect";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandDisconnectParsed = parser.Parse(commandDisconnect);
            StatusCommand status2 = commandDisconnectParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }

    [Fact]
    public void CopyFile()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new FileCopyHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        string tempDirectory2 = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory2");
        Directory.CreateDirectory(tempDirectory2);
        string testFilePath2 = Path.Combine(tempDirectory2, "test.txt");

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandCopy = $"file copy {testFilePath} {testFilePath2}";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandCopyParsed = parser.Parse(commandCopy);
            StatusCommand status2 = commandCopyParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }

            if (Directory.Exists(tempDirectory2))
            {
                Directory.Delete(tempDirectory2, true);
            }
        }
    }

    [Fact]
    public void DeleteFile()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new FileDeleteHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandDelete = $"file delete {testFilePath}";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandDeleteParsed = parser.Parse(commandDelete);
            StatusCommand status2 = commandDeleteParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }

    [Fact]
    public void MoveFile()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new FileMoveHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        string tempDirectory2 = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory2");
        Directory.CreateDirectory(tempDirectory2);
        string testFilePath2 = Path.Combine(tempDirectory2, "test.txt");

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandMove = $"file move {testFilePath} {testFilePath2}";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandMoveParsed = parser.Parse(commandMove);
            StatusCommand status2 = commandMoveParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }

            if (Directory.Exists(tempDirectory2))
            {
                Directory.Delete(tempDirectory2, true);
            }
        }
    }

    [Fact]
    public void RenameFile()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new FileRenameHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandRename = $"file rename {testFilePath} text2.txt";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandRenameParsed = parser.Parse(commandRename);
            StatusCommand status2 = commandRenameParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }

    [Fact]
    public void ShowFile()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new FileShowHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandShow = $"file show {testFilePath} -m console";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandShowParsed = parser.Parse(commandShow);
            StatusCommand status2 = commandShowParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }

    [Fact]
    public void ListFiles()
    {
        // Arrange
        var rootHandler = new ConnectHandler();
        var parser = new ConsoleParser(rootHandler);
        rootHandler
            .AddNext(new TreeListHandler());
        var context = new Context();

        string tempDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(tempDirectory);
        string testFilePath = Path.Combine(tempDirectory, "test.txt");

        using (File.Create(testFilePath))
        {
        }

        try
        {
            string command = $"connect {tempDirectory} -m local";
            string commandShow = $"tree list -d 1";

            // Act
            ICommand commandParsed = parser.Parse(command);
            StatusCommand status = commandParsed.Execute(context);
            ICommand commandShowParsed = parser.Parse(commandShow);
            StatusCommand status2 = commandShowParsed.Execute(context);

            // Assert
            Assert.Equal(new StatusCommand.Success(), status2);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }
}