using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading.ConsoleRunner
{
    /*
     * Thread life cycle: Request Calls -> Thread Object -> Memory Resource -> Execution -> ThreadPool
     * ThreadPool life cycle: Request Calls -> Execution -> Thread Pool
     *
     */
    public class ThreadPoolPerformance
    {
        public static void Execute()
        {
            for (var i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
                MethodWithTask();
            }

            var stopwatch = new Stopwatch();
            Console.WriteLine("Execution using Thread");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThread is : " + stopwatch.ElapsedTicks);

            stopwatch.Reset();
            Console.WriteLine("Execution using Thread Pool");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThreadPool is : " + stopwatch.ElapsedTicks);

            stopwatch.Reset();
            Console.WriteLine("Execution using Task");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithTask is : " + stopwatch.ElapsedTicks);

            Console.Read();
        }
        public static void MethodWithThread()
        {
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(Test);
                thread.Start();
            }
        }

        public static void MethodWithThreadPool()
        {
            for (var i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Test);
            }
        }

        public static void MethodWithTask()
        {
            for (var i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(TestWithoutArguments);
            }
        }

        public static void Test(object obj)
        {
        }

        public static void TestWithoutArguments()
        {
        }
    }
}
