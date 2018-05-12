using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RecycleProject.Interfaces.DI;
using System;

namespace RecycleProject.Model.DI
{
    internal class JsonOptionsSetup : IConfigureOptions<MvcJsonOptions>
    {
        private IServiceProvider _serviceProvider;
        public JsonOptionsSetup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Configure(MvcJsonOptions o)
        {
            o.SerializerSettings.ContractResolver =
                new DIContractResolver(_serviceProvider.GetService<IDIMeta>(), _serviceProvider);
        }
    }
}
