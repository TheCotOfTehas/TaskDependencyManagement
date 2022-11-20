using System.IO;
using TaskDependencyManagement;

public class PrintTimeCommand : ConsoleCommand
{
    public PrintTimeCommand()
        : base("printtime", "printtime      # prints current time")
    { }

    public override void Execute(string[] args, TextWriter writer)
    {
        writer.WriteLine(DateTime.Now);
    }
}