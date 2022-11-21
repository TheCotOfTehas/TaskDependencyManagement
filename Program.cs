using TaskDependencyManagement;


ICommandsExecutor executor = CreateExecutor();
if (args.Length > 0)
    executor.Execute(args);
else
    RunInteractiveMode(executor);

static ICommandsExecutor CreateExecutor()
{
    var locator = new ServiceLocator();
    locator.Register(Console.Out);
    locator.Register<ConsoleCommand>(new PrintTimeCommand(locator));
    locator.Register<ConsoleCommand>(new TimerCommand(locator));
    locator.Register<ConsoleCommand>(new HelpCommand(locator));
    locator.Register<ConsoleCommand>(new DetailedHelpCommand(locator));
    locator.Register<ICommandsExecutor>(new CommandsExecutor(locator));
    return locator.Get<ICommandsExecutor>();
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