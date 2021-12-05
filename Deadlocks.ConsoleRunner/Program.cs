namespace Deadlocks.ConsoleRunner
{
    /*************************************
    public static void First()
    {
        lock (LockerOne)
        {
            lock (LockerTwo)
            {
                 Console.WriteLine("This will not be in output");
            }
        }
    }

    public static void Second()
    {
        lock (LockerTwo)
        {
            lock (LockerOne)
            {
                 Console.WriteLine("This will not be in output");
            }
        }
    }
    *************************************/

    /*************************************
     private static readonly AutoResetEvent WaitHandler = new AutoResetEvent(true);

    for (var i = 0; i < 3; i++)
    {
        WaitHandler.WaitOne();
        if (i == 1)
            continue;

        WaitHandler.Set();
    }

    Console.WriteLine("This will not be in output");
     */

    public class Program
    {
        public static void Main()
        {
            AutoResetEventDeadlocks.Execute();
            LockerDeadlocks.Execute();
        }
    }
}
