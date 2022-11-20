internal class PrintTimeCommand
{
    internal static void Execute(TextWriter textReader)
    {
        textReader.WriteLine(DateTime.Now);
    }
}