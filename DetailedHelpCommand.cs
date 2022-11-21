using System.IO;
using TaskDependencyManagement;

public class DetailedHelpCommand : ConsoleCommand
{
    public DetailedHelpCommand(IServiceLocation locator)
        : base("help", "help <command>      # prints help for <command>", locator)
    { }

    public override void Execute(string[] args)
    {
        var commandName = args[0];
        var command = Locator.Get<ICommandsExecutor>().FindCommandByName(commandName);
        var writer = Locator.Get<TextWriter>();
        if (command != null)
        {
            writer.WriteLine(command.Help);
        }
        else
        {
            writer.WriteLine("Not a command " + commandName);
        }
    }
}