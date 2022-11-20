if (args.Length > 0)
    CommandsExecuter.RunCommand(args);
else
    RunInteractiveMode();

static void RunInteractiveMode()
{
    while (true)
    {
        var line = Console.ReadLine();
        if (line == null || line == "exit") return;
        CommandsExecuter.RunCommand(line.Split(' '));
    }
}