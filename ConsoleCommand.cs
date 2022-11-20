using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDependencyManagement
{
    public abstract class ConsoleCommand
    {
        protected ConsoleCommand(string name, string help)
        {
            Name = name;
            Help = help;
        }

        public string Name { get; }
        public string Help { get; }
        public abstract void Execute(string[] args, TextWriter writer);
    }
}
