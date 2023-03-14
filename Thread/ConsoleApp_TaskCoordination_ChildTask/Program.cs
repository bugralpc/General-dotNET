namespace ConsoleApp_TaskCoordination_ChildTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                var child = new Task(() =>
                {
                    Console.WriteLine("Child task starting");
                    Thread.Sleep(3000);
                    Console.WriteLine("Child task finishing");
                    //throw new Exception(); // ---------------> Important
                }, TaskCreationOptions.AttachedToParent);

                var completionHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Hooray, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                var failHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Ooops, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

                child.Start();
            });

            // AttachedToParent, they form a parent child relationshipd and as a result, parent
            // task waits its child to finish. !!!!!


            parent.Start();

            try
            {
                parent.Wait();

            }
            catch(AggregateException ae)
            {
                ae.Handle(e => true);
            }
        }
    }
}