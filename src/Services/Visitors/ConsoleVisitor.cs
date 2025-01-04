using Itmo.ObjectOrientedProgramming.Lab4.Models.TreeSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public class ConsoleVisitor : IFileSystemComponentVisitor
{
    private readonly int _depth;
    private int _currentDepth;

    public ConsoleVisitor(int depth)
    {
        _depth = depth;
        _currentDepth = 0;
    }

    public void Visit(FileSystemComponent component)
    {
        if (_currentDepth <= _depth)
        {
            PrintTree(component.Name);
        }
    }

    public void Visit(DirectorySystemComponent component)
    {
        if (_currentDepth > _depth)
        {
            return;
        }

        PrintTree(component.Name);
        _currentDepth++;
        foreach (IFileSystemComponent file in component.Files)
        {
            file.Accept(this);
        }

        _currentDepth--;
    }

    private void PrintTree(string name)
    {
        if (_currentDepth != 0)
        {
            Console.Write(string.Concat(Enumerable.Repeat("   ", _currentDepth)));
            Console.Write("|–> ");
        }

        Console.WriteLine(name);
    }
}