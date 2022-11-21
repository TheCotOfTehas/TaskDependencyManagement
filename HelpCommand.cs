using System.IO;
using TaskDependencyManagement;

internal class HelpCommand : ConsoleCommand
{
    private readonly ICommandsExecutor executor;

    public HelpCommand(ICommandsExecutor executor)
        : base("h", "h      # prints available commands list")
    {
        this.executor = executor;
    }

    public HelpCommand(ServiceLocator locator)
        : base("h", "h      # prints available commands list", locator)
    {
        Locator = locator;
    }

    public override void Execute(string[] args)
    {
        Locator.Get<TextWriter>().WriteLine("Available commands: " + string.Join(", ", executor.GetAvailableCommandName()));
    }
}