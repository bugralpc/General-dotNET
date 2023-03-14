namespace ConsoleApp_ConsumerProducerDesignPattern_2
{
    // Consumer-Producer Design Pattern Example
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            object lockObj = new object();

            // Producer task
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    lock (lockObj)
                    {
                        queue.Enqueue(i);
                        Monitor.Pulse(lockObj);
                    }
                }
            });

            // Consumer task
            Task.Run(() =>
            {
                while (true)
                {
                    int item;
                    lock (lockObj)
                    {
                        while (queue.Count == 0)
                        {
                            Monitor.Wait(lockObj);
                        }
                        item = queue.Dequeue();
                    }
                    Console.WriteLine(item);
                }
            });

            Console.ReadKey();


        }
    }
}