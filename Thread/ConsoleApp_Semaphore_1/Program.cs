namespace ConsoleApp_Semaphore_1
{
    internal class Program
    {
        static Thread[] threads = new Thread[2];
        static Semaphore semaphore = new Semaphore(1, 1);

        static Thread[] threads2 = new Thread[3];
        static Semaphore semaphore2 = new Semaphore(2, 2);

        static void Main(string[] args)
        {
            for(int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(DoSomething);
                threads[i].Name = "Thread Number " + i;
                threads[i].Start();
            }

            Console.ReadKey();
            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            for (int i = 0; i < threads2.Length; i++)
            {
                threads2[i] = new Thread(DoSomething2);
                threads2[i].Name = "thread number " + i;
                threads2[i].Start();
            }

        }

        static void DoSomething()
        {
            Console.WriteLine("{0} => waiting", Thread.CurrentThread.Name);
            Thread.Sleep(200);
            semaphore.WaitOne();
            Console.WriteLine("{0} => begins!", Thread.CurrentThread.Name);
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0} => executes {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep(200);
            }
            Console.WriteLine("{0} => releasing... ", Thread.CurrentThread.Name);
            semaphore.Release();
        }

        static void DoSomething2()
        {
            Console.WriteLine("{0} => waiting", Thread.CurrentThread.Name);
            Thread.Sleep(200);
            semaphore2.WaitOne();
            Console.WriteLine("{0} => begins!", Thread.CurrentThread.Name);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0} => executes {1}", Thread.CurrentThread.Name, i);
                Thread.Sleep(200);
            }
            Console.WriteLine("{0} => releasing... ", Thread.CurrentThread.Name);
            semaphore2.Release();
        }

    }
}