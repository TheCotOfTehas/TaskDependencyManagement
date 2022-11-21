using Ninject;
using TaskDependencyManagement;


//ICommandsExecutor executor = CreateExecutor();
//if (args.Length > 0)
//    executor.Execute(args);
//else
//    RunInteractiveMode(executor);
ICommandsExecutor executor = CreateExecutor();
executor.Execute(args);

static ICommandsExecutor CreateExecutor()
{
    var container = new StandardKernel();
    container.Bind<TextWriter>().ToConstant(Console.Out);

    // Этой команде для работы нужен CommandExecutor,
    // а ему нужен список всех команд, в том числе этой.
    // Нужно разорвать этот цикл.
    container.Bind<ConsoleCommand>().To<HelpCommand>();

    container.Bind<ConsoleCommand>().To<TimerCommand>();
    container.Bind<ConsoleCommand>().To<PrintTimeCommand>();
    container.Bind<ICommandsExecutor>().To<CommandsExecutor>();
    return container.Get<ICommandsExecutor>();
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