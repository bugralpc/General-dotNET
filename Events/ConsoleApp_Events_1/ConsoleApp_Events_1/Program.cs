namespace ConsoleApp_Events_1
{
    // to use events effectively to design the loose coupling applications.

    // Events allow a class or object to notify other classes or objects when something occurs.

    // The class that raises (or sends) the event is called the publisher
    // The classes that receive (or handle) the event are called subscribers. The method of the classes that handle
    // the event is often called event handlers.

    // This pattern is known as publisher/subscriber design pattern.
    // In this pattern, the publisher determines when to raise the event and the subscriber decide how to handle the event.

    // techically an event has an encapsulated delegate. That is, an event is like a simpler delegate.

    public class Order1
    {
        public void Create()
        {
            Console.WriteLine("Order1 Create() method");
            Email1.Send();
            SMS1.Send();
        }
    }
    public class Email1
    {
        public static void Send()
        {
            Console.WriteLine("Send an email");
        }
    }
    public class SMS1
    {
        public static void Send()
        {
            Console.WriteLine("Send a SMS1");
        }
    }

    delegate void OrderEventHandler(); // delegate type for event, delegate is kind of method pointer

    class Order2
    {
        // the event is public so that other classes can register event handler
        public event OrderEventHandler OnCreated; // OnCreated is an event

        public void Create()
        {
            Console.WriteLine("Order2 created");

            // Raising an event is the same as invoking a method. An event that does not any event handler is null.
            if (OnCreated != null)
            {
                OnCreated(); // raise events
            }
        }

    }


    public class Program
    {

        static void Main(string[] args)
        {
            // if you want to do other tasks when order is created, you need to modify the Create() method.
            // Order1 class depends on the Email1 and SMS1 classes, which is not a good design.
            Order1 order1 = new Order1();
            order1.Create();

            // To solve above problem, you need to use publisher/subscriber pattern.
            // Order class need to be publisher
            // Email and SMS classes need to be subscriber

            // Subscribing to an event means adding event handlers to an event.
            // event delegate => event, then event handlers are added to event.

            var order2 = new Order2();

            order2.OnCreated += Email1.Send;
            order2.OnCreated += SMS1.Send;

            order2.Create();
            //The Create() method raises the OnCreated event.
        }
    }
}