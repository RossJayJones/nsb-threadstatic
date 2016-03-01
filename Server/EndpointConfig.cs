using System;
using Ninject;

namespace Server
{
    using NServiceBus;
    
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            Ioc.RegisterSingleton();
            configuration.EndpointName("server");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseContainer<NinjectBuilder>(c => c.ExistingKernel(Ioc.Kernel));
            Ioc.Kernel.Load(new Module());
        }
    }
}
