namespace ConsoleApp_ReaderWriterLock
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
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            Balance = amount;
        }

        public void Transfer(BankAccount where, int amount)
        {
            balance -= amount;
            where.Balance += amount;
        }
    }


    internal class Program
    {
        static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim();

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int x = 0;

            var tasks = new List<Task>();

            for(int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    padlock.EnterReadLock();

                    Console.WriteLine($"Entered read lock, x = {x}");
                    Thread.Sleep(3000);

                    padlock.ExitReadLock();
                    Console.WriteLine($"Exited read lock, x = {x}");
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch(AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }

            while(true)
            {
                Console.ReadKey();
                padlock.EnterWriteLock();
                Console.WriteLine("Write lock acquires");
                int newValue = rnd.Next(10);
                Console.WriteLine($"Set x = {x}");
                padlock.ExitWriteLock();
                Console.WriteLine("Write lock released");
            }

        }
    }
}