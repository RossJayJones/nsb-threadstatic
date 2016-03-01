using System;

namespace Server
{
    public class ThreadStaticWrapper : IMyService, IDisposable
    {
        private readonly ObjectPool<IMyService> _pool;

        private readonly IMyService _item;

        public ThreadStaticWrapper(ObjectPool<IMyService> pool)
        {
            _pool = pool;
            _item = pool.Get();
        }

        public string DoWork()
        {
            return _item.DoWork();
        }

        public void Dispose()
        {
            _pool.Release(_item);
        }
    }
}
