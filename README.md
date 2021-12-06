- **Процесс (Process)** — объект ОС, изолированное адресное пространство, содержит потоки.
- **Поток (Thread)** — объект ОС, наименьшая единица выполнения, часть процесса, потоки делят память и другие ресурсы между собой в рамках процесса.
- **Многозадачность** — свойство ОС, возможность выполнять несколько процессов одновременно
- **Многоядерность** — свойство процессора, возможность использовать несколько ядер для обработки данных
- **Многопроцессорность** — свойство компьютера, возможность одновременно работать с несколькими процессорами физически
- **Многопоточность** — свойство процесса, возможность распределять обработку данных между несколькими потоками.
- **Параллельность** — выполнение нескольких действий физически одновременно в единицу времени
- **Асинхронность** — выполнение операции без ожидания окончания завершения этой обработки, результат же выполнения может быть обработан позднее.
---------------------------------------------------
**AutoResetEvent:**

```
System.Threading.AutoResetEvent WaitHandler = new System.Threading.AutoResetEvent(true);

WaitHandler.WaitOne();
// THREAD-SAFE-WORK
WaitHandler.Set();
```
---------------------------------------------------
**Lock:**
```
private static readonly object Locker = new object();

lock (Locker)
{
   // THREAD-SAFE-WORK
}
```
---------------------------------------------------
**Monitor:**
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
---------------------------------------------------
**Monitor:**
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
---------------------------------------------------
**Mutex:**
```
private static readonly Mutex Mutex = new Mutex();

Mutex.WaitOne();
// THREAD-SAFE-WORK
Mutex.ReleaseMutex();
```
---------------------------------------------------
**Semaphore:**
```
private static readonly System.Threading.Semaphore Semaphore = new System.Threading.Semaphore(5, 5);

Semaphore.WaitOne();
Interlocked.Increment(ref _count);
// THREAD-SAFE-WORK
Interlocked.Decrement(ref _count);
Semaphore.Release();
```
