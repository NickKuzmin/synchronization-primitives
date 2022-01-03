using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.ConsoleRunner
{
    class Program
    {
        public enum AsyncType
        {
            TAP,
            EAP,
            APM
        }

        static void Main(string[] args)
        {
            var type = AsyncType.TAP;
            if (type == AsyncType.TAP)
            {
                var task = Task.Run(async () => await LongAsyncOperation(5, 2, new[] { 2, 5, 6 }));
                Console.WriteLine("After task");
                task.Wait();
                Console.ReadKey();
            }
            else if (type == AsyncType.EAP)
            {

            }
            else if (type == AsyncType.APM)
            {
                IAsyncResult result = AsynchronousProgrammingModelPattern.BeginLongAsyncOperation(5, 2, new[] {2, 5, 6});
                AsynchronousProgrammingModelPattern.EndLongAsyncOperation(result);
            }
        }

        private static async Task<int> LongAsyncOperation(int count, int factor, int[] array)
        {
            await Task.Delay(5000);
            Console.WriteLine("Task completed");

            return count * factor * array.Length * 5;
        }

        public class AsynchronousProgrammingModelPattern
        {
            private delegate int DelegateApm(int count, int factor, int[] array);

            private static readonly DelegateApm Delegate = LongAsyncOperation;

            public static IAsyncResult BeginLongAsyncOperation(int count, int factor, int[] array)
            {
                return Delegate.BeginInvoke(count, factor, array, null, null);
            }
                
            public static void EndLongAsyncOperation(IAsyncResult result)
            {
                Delegate.EndInvoke(result);
            }

            private static int LongAsyncOperation(int count, int factor, int[] array)
            {
                Thread.Sleep(5000);
                return count * factor * array.Length * 5;
            }
        }
    }
}
