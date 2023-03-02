namespace ConsoleApp_EventHandler_2
{

    // Passing data by extending EventArgs
    // To pass data in the second parameter of the vent handler from publisher to subscriber, you need to define a class
    // that inherits the EventArgs class.

    public class OrderEventArgs: EventArgs
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Order
    {
        public event EventHandler<OrderEventArgs> OnCreated;

        public void Create(string email, string phone)
        {
            Console.WriteLine("Order Created");

            if (OnCreated != null)
            {
                OnCreated(this, new OrderEventArgs { Email = email, Phone = phone });
            }
        }
    }

    class Email
    {
        public static void Send(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"Send an email to {e.Email}");
        }
    }

    class SMS
    {
        public static void Send(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"Send an SMS to {e.Phone}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            order.OnCreated += Email.Send;
            order.OnCreated += SMS.Send;

            order.Create("john@test.com", "(408)-111-2222");
        }
    }
}