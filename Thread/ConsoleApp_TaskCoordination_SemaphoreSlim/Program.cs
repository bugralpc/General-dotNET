namespace ConsoleApp_TaskCoordination_SemaphoreSlim
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var semaphore = new SemaphoreSlim(2, 10);
            // Remember these synchronization primatives, they all use a counter of some kind.
            // first argument is number of request can be granted concurrently
            // second argument is maximum number of request can be granted concurrently

            for(int i = 0; i < 20; i++)
            {

                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}");
                    semaphore.Wait(); // ReleaseCount --
                    Console.WriteLine($"Processing task {Task.CurrentId}");

                });

            }

            while(semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($" Semaphore count: {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2);
            }
        }
    }
}