using System.Threading;

namespace Demo.Selenium.Functional.Tests.Helpers
{
    public static class ThreadSleepHelper
    {
        public static void Wait(int ms = 0)
        {
            Thread.Sleep(ms);
        }
    }
}
