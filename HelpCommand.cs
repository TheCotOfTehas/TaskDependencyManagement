using System.IO;
using TaskDependencyManagement;

internal class HelpCommand : ConsoleCommand
{
    private readonly Lazy<ICommandsExecutor> executor;
    private readonly TextWriter writer;

    public HelpCommand(Lazy<ICommandsExecutor> executor, TextWriter writer)
        : base("h", "h    # prints available commands list")
    {
        this.executor = executor;
        this.writer = writer;
    }

    public HelpCommand(ServiceLocator locator)
        : base("h", "h      # prints available commands list", locator)
    {
        Locator = locator;
    }

    public override void Execute(string[] args)
    {
        Locator.Get<TextWriter>().WriteLine("Available commands: " + string.Join(", ", executor.Value.GetAvailableCommandName()));
    }
}