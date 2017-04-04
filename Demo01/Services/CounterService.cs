namespace Demo01.Services
{
    public class CounterService : ICounterService
    {
        private int _counter = 0;

        public int GetCounter()
        {
            return _counter;
        }

        public void IncrementCounter()
        {
            _counter++;
        }
    }
}