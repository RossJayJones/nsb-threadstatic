using Ninject;

namespace Client
{
    using NServiceBus;
    
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            var kernel = new StandardKernel();
            configuration.EndpointName("client");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseContainer<NinjectBuilder>(c => c.ExistingKernel(kernel));
        }
    }
}
