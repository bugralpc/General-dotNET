namespace ConsoleApp_AsyncAwaitTask1
{
    internal class Program
    {
        // When you use Task.Wait() tasks run synchronously
        // When you use await tasks run asycnhronously

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId} ");

            // Running task asynchronously without blocking the caller thread
            // We use await for the task to complete without blocking the main thread.
            await Task.Run(() =>
            {
                Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(2000);
            });

            Console.WriteLine("Main thread resumed, task completed");

            // Running task synchronously and blocking the caller thread.
            var task = Task.Run(() =>
            {
                Console.WriteLine($"Task thread id: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
            });

            // to block the main thread and wait for the task to complete synchronously
            task.Wait();

            Console.WriteLine($"Main thread resumed, task completed");

            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");



        }


    }
}