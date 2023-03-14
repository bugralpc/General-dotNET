namespace ConsoleApp_TaskCoordination_ManuelAutoResetEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mre = new ManualResetEventSlim();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine( "Boiling water");
                mre.Set();
            });

            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water");
                mre.Wait(); // it has input as time-out remember
                // when mre.Set() mre.Wait() is unblocked
                // you need to set again by hand.
                Console.WriteLine("Here is your tea");
            });

            makeTea.Wait();

            Console.WriteLine();

            var are = new AutoResetEvent(false);

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 1");
                are.Set();
            });

            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 2 waiting");
                are.WaitOne();
                Console.WriteLine("Task 2 done");
                //are.WaitOne();// never gets here needed to be signalled again.
                var ok = are.WaitOne(1000);

                if (ok)
                {
                    Console.WriteLine("Singalled");
                }
                else
                {
                    Console.WriteLine("Not Signalled");
                }

            });

            task.Wait();


        }
    }
}