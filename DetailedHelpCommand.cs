using System.IO;
using TaskDependencyManagement;

public class DetailedHelpCommand : ConsoleCommand
{
    private readonly Lazy<ICommandsExecutor> executor;
    private readonly TextWriter writer;
    public DetailedHelpCommand(IServiceLocation locator)
        : base("help", "help <command>      # prints help for <command>", locator)
    { }

    public override void Execute(string[] args)
    {
        var commandName = args[1];
        var command = executor.Value.FindCommandByName(commandName);
        var writer = Locator.Get<TextWriter>();
        if (command != null)
            writer.WriteLine(command.Help);
        else
            writer.WriteLine("Not a command " + commandName);
    }
}