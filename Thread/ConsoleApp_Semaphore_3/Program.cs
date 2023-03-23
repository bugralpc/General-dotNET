namespace ConsoleApp_Semaphore_3
{
    internal class Program
    {
        static Semaphore sem1 = new Semaphore(1, 1);
        static Semaphore sem2 = new Semaphore(0, 1);
        static Semaphore sem3 = new Semaphore(0, 1);

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Thread1Work);
            t1.Start();

            Thread t2 = new Thread(Thread2Work);
            t2.Start();

            Thread t3 = new Thread(Thread3Work);
            t3.Start();


        }

        static void Thread1Work()
        {
            sem1.WaitOne(); // when waitone it decreases first argument of sem2

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }

            sem2.Release(); // when release it increases first argument of sem2
        }

        static void Thread2Work()
        {
            sem2.WaitOne();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }

            sem3.Release();
        }

        static void Thread3Work()
        {
            sem3.WaitOne();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }
    }
}