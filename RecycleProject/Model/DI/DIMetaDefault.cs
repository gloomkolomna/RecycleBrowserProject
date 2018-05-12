using Microsoft.Extensions.DependencyInjection;
using RecycleProject.Interfaces.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleProject.Model.DI
{
    internal class DIMetaDefault : IDIMeta
    {
        IDictionary<Type, Type> register = new Dictionary<Type, Type>();
        public DIMetaDefault(IServiceCollection services)
        {
            foreach (var s in services)
            {
                register[s.ServiceType] = s.ImplementationType;
            }
        }
        public bool IsRegistred(Type t)
        {
            return register.ContainsKey(t);
        }

        public Type RegistredTypeFor(Type t)
        {
            return register[t];
        }
    }
}
