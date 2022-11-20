internal class CommandsExecuter
{
    internal static void RunCommand(string[] args)
    {
        var writer = Console.Out;
        var command = args[0];
        if (command == "timer")
            TimerComman.Execute(int.Parse(args[1]), writer);
        else if (command == "printtime")
            PrintTimeCommand.Execute(writer);
        else if (command == "h")
            HelpCommand.Execute(writer);
        else if (command == "help")
            DetailedHelpCommand.Execute(args[1], writer);
        else ShowUnknownCommandError(args[0], writer);
    }

    internal static void ShowUnknownCommandError(string command, TextWriter textReader)
    {
        textReader.WriteLine("Sorry. Unknown command {0}", command);
    }
}