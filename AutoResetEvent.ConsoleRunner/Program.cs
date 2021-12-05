using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEvent.ConsoleRunner
{
    public class Program
    {
        private static readonly System.Threading.AutoResetEvent WaitHandler = new System.Threading.AutoResetEvent(true);
        private static int _counter = 0;

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

        public static void Count()
        {
            WaitHandler.WaitOne();
            _counter = 1;
            for (var i = 1; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_counter}");
                _counter++;
                Thread.Sleep(100);
            }

            WaitHandler.Set();
        }
    }
}
