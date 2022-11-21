using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDependencyManagement
{
    public interface IServiceLocation
    {
        TService Get<TService>();
        IEnumerable<TService> GetAll<TService>();
    }
}
