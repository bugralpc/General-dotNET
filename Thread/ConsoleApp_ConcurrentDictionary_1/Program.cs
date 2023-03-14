using System.Collections.Concurrent;

namespace ConsoleApp_ConcurrentDictionary_1
{
    internal class Program
    {
        private static ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();

        static void Main(string[] args)
        {

            //AddParis();

            Task.Factory.StartNew(AddParis).Wait();

            AddParis();

        }

        private static void AddParis()
        {
            bool success = capitals.TryAdd("France", "Paris");

            string who = Task.CurrentId.HasValue ? ("Task " + Task.CurrentId) : "Main thread";

            Console.WriteLine($"{who} {(success ? "added": "did not add")} the element");
        }
    }
}