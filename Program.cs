using TaskDependencyManagement;


ICommandsExecutor executor = CreateExecutor();
if (args.Length > 0)
    executor.Execute(args);
else
    RunInteractiveMode(executor);

static ICommandsExecutor CreateExecutor()
{
    // Этот метод — единственное место изменения, при добавлении новой команды
    var executor = new CommandsExecutor(Console.Out);
    executor.Register(new PrintTimeCommand());
    executor.Register(new TimerCommand());
    executor.Register(new HelpCommand(executor));
    executor.Register(new DetailedHelpCommand(executor.FindCommandByName));
    return executor;
}
static void RunInteractiveMode(ICommandsExecutor executor)
{
    while (true)
    {
        var line = Console.ReadLine();
        if (line == null || line == "exit")
            return;
        executor.Execute(line.Split(' '));
    }
}