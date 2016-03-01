namespace Server
{
    public class MyOtherService : IMyOtherService
    {
        private readonly IMyService _myService;
        public MyOtherService(IMyService myService)
        {
            _myService = myService;
        }

        public string DoWork()
        {
            return _myService.DoWork();
        }
    }
}
