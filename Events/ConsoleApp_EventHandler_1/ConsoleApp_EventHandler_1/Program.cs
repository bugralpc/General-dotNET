namespace ConsoleApp_EventHandler_1
{

    // public delegate void EventHandler(object sender, EventArgs e);
    // C# provides you with the standard EventHandler delegate type.
    // the sender holds a reference to the object that raised the event
    // EventArgs object hold sthe state information

    // It’s important to understand that the EventArgs is designed for event handlers
    // that do not need to pass data from the publisher to subscribers. If you want to pass the data,
    // you need to define a class derived from the EventArgs class.

    public delegate void EventHandler(object sender, EventArgs e);

    public class Order
    {
        public event EventHandler OnCreated;

        public void Create()
        {
            Console.WriteLine("Order created");

            if (OnCreated != null)
            {
                OnCreated(this, EventArgs.Empty);
            }
        }
    }

    class Email
    {
        public static void Send(object sender, EventArgs e)
        {
            Console.WriteLine($"Send an email");
        }
    }

    class SMS
    {
        public static void Send(object sender, EventArgs e)
        {
            Console.WriteLine($"Send an SMS");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            order.OnCreated += Email.Send;
            order.OnCreated += SMS.Send;
            order.OnCreated += Method1;

            order.Create();
        }

        private static void Method1(object sender, EventArgs e)
        {
            Console.WriteLine("Static Method1");
        }
    }

    
}