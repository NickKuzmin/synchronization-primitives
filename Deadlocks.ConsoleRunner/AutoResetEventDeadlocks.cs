using System;
using System.Threading;

namespace Deadlocks.ConsoleRunner
{
    public class AutoResetEventDeadlocks
    {
        private static readonly AutoResetEvent WaitHandler = new AutoResetEvent(true);

        public static void Execute()
        {
            Console.WriteLine("Deadlock demo. Please check where threads are stuck.");

            for (var i = 0; i < 3; i++)
            {
                WaitHandler.WaitOne();
                WaitHandler.Set();
            }

            Console.WriteLine("This will not be in output");

            Console.ReadLine();
        }
    }
}
