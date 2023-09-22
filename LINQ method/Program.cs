﻿namespace LINQ_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<int>();
            var test = new List<int> { 1213,12312,423423,234234};
            var tested = test.OrderDescending().ToList();
            var rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                collection.Add(rnd.Next(1, 100000));
            }
            var topped = collection.Top(30, e => e - 1000000).ToList();
           // topped.ForEach(Console.WriteLine);
            tested.ForEach(Console.WriteLine);
        }
    }
}