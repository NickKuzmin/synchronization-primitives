using System;
using System.Threading;

namespace Multithreading.ConsoleRunner
{
    /*
     * ThreadPool: NOT COMPILED. Only "void MethodName(object) signature.
     *
     */

    public class ThreadPoolSample
    {
        public static void Execute()
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine("Выполнение внутри потока из пула {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
            });

            ThreadPool.QueueUserWorkItem(DoWork);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));

            const int counter = 5;
            /*
             * ThreadPool: NOT COMPILED. Only "void MethodName(object) signature.
             * ThreadPool.QueueUserWorkItem(DoWorkOneParameter, new object[] {counter});
             */

            const string text = "text";
            const double factor = 1.5;
            /*
             * NOT COMPILED. Only "void MethodName(object) signature.
             * ThreadPool.QueueUserWorkItem(DoWorkMultipleParameters, new object[] { counter, text, factor });
             */
        }

        public static void DoWork(object state)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }

        public static void DoWorkZeroParameters(object state)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }

        public static void DoWorkOneParameter(object state, int counter)
        {
            for (var i = 0; i < counter; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1} with counter {2}",
                    i, Thread.CurrentThread.ManagedThreadId, counter);
                Thread.Sleep(50);
            }
        }

        public static void DoWorkMultipleParameters(object state, int counter, string text, double factor)
        {
            for (var i = 0; i < counter; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1} with text {2} and factor {3}",
                    i, Thread.CurrentThread.ManagedThreadId, text, factor);
                Thread.Sleep(50);
            }
        }
    }
}
