namespace ConsoleApp_TaskExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Cant do this") { Source = "task1" };
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Cant do this") { Source = "task2" };
            });

            try
            {
                Task.WaitAll(task1, task2);
            }
            catch(AggregateException ae)
            {
                foreach(var e in ae.InnerExceptions)
                {
                    Console.WriteLine("Exception {0} from {1}", e.GetType(), e.Source);
                }
            }

            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \n\n");

            try
            {
                Test();
            }
            catch(AggregateException ae)
            {
                foreach(var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"Handled elsewhere: {e.GetType()}");
                }
            }
            
        }

        private static void Test()
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Cant do this") { Source = "task1" };
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Cant do this") { Source = "task2" };
            });

            try
            {
                Task.WaitAll(task1, task2);
            }
            catch(AggregateException ae)
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }

        }
    }
}