using Newtonsoft.Json.Serialization;
using RecycleProject.Interfaces.DI;
using System;

namespace RecycleProject.Model.DI
{
    internal class DIContractResolver : CamelCasePropertyNamesContractResolver
    {
        private IDIMeta _diMeta;
        private IServiceProvider _serviceProvider;
        public DIContractResolver(IDIMeta diMeta, IServiceProvider serviceProvider)
        {
            _diMeta = diMeta;
            _serviceProvider = serviceProvider;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {

            if (_diMeta.IsRegistred(objectType))
            {
                JsonObjectContract contract = DIResolveContract(objectType);
                contract.DefaultCreator = () => _serviceProvider.GetService(objectType);

                return contract;
            }

            return base.CreateObjectContract(objectType);
        }

        private JsonObjectContract DIResolveContract(Type objectType)
        {
            var fType = _diMeta.RegistredTypeFor(objectType);
            if (fType != null) return base.CreateObjectContract(fType);
            else return CreateObjectContract(objectType);
        }
    }
}