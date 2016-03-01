using System;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;

namespace Server
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            /*Bind<IMyService>().ToMethod(context =>
            {
                Console.WriteLine("Creating a new service");
                return new MyService();
            }).InThreadScope();*/

            var pool = new ObjectPool<IMyService>(p => new MyService(p));
            Bind<ObjectPool<IMyService>>().ToConstant(pool).InSingletonScope();
            Bind<IMyService>().ToMethod(context =>
            {
                var service = pool.Get();
                Console.WriteLine($"________retrieved {service.DoWork()}_______________");
                return service;
            }).WhenInUnitOfWork().InUnitOfWorkScope();

            Bind<IMyOtherService>().To<MyOtherService>();
        }
    }
}
