namespace ConsoleApp_Mutex_1
{
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
                balance += amount;
            }

            public void Withdraw(int amount)
            {
                balance -= amount;

            }

            public void Transfer(BankAccount where, int amount)
            {
                Balance -= amount;
                where.Balance += balance;
            }


        }
        static void Main(string[] args)
        {
            var tasks = new List<Task>();

            var ba = new BankAccount();
            var ba2 = new BankAccount();

            Mutex mutex = new Mutex();
            Mutex mutex2 = new Mutex();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex.ReleaseMutex();
                            }
                        }
                        
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex.ReleaseMutex();
                            }
                        }
                    }
                }));

            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine(ba.Balance);

            Console.WriteLine("/////////////");
            // Bank account transfers

            var tasks2 = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks2.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Deposit(1);
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex.ReleaseMutex();
                            }
                        }
                    }
                }));

                tasks2.Add(Task.Factory.StartNew(() =>
                {
                    for(int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex2.WaitOne();
                        try
                        {
                            ba2.Deposit(1);
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex2.ReleaseMutex();
                            }
                        }
                    }
                }));

                tasks2.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        bool haveLock = WaitHandle.WaitAll(new[] { mutex, mutex2 });
                        try
                        {
                            ba.Transfer(ba2, 1);
                        }
                        finally
                        {
                            if(haveLock)
                            {
                                mutex.ReleaseMutex();
                                mutex2.ReleaseMutex();
                            }
                        }
                    }
                }));
            }

            Task.WaitAll(tasks2.ToArray());

            Console.WriteLine(ba.Balance);
            Console.WriteLine(ba2.Balance); // this should be 20000, later check


        }
    }
}