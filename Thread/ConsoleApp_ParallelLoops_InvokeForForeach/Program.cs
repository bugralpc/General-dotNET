namespace ConsoleApp_ParallelLoops_InvokeForForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Action(() =>
            {
                Console.WriteLine($"First {Task.CurrentId}");
            });
            var b = new Action(() =>
            {
                Console.WriteLine($"Second {Task.CurrentId}");
            });
            var c = new Action(() =>
            {
                Console.WriteLine($"Third {Task.CurrentId}");
            });

            Parallel.Invoke(a, b, c); // runs this action concurrently

            Console.WriteLine("-----------------------");

            Parallel.For(1, 11, i =>
            {
                Console.WriteLine($"{i*i}\t");
            });
            // you will not get in order square of each 

            //Console.WriteLine("------------------------");

            //string[] words = { "oh", "what", "a", "night" };

            //Parallel.ForEach(words, a => Console.WriteLine(a.Length));



        }
    }
}