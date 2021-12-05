using System;
using System.Threading;

namespace Deadlocks.ConsoleRunner
{
    /*************************************
    public static void First()
    {
        lock (LockerOne)
        {
            lock (LockerTwo)
            {
                 Console.WriteLine("This will not be in output");
            }
        }
    }

    public static void Second()
    {
        lock (LockerTwo)
        {
            lock (LockerOne)
            {
                 Console.WriteLine("This will not be in output");
            }
        }
    }
    *************************************/

    public class Program
    {
        private static readonly object LockerOne = new object();
        private static readonly object LockerTwo = new object();

        public static void Main()
        {
            var thread1 = new Thread(First);
            var thread2 = new Thread(Second);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Deadlock demo. Please check where threads are stuck.");
            Console.ReadLine();
        }

        public static void First()
        {
            Console.WriteLine("First: Before LockerOne");
            lock (LockerOne)
            {
                Console.WriteLine("First: Before LockerTwo");
                Thread.Sleep(1000);
                lock (LockerTwo)
                {
                    Console.WriteLine("This will not be in output");
                }
            }

            Console.WriteLine("This will not be in output");
        }

        public static void Second()
        {
            Console.WriteLine("Second: Before LockerTwo");
            lock (LockerTwo)
            {
                Console.WriteLine("Second: Before LockerOne");
                Thread.Sleep(1000);
                lock (LockerOne)
                {
                    Console.WriteLine("This will not be in output");
                }
            }

            Console.WriteLine("This will not be in output");
        }
    }
}
