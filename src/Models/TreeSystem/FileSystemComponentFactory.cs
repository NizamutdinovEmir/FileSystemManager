namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TreeSystem;

public class FileSystemComponentFactory
{
    public IFileSystemComponent Create(string path)
    {
        if (File.Exists(path))
        {
            string fileName = Path.GetFileName(path);
            return new FileSystemComponent(fileName);
        }

        if (Directory.Exists(path))
        {
            string? name = Path.GetFileName(path);

            IEnumerable<string> names = Directory
                .EnumerateFileSystemEntries(path)
                .Select(Path.GetFileName)
                .Where(x => x is not null)
                .Cast<string>();

            IFileSystemComponent[] components = names
                .Select(entry => Path.Combine(path, entry))
                .Select(Create)
                .ToArray();

            return new DirectorySystemComponent(name ?? string.Empty, components);
        }

        throw new ArgumentException("Invalid path");
    }
}