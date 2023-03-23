namespace ConsoleApp_Semaphore_2
{
    internal class Program
    {
        static Semaphore sem1 = new Semaphore(0, 1);

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Thread1Work);
            thread1.Start();

            Thread thread2 = new Thread(Thread2Work);
            thread2.Start();


        }

        static void Thread1Work()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }

            sem1.Release(); // when it is in comment Thread2 wont work
        }

        static void Thread2Work()
        {
            sem1.WaitOne(); // waits sem1's first argument to be 1.

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }
    }
}