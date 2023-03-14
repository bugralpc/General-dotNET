using System.Collections.Concurrent;

namespace ConsoleApp_ConcurrentQueue_1
{
    // Producer-Consumer Design Pattern. Two taks are acting as producuers by adding elements to the queue
    // the third task is acting as the consumer by reading elements from the queue and pushing them to the console.

    internal class Program
    {

        static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Enqueue(i);
                    Console.WriteLine($"Task 1 added {i} to the queue");
                    Thread.Sleep(100); // Simulate some work
                }
            });

            Task.Factory.StartNew(() =>
            {
                for(int i = 10; i < 20; i++)
                {
                    // Add element to the queue
                    queue.Enqueue(i);
                    Console.WriteLine($"Task 2 added {i} to the queue");
                    Thread.Sleep(100); // Simulate some work
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    // Try to dequeue an element from the queue
                    if (queue.TryDequeue(out int element))
                    {
                        Console.WriteLine($"Task 3 dequeued {element} from the queue");
                    }
                    else
                    {
                        // If the queue is empty, wait for some time
                        Thread.Sleep(100);
                    }
                }
            });

            // Wait for all tasks to complete
            Task.WaitAll();

            //Console.ReadKey();

            Console.WriteLine("Count of queue is " + queue.Count);
        }
    }
}