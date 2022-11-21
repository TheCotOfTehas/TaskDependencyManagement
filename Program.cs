using Ninject;
using TaskDependencyManagement;


//ICommandsExecutor executor = CreateExecutor();
//if (args.Length > 0)
//    executor.Execute(args);
//else
//    RunInteractiveMode(executor);
ICommandsExecutor executor = CreateExecutor();
if (args.Length > 0)
    executor.Execute(args);
else
    RunInteractiveMode(executor);

static ICommandsExecutor CreateExecutor()
{
    var container = new StandardKernel();

    // Регистрируем все имеющиеся реализации ConsoleCommand:
    container.Bind<ConsoleCommand>().To<TimerCommand>();
    container.Bind<ConsoleCommand>().To<PrintTimeCommand>();
    //...

    container.Bind<TextWriter>().ToConstant(Console.Out);
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