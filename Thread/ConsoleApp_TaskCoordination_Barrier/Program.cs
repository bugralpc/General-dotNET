namespace ConsoleApp_TaskCoordination_Barrier
{
    internal class Program
    {
        static Barrier barrier = new Barrier(2, b =>
        {
            Console.WriteLine("Phase " + b.CurrentPhaseNumber + " is finished");
            
        });

        static void Main(string[] args)
        {
            var water = Task.Factory.StartNew(Water);
            var cup = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup }, tasks =>
            {
                Console.WriteLine("Enjoy your cup of tea");
            });

            tea.Wait();
        }

        public static void Water()
        {
            Console.WriteLine("Putting the kettle on");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("Pourint water into cup.");
            barrier.SignalAndWait();
            Console.WriteLine("Putting the kettle away");
        }

        public static void Cup()
        {
            Console.WriteLine("Finding the nicest cup of tea");
            barrier.SignalAndWait();
            Console.WriteLine("Adding Tea");
            barrier.SignalAndWait();
            Console.WriteLine("Adding sugar");
        }
    }
}