using System.Collections.Concurrent;

namespace ConsoleApp_ConcurrentQueue_2
{
    // Procuder-Consumer Design Pattern Example
    internal class Program
    {
        static BlockingCollection<int> queue = new BlockingCollection<int>(boundedCapacity: 5);

        static void Main(string[] args)
        {
            // Producer
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Add(i);
                    Thread.Sleep(1000);
                }

                queue.CompleteAdding();
            });

            // Consumer
            Task.Run(() =>
            {
                foreach(int item in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine(item);
                }
                
            });


            Console.ReadKey();
        }
    }
}