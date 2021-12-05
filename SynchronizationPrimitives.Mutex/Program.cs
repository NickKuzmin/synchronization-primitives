using System;

namespace SynchronizationPrimitives.Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutex = new System.Threading.Mutex(false, @"Global\" + Guid.Empty);
            GC.KeepAlive(mutex);

            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("Instance already running");
            }
            else
            {
                Console.WriteLine("First load!");
            }

            Console.ReadKey();
        }
    }
}
