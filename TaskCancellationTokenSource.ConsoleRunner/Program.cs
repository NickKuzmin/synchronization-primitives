using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationTokenSource.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunCancellationTokenTask();
            RunParallelCancellationTokenTask();
        }

        private static void RunCancellationTokenTask()
        {
            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;
            var number = 6;

            var task = new Task(() =>
            {
                var result = 1;
                for (var i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {number} равен {result}");
                    Thread.Sleep(5000);
                }
            });
            task.Start();

            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            var input = Console.ReadLine();
            if (input == "Y")
                cancelTokenSource.Cancel();

            Console.Read();
        }

        public static void RunParallelCancellationTokenTask()
        {
            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            new Task(() =>
            {
                Thread.Sleep(400);
                cancelTokenSource.Cancel();
            }).Start();

            try
            {
                Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 },
                    new ParallelOptions
                    {
                        CancellationToken = token
                    }, x =>
                    {
                        var result = 1;
                        for (var i = 1; i <= x; i++)
                        {
                            result *= i;
                        }

                        Console.WriteLine($"Факториал числа {x} равен {result}");
                        Thread.Sleep(3000);
                    });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            Console.ReadLine();
        }
    }
}
