namespace ConsoleApp_InterlockedOperations
{
    // In C#, Interlocked is a class that provides a set of methods for performing atomic operations on variables,
    // such as incrementing or decrementing their values. 
    
    // These operations are guaranteed to be thread-safe and atomic, can't be interrupted by other threads.

    internal class Program
    {
        public class BankAccount
        {
            private int balance;

            public int Balance
            {
                get { return balance; }
                set { balance = value; }
            }

            public void Deposit(int amount)
            {
                Interlocked.Add(ref balance, amount);
            }

            public void Withdraw(int amount)
            {
                Interlocked.Add(ref balance, -amount);
                    
            }
        }

        static void Main(string[] args)
        {
            int count = 0;

            for(int i = 0; i < 10; i++)
            {
                Interlocked.Increment(ref count);
            }

            Console.WriteLine(count);

            var tasks = new List<Task>();

            var ba = new BankAccount();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Final Balance is " + ba.Balance);



        }
    }
}