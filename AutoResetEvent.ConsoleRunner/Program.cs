using System;
using System.Threading;

namespace AutoResetEvent.ConsoleRunner
{
    /*************************************
    private static readonly System.Threading.AutoResetEvent WaitHandler = new System.Threading.AutoResetEvent(true);

    WaitHandler.WaitOne();
    // THREAD-SAFE-WORK
    WaitHandler.Set();
    **************************************/

    public class Program
    {
        private static readonly System.Threading.AutoResetEvent WaitHandler = new System.Threading.AutoResetEvent(true);
        private static int _counter;

        public static void Main(string[] args)
        {
            for (var i = 1; i < 6; i++)
            {
                var myThread = new Thread(Count)
                {
                    Name = $"Thread {i}"
                };
                myThread.Start();
            }

            Console.ReadLine();
        }

        public static void Count()
        {
            WaitHandler.WaitOne();
            _counter = 1;
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                _counter++;
                Thread.Sleep(100);
            }

            WaitHandler.Set();
        }
    }
}
