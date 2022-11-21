using System.IO;
using TaskDependencyManagement;

public class TimerCommand : ConsoleCommand
{
    public TimerCommand() : base("timer", "timer <ms>      # starts timer for <ms> milliseconds")
    { }

    public TimerCommand(ServiceLocator locator) : base("timer", "timer <ms>      # starts timer for <ms> milliseconds", locator)
    {
        Locator = locator;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            Locator.Get<TextWriter>().WriteLine("Error!");
            return;
        }
        var timeout = TimeSpan.FromMilliseconds(int.Parse(args[1]));
        Locator.Get<TextWriter>().WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        Locator.Get<TextWriter>().WriteLine("Done!");
    }
}