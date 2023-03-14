using System.Collections.Concurrent;

namespace ConsoleApp_BlockingCollection_ProduceerConsumer
{
    internal class Program
    {
        static BlockingCollection<int> messages =
            new BlockingCollection<int>(new ConcurrentBag<int>(), 10);

        static CancellationTokenSource cts = new CancellationTokenSource();

        static Random random = new Random();

        static void Main(string[] args)
        {

            Task.Factory.StartNew(ProduceAndConsume, cts.Token);

            Console.ReadKey();

            cts.Cancel();

        }

        private static void ProduceAndConsume()
        {
            var producer = Task.Factory.StartNew(RunProducer);
            var consumer = Task.Factory.StartNew(RunConsumer);

            try
            {
                Task.WaitAll(new[] { producer, consumer }, cts.Token);
            }
            catch(AggregateException ae)
            {
                ae.Handle(e => true);
            }

        }

        private static void RunConsumer()
        {
            foreach(var item in messages.GetConsumingEnumerable())
            {
                cts.Token.ThrowIfCancellationRequested();

                Console.WriteLine("Producer removed" + item);
                Thread.Sleep(random.Next(1000));
            }
        }

        private static void RunProducer()
        {
            while(true)
            {
                cts.Token.ThrowIfCancellationRequested();
                int i = random.Next(100);
                messages.Add(i);
                Console.WriteLine("Producer added " + i);
                Thread.Sleep(random.Next(1000));
            }
        }
    }
}