using System;
using System.Threading;

namespace MutexThreads.ConsoleRunner
{
    /*************************************
    private static readonly Mutex Mutex = new Mutex();

    Mutex.WaitOne();
    // THREAD-SAFE-WORK
    Mutex.ReleaseMutex();
    **************************************/

    public class Program
    {
        private static readonly Mutex Mutex = new Mutex();
        private static int _counter;

        public static void Main(string[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                var myThread = new Thread(Count)
                {
                    Name = $"Thread {i}"
                };
                myThread.Start();
            }

            Console.ReadKey();
        }

        public static void Count()
        {
            Mutex.WaitOne();
            _counter = 1;
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                _counter++;
                Thread.Sleep(100);
            }

            Mutex.ReleaseMutex();
        }
    }
}
