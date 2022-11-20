internal class HelpCommand
{
    internal static void Execute(TextWriter textReader)
    {
        textReader.WriteLine("Available commands: timer, printtime, help, h");
    }
}