namespace ConsoleApp_BankAccountProblem
{
    // Concept of Atomacity
    // Critical Section

    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
    }

    public class BankAccountLock
    {
        public object padlock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            lock(padlock)
            {
                Balance += amount;
            }
            
        }

        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();   

            var ba = new BankAccount();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for(int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for(int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Final Balance is " + ba.Balance);

            // The bank balance is not 0. Deposit and Withdraw operations are not atomic
            // The object is not used synchrnously.

            var tasks2 = new List<Task>();

            var ba2 = new BankAccountLock();

            for (int i = 0; i < 10; i++)
            {
                tasks2.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba2.Deposit(100);
                    }
                }));

                tasks2.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba2.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks2.ToArray());

            Console.WriteLine("Final Balance is " + ba2.Balance);
            // The bank balance is 0. Deposit and Withdraw operations are atomic
            // The object is used synchrnously.

            // In C#, an atomic operation is an operation that is performed as a single,
            // indivisible unit of operation. It means that the operation is executed as a single step,
            // without the possibility of interference from another operation.
            // It can be used to ensure thread safety 
        }
    }
}