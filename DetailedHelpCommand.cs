internal class DetailedHelpCommand
{
    internal static void Execute(string commandName, TextWriter textReader)
    {
        textReader.WriteLine("");
        if (commandName == "timer")
            textReader.WriteLine("timer <ms> — starts timer for <ms> milliseconds");
        else if (commandName == "printtime")
            textReader.WriteLine("printtime — prints current time");
        else if (commandName == "h")
            textReader.WriteLine("h — prints available commands list");
        else if (commandName == "help")
            textReader.WriteLine("help <command> — prints help for <command>");
        else
        {
            ShowUnknownCommandError(commandName, textReader);
        }
    }

    internal static void ShowUnknownCommandError(string command, TextWriter textReader)
    {
        textReader.WriteLine("Sorry. Unknown command {0}", command);
    }
}