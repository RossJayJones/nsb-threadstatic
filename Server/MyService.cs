using System;

namespace Server
{
    public class MyService : IMyService, IDisposable
    {
        private readonly Guid _id;

        private readonly ObjectPool<IMyService> _pool;

        public MyService(ObjectPool<IMyService> pool)
        {
            _id = Guid.NewGuid();
            _pool = pool;
            Console.WriteLine($"---- creating {_id}");
        }

        public string DoWork()
        {
            return _id.ToString();
        }

        public void Dispose()
        {
            Console.WriteLine($"---- releasing {_id}");
            _pool.Release(this);
        }
    }
}
