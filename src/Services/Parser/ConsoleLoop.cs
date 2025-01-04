using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ConsoleLoop
{
    private readonly ConsoleParser _parser;

    public ConsoleLoop(ConsoleParser parser)
    {
        _parser = parser;
    }

    public void Run(Context context)
    {
        while (true)
        {
            Console.Write("> ");
            string? commandInput = Console.ReadLine();
            if (commandInput == "exit")
            {
                break;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(commandInput))
                {
                    ICommand? command = _parser.Parse(commandInput);

                    if (command is null)
                    {
                        Console.WriteLine("Unknown command. Please try again.");
                        continue;
                    }

                    // Выполнение команды
                    StatusCommand status = command.Execute(context);

                    switch (status)
                    {
                        case StatusCommand.Success success:
                            Console.WriteLine(success.ToString());
                            break;

                        case StatusCommand.Failure failure:
                            Console.WriteLine(failure.GetErrorMessage());
                            break;

                        default:
                            Console.WriteLine("Unexpected status command.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}