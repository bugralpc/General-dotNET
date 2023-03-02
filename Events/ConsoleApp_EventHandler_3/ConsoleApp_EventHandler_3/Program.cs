namespace ConsoleApp_EventHandler_3
{
    public delegate void Notify(); // delegate

    public class ProcessBusinessLogic 
    {
        public event Notify Process; // Declare an event in publisher class

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");

            // if Process is not null then call delegate
            Process?.Invoke();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // The program class is a subscriver of the Process event. It register with the event using += operator

            // ProcessBusinessLogic class is called the publisher.
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();

            // all the event handler methods registered with the Process event.
            processBusinessLogic.Process += Method1;
            processBusinessLogic.Process += Method2;

            // raising the Process event.
            processBusinessLogic.StartProcess();


        }

        private static void Method1()
        {
            Console.WriteLine("Process1 completed");
        }
        private static void Method2()
        {
            Console.WriteLine("Process2 completed");
        }
    }
}