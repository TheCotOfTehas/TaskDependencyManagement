using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDependencyManagement
{
    public class ServiceLocator : IServiceLocation
    {
        private readonly Dictionary<Type, List<object>> services
                = new Dictionary<Type, List<object>>();
        public TService Get<TService>()
        {
            return (TService)services[typeof(TService)].Single();
        }

        public IEnumerable<TService> GetAll<TService>()
        {
            return services[typeof(TService)].Cast<TService>();
        }

        public void Register<TService>(TService service)
        {
            var key = typeof(TService);
            if (!services.ContainsKey(key))
                services.Add(key, new List<object>());
            services[key].Add(service);
        }
    }
}
