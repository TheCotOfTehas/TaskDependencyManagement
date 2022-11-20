internal class TimerComman
{
    internal static void Execute(int time, TextWriter textReader)
    {
        var timeout = TimeSpan.FromMilliseconds(time);
        Console.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        textReader.WriteLine("Done!");
    }
}