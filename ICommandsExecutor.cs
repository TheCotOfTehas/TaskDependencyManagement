using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDependencyManagement
{
    internal interface ICommandsExecutor
    {
        string[] GetAvailableCommandName();
        void Execute(string[] args);
    }
}
