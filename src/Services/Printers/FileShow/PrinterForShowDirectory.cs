namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Printers.FileShow;

public class PrinterForShowDirectory : IPrinterForShow
{
    public void Show(string path)
    {
        Console.WriteLine($"Contents of directory: {path}");
        foreach (string entry in Directory.GetFileSystemEntries(path))
        {
            Console.WriteLine($"- {entry}");
        }
    }
}