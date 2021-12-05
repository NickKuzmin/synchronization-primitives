using System;

namespace Multithreading.ConsoleRunner
{
    /*
     * The Task class will be the easier-to-use
     * as it offers a very clean interface for starting and joining threads and transfers exceptions.
     * It also supports a (limited) form of load balancing.
     *
     * ThreadPool is basically help to manage and reuse the free threads.
     * In other words a threadpool is the collection of background thread.
     *
     * Task work asynchronously manages the the unit of work. In easy words Task doesn’t create new threads.
     * Instead it efficiently manages the threads of a threadpool.
     * Tasks are executed by TaskScheduler, which queues tasks onto threads.
     *
     * Thread life cycle: Request Calls -> Thread Object -> Memory Resource -> Execution -> ThreadPool
     * ThreadPool life cycle: Request Calls -> Execution -> Thread Pool
     *
     * ThreadPool: NOT COMPILED. Only "void MethodName(object) signature.
     */
    public class Program
    {
        public static void Main()
        {
            // ThreadPoolFastAndLongOperationsSample.Execute();
            // ThreadPoolSample.Execute();
            ThreadPoolPerformance.Execute();
            TaskSample.Execute();

            Console.ReadLine();
        }
    }
}
