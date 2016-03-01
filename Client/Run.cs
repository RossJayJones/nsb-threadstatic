using System;
using Messages;
using NServiceBus;

namespace Client
{
    public class Run : IWantToRunWhenBusStartsAndStops
    {
        private readonly Schedule _schedule;

        private readonly IBus _bus;

        private int _counter;

        public Run(Schedule schedule, IBus bus)
        {
            _schedule = schedule;
            _bus = bus;
            _counter = 0;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Press any key to send a message...");
                Console.ReadLine();
                var message = new Say { Words = $"Hi! ({++_counter})" };
                _bus.Send("server", message);
            }
        }

        public void Stop()
        {

        }
    }
}
