using static TaskDependencyManagement.NewProgram;

if (args.Length > 0)
    RunCommand(args);
else
    RunInteractiveMode();