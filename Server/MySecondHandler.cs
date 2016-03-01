using System;
using Messages;
using NServiceBus;

namespace Server
{
    public class MySecondHandler : IHandleMessages<Say>
    {
        private readonly IMyService _myService;

        private readonly IMyOtherService _myOtherService;

        public MySecondHandler(IMyService myService, IMyOtherService myOtherService)
        {
            _myService = myService;
            _myOtherService = myOtherService;
        }

        public void Handle(Say message)
        {
            Console.WriteLine($"SecondHandler -> {message.Words}");
            Console.WriteLine($"SecondHandler -> MyService: {_myService.DoWork()}");
            Console.WriteLine($"SecondHandler -> MyOtherService: {_myOtherService.DoWork()}");
        }
    }
}