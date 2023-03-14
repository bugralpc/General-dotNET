using System.Collections.Concurrent;

namespace ConsoleApp_ConsumerProducerDesignPattern_1
{
    // Consumer-Producer Design Pattern examples.

    internal class Program
    {
        static BlockingCollection<int> queue = new BlockingCollection<int>(boundedCapacity: 10);

        static TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        static void Main(string[] args)
        {
            // Producer task
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Add(i);
                    Thread.Sleep(300);
                }
                queue.CompleteAdding();
            });

            // Consumer task
            Task.Run(() =>
            {
                foreach (int item in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine(item);
                }
            });

            Console.ReadKey();

            // Producer task
            Task.Run(() =>
            {
                int result = 42; // Some long-running operation
                tcs.SetResult(result);
            });

            // Consumer task
            Task.Run(async () =>
            {
                int result = await tcs.Task;
                Console.WriteLine(result);
            });

            Console.ReadKey();

        }
    }
}