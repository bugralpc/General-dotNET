namespace ConsoleApp_ConsumerProducerDesignPattern_3
{
    class Program
    {
        static List<int> sharedList = new List<int>();
        static object lockObject = new object();
        static int maxSize = 10;

        static void Main()
        {
            // Create producer and consumer tasks
            Task producer = Task.Run(() => Producer());
            Task consumer = Task.Run(() => Consumer());

            // Wait for both tasks to complete
            Task.WaitAll(producer, consumer);

            Console.WriteLine("Done");
        }

        static void Producer()
        {
            Random random = new Random();

            while (true)
            {
                // Generate a random number between 1 and 100
                int number = random.Next(1, 101);

                lock (lockObject)
                {
                    // Add number to shared list if it is not full
                    if (sharedList.Count < maxSize)
                    {
                        sharedList.Add(number);
                        Console.WriteLine($"Added {number} to the list");
                    }
                }

                // Sleep for a random amount of time between 1 and 3 seconds
                Thread.Sleep(random.Next(1000, 3001));
            }
        }

        static void Consumer()
        {
            Random random = new Random();

            while (true)
            {
                lock (lockObject)
                {
                    // Remove the first element from the shared list if it is not empty
                    if (sharedList.Count > 0)
                    {
                        int number = sharedList[0];
                        sharedList.RemoveAt(0);
                        Console.WriteLine($"Removed {number} from the list");
                    }
                }

                // Sleep for a random amount of time between 1 and 3 seconds
                Thread.Sleep(random.Next(1000, 3001));
            }
        }
    }
}