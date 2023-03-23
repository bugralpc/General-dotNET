namespace ConsoleApp_Mutex_2
{
    internal class Program
    {
        static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            for(int i = 0; i < 4; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Start();
            }


        }

        static void DoWork()
        {
            mutex.WaitOne();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }

            mutex.ReleaseMutex();
        }
    }
}