namespace ConsoleApp_TaskCoordination_CountdownEvent
{
    internal class Program
    {
        private static int taskCount = 5;

        static CountdownEvent cte = new CountdownEvent(taskCount);

        static Random random = new Random();

        static void Main(string[] args)
        {
            
            // Barrier => signal and wait

            for (int i = 0; i < taskCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal(); // taking the countdown by one 
                    Console.WriteLine($"Exiting Task {Task.CurrentId}");
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Waiting for other tasks complete in {Task.CurrentId}");
                cte.Wait(); // it blocks the entire thread until countdown reaches 0
                // we have to wait every thread to singal, when cte reaches zero below codes are unlocked
                Console.WriteLine("All tasks completed");
            });

            finalTask.Wait();

            // The main logic cte needs to be zero to unclok cte.Wait() method.
            // cte.Wait() blocks the thread it is inside

        }
    }
}