using System;
using System.Threading;

namespace Locker.ConsoleRunner
{
    /*************************************
    private static readonly object Locker = new object();

    lock (Locker)
    {
       // THREAD-SAFE-WORK
    }
    **************************************/

    public class Program
    {
        private static readonly object Locker = new object();
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

        private static void Count()
        {
            lock (Locker)
            {
                _counter = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                    _counter++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
