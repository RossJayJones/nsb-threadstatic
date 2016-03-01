using System.Collections.Concurrent;

namespace System
{
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;

        private readonly Func<ObjectPool<T>, T> _factory;
        
        public ObjectPool(Func<ObjectPool<T>, T> factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            _factory = factory;
            _objects = new ConcurrentBag<T>();
        }

        public T Get()
        {
            T item;
            if (_objects.TryTake(out item))
            {
                return item;
            }
            return _factory(this);
        }

        public void Release(T item)
        {
            _objects.Add(item);
        }

        public int Count => _objects.Count;
    }
}
