```
System.Threading.AutoResetEvent WaitHandler = new System.Threading.AutoResetEvent(true);

WaitHandler.WaitOne();
// THREAD-SAFE-WORK
WaitHandler.Set();
```

```
private static readonly object Locker = new object();

lock (Locker)
{
   // THREAD-SAFE-WORK
}
```

```
private static readonly object Locker = new object();

try
{
    System.Threading.Monitor.Enter(Locker);
    // THREAD-SAFE-WORK
}
finally
{
    System.Threading.Monitor.Exit(Locker);
}
```

```
private static readonly object Locker = new object();

var acquiredLock = false;
try
{
    System.Threading.Monitor.Enter(Locker, ref acquiredLock);
    // THREAD-SAFE-WORK
}
finally
{
    if (acquiredLock)
    {
        System.Threading.Monitor.Exit(Locker);
    }
}
```

```
private static readonly Mutex Mutex = new Mutex();

Mutex.WaitOne();
// THREAD-SAFE-WORK
Mutex.ReleaseMutex();
```

```
private static readonly System.Threading.Semaphore Semaphore = new System.Threading.Semaphore(5, 5);

Semaphore.WaitOne();
Interlocked.Increment(ref _count);
// THREAD-SAFE-WORK
Interlocked.Decrement(ref _count);
Semaphore.Release();
```