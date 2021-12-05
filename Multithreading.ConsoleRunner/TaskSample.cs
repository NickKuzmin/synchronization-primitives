using System.Threading.Tasks;

namespace Multithreading.ConsoleRunner
{
    public class TaskSample
    {
        public static void Execute()
        {
            ContinueWithSample();

            /*
             * Sync mode execution for async-method
             */
            Task.Run(TaskRunSample).Wait();

            TaskRunSampleWithWarning();
        }

        private static void ContinueWithSample()
        {
            Task.Run(DoWork).ContinueWith(x =>
            {
                Task.Run(DoWork2);
            });

            Task.Factory.StartNew(DoWork).ContinueWith(x =>
            {
                Task.Factory.StartNew(DoWork);
            });
        }

        private static async void TaskRunSample()
        {
            await Task.Run(DoWork);

            await Task.Factory.StartNew(DoWork);
        }

        private static async void TaskRunSampleWithWarning()
        {
            Task.Run(DoWork);

            Task.Factory.StartNew(DoWork);
        }

        private static void DoWork()
        {
        }

        private static void DoWork2()
        {
        }
    }
}
