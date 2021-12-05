using System;
using System.Threading;

namespace Monitor.ConsoleRunner
{
    /*************************************
    private static readonly object Locker = new object();

    try
    {
        System.Threading.Monitor.Enter(Locker);
        // THREAD-SAFE-WORK
    }
    finally
    {
        System.Threading.Monitor.Exit(Locker);
    }
    **************************************/

    /*************************************
    private static readonly object Locker = new object();

    var acquiredLock = false;
    try
    {
        System.Threading.Monitor.Enter(Locker, ref acquiredLock);
        // THREAD-SAFE-WORK
    }
    finally
    {
        if (acquiredLock)
        {
            System.Threading.Monitor.Exit(Locker);
        }
    }
    **************************************/

    public class Program
    {
        private static readonly object Locker = new object();
        private static int _counter;

        static void Main(string[] args)
        {
            for (var i = 1; i < 6; i++)
            {
                var threadWithoutMonitor = new Thread(CountWithoutMonitor)
                {
                    Name = $"Thread {i}"
                };
                // threadWithoutMonitor.Start();

                var threadWithoutLockTaken = new Thread(CountWithoutLockTaken)
                {
                    Name = $"Thread {i}"
                };
                threadWithoutLockTaken.Start();

                var threadWithLockTaken = new Thread(CountWithLockTaken)
                {
                    Name = $"Thread {i}"
                };
                // threadWithLockTaken.Start();
            }

            Console.ReadLine();
        }

        public static void CountWithoutMonitor()
        {
            _counter = 1;
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                _counter++;
                Thread.Sleep(100);
            }
        }

        public static void CountWithoutLockTaken()
        {
            try
            {
                System.Threading.Monitor.Enter(Locker);
                _counter = 1;
                for (var i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                    _counter++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(Locker);
            }
        }

        public static void CountWithLockTaken()
        {
            var acquiredLock = false;
            try
            {
                System.Threading.Monitor.Enter(Locker, ref acquiredLock);
                _counter = 1;
                for (var i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                    _counter++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (acquiredLock)
                {
                    System.Threading.Monitor.Exit(Locker);
                }
            }
        }
    }
}
