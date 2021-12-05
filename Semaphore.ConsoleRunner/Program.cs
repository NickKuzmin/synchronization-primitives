using System;
using System.Threading;

namespace Semaphore.ConsoleRunner
{
    public class Program
    {
        private static int _count;
        private static readonly System.Threading.Semaphore Semaphore = new System.Threading.Semaphore(5, 5);

        public static void Main(string[] args)
        {
            for (var i = 1; i < 10; i++)
            {
                var thread = new Thread(Work)
                {
                    Name = $"Worker {i}"
                };
                thread.Start();
            }

            Console.ReadLine();
        }

        private static void Work()
        {
            Semaphore.WaitOne();

            Interlocked.Increment(ref _count);

            Console.WriteLine($"{Thread.CurrentThread.Name} starting... Now working {_count}");

            Thread.Sleep(new Random().Next(500, 1000));

            Console.WriteLine($"{Thread.CurrentThread.Name} finishing.. Now working {_count}");

            Interlocked.Decrement(ref _count);

            Semaphore.Release();
        }
    }
}
