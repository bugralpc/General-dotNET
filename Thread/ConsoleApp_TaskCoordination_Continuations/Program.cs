namespace ConsoleApp_TaskCoordination_Continuations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water");
                Thread.Sleep(3000);
            });

            var task2 = task.ContinueWith(t =>
            {
                Console.WriteLine($"Completed task {t.Id}, pour water into the cup");
            });

            task2.Wait();


            var task3 = Task.Factory.StartNew(() => "Task3");
            var task4 = Task.Factory.StartNew(() => "Task4");

            var task5 = Task.Factory.ContinueWhenAll(new[] { task3, task4 },
                tasks =>
                {
                    Console.WriteLine("Tasks completed");
                    foreach (var t in tasks)
                    {
                        Console.WriteLine(t.Result);
                    }
                    Console.WriteLine("All tasks done");

                });

            task5.Wait();
        }

    }
}