using System;
using System.Threading;

namespace Multithreading.ConsoleRunner
{
    public class ThreadPoolFastAndLongOperationsSample
    {
        public static void Execute()
        {
            ThreadPool.GetMaxThreads(out var workerThreadsCount, out var completionThreadsCount);
            Console.WriteLine("Максимальное количество потоков: " + workerThreadsCount
                + "\nПотоков ввода-вывода доступно: " + completionThreadsCount);

            Console.WriteLine("Small amount of threads for fast operations:");
            for (var i = 0; i < 50; i++)
                ThreadPool.QueueUserWorkItem(JobForAThreadWithFastOperations);

            Console.WriteLine("Big amount of threads for long operations:");
            for (var i = 0; i < 50; i++)
                ThreadPool.QueueUserWorkItem(JobForAThreadWithLongOperations);

            Console.ReadLine();
        }

        private static void JobForAThreadWithFastOperations(object state)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("Fast: цикл {0}, выполнение внутри потока из пула {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }

        private static void JobForAThreadWithLongOperations(object state)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("Long: цикл {0}, выполнение внутри потока из пула {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
            }
        }
    }
}
