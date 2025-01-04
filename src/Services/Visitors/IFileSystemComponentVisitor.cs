using Itmo.ObjectOrientedProgramming.Lab4.Models.TreeSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileSystemComponent component);

    void Visit(DirectorySystemComponent component);
}