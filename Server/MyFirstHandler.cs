using System;
using Messages;
using NServiceBus;

namespace Server
{
    public class MyFirstHandler : IHandleMessages<Say>
    {
        private readonly IMyService _myService;

        private readonly IMyOtherService _myOtherService;

        public MyFirstHandler(IMyService myService, IMyOtherService myOtherService)
        {
            _myService = myService;
            _myOtherService = myOtherService;
        }

        public void Handle(Say message)
        {
            Console.WriteLine($"FirstHandler -> {message.Words}");
            Console.WriteLine($"FirstHandler -> MyService: {_myService.DoWork()}");
            Console.WriteLine($"FirstHandler -> MyOtherService: {_myOtherService.DoWork()}");
        }
    }
}
