namespace ConsoleApp_CreatingStartingTask
{

    internal class Program
    {
        private static string line = "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \n\n";
        public class Person
        {
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3 };

            Console.WriteLine("Array arr1: " + arr1[0] + " " + arr1[1] + " " + arr1[2]);

            Task<int> task1 = new Task<int>(() =>
            {
                return Method1(arr1);
            });

            task1.Start();

            task1.Wait();

            Console.WriteLine("Result of Task1 {0}", task1.Result);
            Console.WriteLine("Array is passed as Reference Type");
            Console.WriteLine("Array arr1: " + arr1[0] + " " + arr1[1] + " " + arr1[2]);
            Console.WriteLine(line);

            Person person = new Person() { Name = "Aragorn" };

            Task task2 = new Task(Method2, person);
            Console.WriteLine("Person object name: " + person.Name);

            task2.Start();

            task2.Wait();
            Console.WriteLine("Person object is passed as Reference Type");
            Console.WriteLine("Person object name: " + person.Name);
            Console.WriteLine(line);

            Console.WriteLine("Wait task3 and task4 to finish");
            Task task3 = Task.Factory.StartNew(() =>
            {
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                }
            });

            Task task4 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(500);
                }
            });

            Task.WaitAll(task3, task4);
            Console.WriteLine("task3 and task4 finished");
            Console.WriteLine(line);

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var task5 = new Task(() =>
            {
                for(int i = 0; i < 20; i++)
                {
                    Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(400);

                    token.ThrowIfCancellationRequested();
                }
            }, token);

            
            Console.WriteLine("Press Key to stop task5");
            task5.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine(line);

            var cts1 = new CancellationTokenSource();
            var token1 = cts1.Token;

            var task6 = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                if(cancelled)
                {
                    Console.WriteLine("Bomb disarmed");
                }
                else
                {
                    Console.WriteLine("BOOM!");
                }
            }, token1);

            task6.Start();

            Console.ReadKey();
            cts1.Cancel();
        }

        private static int Method1(int[] arr)
        {
            int sum = 0;

            foreach(int num in arr)
            {
                sum += num;
                Thread.Sleep(250);
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
            }

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] += 1000;
            }

            return sum;
        }
     
        private static void Method2(object obj)
        {
            Person person = obj as Person;

            Thread.Sleep(250);
            person.Name = "Sauron";

            Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
        }


    }
}