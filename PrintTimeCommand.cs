using System.IO;
using TaskDependencyManagement;

public class PrintTimeCommand : ConsoleCommand
{
    public PrintTimeCommand(IServiceLocation locator)
        : base("printtime", "printtime      # prints current time", locator) { }

    public override void Execute(string[] args)
    {
        Locator.Get<TextWriter>().WriteLine(DateTime.Now);
    }
}