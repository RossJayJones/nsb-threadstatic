using System;

namespace Server
{
    public class MyService : IMyService
    {
        private readonly Guid _id;

        public MyService()
        {
            _id = Guid.NewGuid();
            Console.WriteLine($"---- creating {_id}");
        }

        public string DoWork()
        {
            return _id.ToString();
        }
    }
}
