using System;

namespace Mutex.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutex = new System.Threading.Mutex(false, @"Global\" + Guid.Empty);
            if (mutex.WaitOne(0, false))
            {
                Console.WriteLine("First load!");
            }
            else
            {
                Console.WriteLine("Instance already running");
            }

            Console.ReadKey();
        }
    }
}
