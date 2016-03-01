using System;

namespace Ninject
{
    public static class Ioc
    {
        private static object _sync = new object();

        public static void RegisterSingleton()
        {
            lock (_sync)
            {
                if (Kernel != null)
                    return;
                MultiTargetSingletonContainer<IKernel>.RegisterSingleton(new StandardKernel());
            }
        }

        public static IKernel Kernel => MultiTargetSingletonContainer<IKernel>.Value;

        public static void ConfigureForTesting(IKernel kernel)
        {
            MultiTargetSingletonContainer<IKernel>.RegisterSingleton(kernel);
        }
    }
}
