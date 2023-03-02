namespace ConsoleApp_EventHandler_4
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Process += DoProcess1;

            // First run on Main Thread.
            DoWork1();

            Thread.Sleep(500);

            // Then run on Worker Thread.
            Thread thread = new Thread(() =>
            {
                DoWork1();
            });

            thread.Start();


        }

        public delegate void Notify();

        public static event Notify Process;

        public static void DoWork2()
        {
            Process?.Invoke();
        }

        public static void DoWork1()
        {
            for (int i = 0; i < 5; i++ )
            {
                Console.WriteLine("Current Thread => {0} ", Thread.CurrentThread.ManagedThreadId + " DoWork1 Method.");
            }

            DoWork2();
        }

        public static void DoProcess1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Current Thread => {0} ", Thread.CurrentThread.ManagedThreadId + " DoProcess1 Method");
            }
        }

    }
}