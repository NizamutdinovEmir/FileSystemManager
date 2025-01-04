namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Printers.FileShow;

public class PrinterForShowFile : IPrinterForShow
{
    public void Show(string path)
    {
        Console.WriteLine($"Contents of file: {path}");
        Console.WriteLine(File.ReadAllText(path));
    }
}