using System.Diagnostics;

namespace Otus_Second_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter collections dimension");
            int dimension = Int32.Parse(Console.ReadLine());
            CreateListCollection(dimension);
        }

        static List<int> CreateListCollection(int dimension)
        {
            List<int> list = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < dimension; i++)
            {
                list.Add(i+1);
            }
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
            timeSpan.Milliseconds / 10);
            Console.WriteLine($"List of {dimension} dimension wos created in {elapsedTime}");

            return list;

        }

        //static IEnumerable CreateArrayListCollection(int dimension)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    stopwatch.Stop();
        //    TimeSpan timeSpan = stopwatch.Elapsed;
        //}

        //static LinkedList<int> CreateLinkedListCollection(int dimension) 
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    stopwatch.Stop();
        //    TimeSpan timeSpan = stopwatch.Elapsed;
        //}
    }

}