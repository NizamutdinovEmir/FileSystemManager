namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record StatusCommand
{
    public record Success : StatusCommand
    {
        public override string ToString() => "Command executed successfully.";
    }

    public abstract record Failure : StatusCommand
    {
        public abstract string GetErrorMessage();

        public record SyntaxError : Failure
        {
            public override string GetErrorMessage() => "Syntax error in the command.";

            public record UnknownCommand : SyntaxError
            {
                public override string GetErrorMessage() => "Unknown command entered.";
            }

            public record InvalidCommand : SyntaxError
            {
                public override string GetErrorMessage() => "Invalid command format.";
            }
        }

        public record ExecutionError : Failure
        {
            public override string GetErrorMessage() => "Error during command execution.";

            public record NotConnectionToFileSystem : ExecutionError
            {
                public override string GetErrorMessage() =>
                    "No connection to the file system. Please connect first.";
            }

            public record FileNameDuplicate : ExecutionError
            {
                public override string GetErrorMessage() => "File name already exists.";
            }

            public record NotExist : ExecutionError
            {
                public override string GetErrorMessage() => "The specified file or directory does not exist.";
            }
        }
    }
}