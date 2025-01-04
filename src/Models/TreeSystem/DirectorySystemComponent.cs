using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TreeSystem;

public class DirectorySystemComponent : IFileSystemComponent
{
    public DirectorySystemComponent(string name, IReadOnlyCollection<IFileSystemComponent> components)
    {
        Name = name;
        Files = components;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Files { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}