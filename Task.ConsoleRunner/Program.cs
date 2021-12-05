using System;
using System.Threading;

namespace Task.ConsoleRunner
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main2(string[] args)
        {
            Console.WriteLine("---------------------------");
            await RunAsynchronouslyAsync();
        }

        public static void Main(string[] args)
        {
            RunSynchronously();

            Console.WriteLine("---------------------------");

            RunAsynchronously();

            /*
             * Не дожидается выполнения таски
             */
            // Console.WriteLine("---------------------------");
            // RunAsynchronouslyAsync();

            Console.WriteLine("---------------------------");
            System.Threading.Tasks.Task.Run(RunAsynchronouslyAsync).Wait();

            //Console.ReadLine();
        }

        private static void RunSynchronously()
        {
            Console.WriteLine("RunSynchronously");
            var task = new System.Threading.Tasks.Task(Display);
            task.Start();

            /*
             * Synchronously
             */
            task.Wait();

            Console.WriteLine("Завершение метода Main");
        }

        private static void RunAsynchronously()
        {
            Console.WriteLine("RunAsynchronously");
            var task = new System.Threading.Tasks.Task(Display);
            task.Start();

            Console.WriteLine("Завершение метода Main");
        }

        private static async System.Threading.Tasks.Task RunAsynchronouslyAsync()
        {
            Console.WriteLine("RunAsynchronouslyAsync");
            await new System.Threading.Tasks.Task(() =>
            {
                Thread.Sleep(5000);
                Display();
                Console.WriteLine("Завершение метода Main");
            });

            Console.ReadKey();
        }

        private static void Display()
        {
            Console.WriteLine("Начало работы метода Display");

            Console.WriteLine("Завершение работы метода Display");
        }
    }
}
