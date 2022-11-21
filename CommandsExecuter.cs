using TaskDependencyManagement;

public class CommandsExecutor : ICommandsExecutor
{
    private readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();

    public ServiceLocator Locator { get; }

    public CommandsExecutor(ServiceLocator locator)
    {
        Locator = locator;
    }

    public void Register(ConsoleCommand command)
    {
        commands.Add(command);
    }

    public string[] GetAvailableCommandName()
    {
        return commands.Select(c => c.Name).ToArray();
    }

    public ConsoleCommand FindCommandByName(string name)
    {
        return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public void Execute(string[] args)
    {
        if (args[0].Length == 0)
        {
            Console.WriteLine("Please specify <command> as the first command line argument");
            return;
        }

        var commandName = args[0];
        var cmd = FindCommandByName(commandName);
        if (cmd == null)
            Locator.Get<TextWriter>().WriteLine("Sorry. Unknown command {0}", commandName);
        else
            cmd.Execute(args);
    }
}