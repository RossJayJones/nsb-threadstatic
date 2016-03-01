using NServiceBus;

namespace Messages
{
    public class Say : IMessage
    {
        public string Words { get; set; }
    }
}
