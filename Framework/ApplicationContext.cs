using System.Collections.Generic;

namespace System
{
    public class ApplicationContext
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        private ApplicationContext()
        {
            
        }

        public object this[string key]
        {
            get
            {
                lock (this)
                {
                    if (!_data.ContainsKey(key))
                        return null;
                    return _data[key];
                }
            }
            set
            {
                lock (this)
                {
                    if (!_data.ContainsKey(key))
                        _data.Add(key, value);
                    _data[key] = value;
                }
            }
        }

        private static volatile ApplicationContext _current;
        public static ApplicationContext Current
        {
            get
            {
                if(_current == null)
                {
                    lock(typeof(ApplicationContext))
                    {
                        if(_current == null)
                        {
                            _current = new ApplicationContext();
                        }
                    }
                }
                return _current;
            }
        }
    }
}
