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
            Task.Run(TaskRunSampleAsync).Wait();

            TaskRunSampleWithWarning();
        }

        private static void ContinueWithSample()
        {
            Task.Run(DoWork).ContinueWith(x => { Task.Run(DoWork2); });

            Task.Factory.StartNew(DoWork).ContinueWith(x => { Task.Factory.StartNew(DoWork); });

            var task = new Task(() => DoWork());
            task.Start();

            task = new Task(DoWork);
            task.Start();

            var taskArgument = new TaskArgument
            {
                Name = typeof(TaskArgument).AssemblyQualifiedName
            };
            task = new Task(DoWorkWithParameter, taskArgument);
            task.Start();

            task = new Task((@object) => DoWorkWithParameter(@object), taskArgument);
            task.Start();
        }

        private static void TaskApiSample()
        {
            Task.Run(DoWork);
            Task.Factory.StartNew(DoWork);

            var task = new Task(DoWork);
            task.Start();

            task = new Task(() => DoWork());
            task.Start();

            task = new Task(DoWork);
            task.RunSynchronously();

            var taskArgument = new TaskArgument
            {
                Name = typeof(TaskArgument).AssemblyQualifiedName
            };
            task = new Task(DoWorkWithParameter, taskArgument);
            task.Start();

            task = new Task((@object) => DoWorkWithParameter(@object), taskArgument);
            task.Start();
        }

        private static async void TaskRunSampleAsync()
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

        private static void DoWorkWithParameter(object state)
        {
            var taskArgument = (TaskArgument)state;
        }

        private class TaskArgument
        {
            public string Name { get; set; }
        }
    }
}
