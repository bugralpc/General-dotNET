using System.Collections.Concurrent;

namespace ConsoleApp_ConcurrentStack_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bag = new ConcurrentBag<int>();

            var tasks = new List<Task>();

            for(int i = 0; i < 10; i++)
            {
                var i1 = i;

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    bag.Add(i1);
                    Console.WriteLine($"{Task.CurrentId} has added {i1}");
                    int result;
                    if (bag.TryPeek(out result))
                    {
                        Console.WriteLine($"{Task.CurrentId} has peeked the value {result}");
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

        }
    }
}