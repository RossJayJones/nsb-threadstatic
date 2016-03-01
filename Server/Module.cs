using System;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;

namespace Server
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            // Uncomment to see thread socpe behavior
            //InThreadScope();

            // Uncomment to see unit of work scope behavior
            //InUnitOfWorkScope();
            
            // Uncomment to see object pool behavior
            UsingObjectPool();
            
            Bind<IMyOtherService>().To<MyOtherService>();
        }

        /// <summary>
        /// Shows how the instance of IMyService is created for each message when in thread scope
        /// </summary>
        private void InThreadScope()
        {
            Bind<IMyService>().ToMethod(context => new MyService()).InThreadScope();
        }

        /// <summary>
        /// Shows how the instance of IMyService is created for each message when in unit of work scope
        /// </summary>
        private void InUnitOfWorkScope()
        {
            Bind<IMyService>().ToMethod(context => new MyService()).InUnitOfWorkScope();
        }

        /// <summary>
        /// Restores original thread static behavior which ensures that there is only
        /// one instance of IMyService per worker thread
        /// </summary>
        private void UsingObjectPool()
        {
            var pool = new ObjectPool<IMyService>(p => new MyService());
            Bind<ObjectPool<IMyService>>().ToConstant(pool).InSingletonScope();
            Bind<IMyService>().ToMethod(context => new ThreadStaticWrapper(pool)).WhenInUnitOfWork().InUnitOfWorkScope();
        }
    }
}
