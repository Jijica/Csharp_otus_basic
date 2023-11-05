using System.Diagnostics;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int position = 40;

            var sw = Stopwatch.StartNew();
            FibonacchiRecursiveSLN(position);
            sw.Stop();
            Console.WriteLine($"element {FibonacchiRecursiveSLN(position)} on position {position} was found in {sw.ElapsedTicks} ticks");

            sw.Restart();
            FibonacchiCycleSLN(position);
            sw.Stop();
            Console.WriteLine($"element {FibonacchiCycleSLN(position)} on position {position} was found in {sw.ElapsedTicks} ticks");

            sw.Restart();
            FibonacchiRecursiveSLN(position);
            sw.Stop();
            Console.WriteLine($"element {FibonacchiRecursiveSLN(position)} on position {position} was found in {sw.ElapsedTicks} ticks");

            sw.Restart();
            FibonacchiCycleSLN(position);
            sw.Stop();
            Console.WriteLine($"element {FibonacchiCycleSLN(position)} on position {position} was found in {sw.ElapsedTicks} ticks");

            //var ticks = MethodElapsedTime(() => FibonacchiRecursiveSLN(position));
            //Console.WriteLine($"element {FibonacchiRecursiveSLN(position)} on position {position} was found in {ticks} ticks");
            //ticks = MethodElapsedTime(() => FibonacchiCycleSLN(position));
            //Console.WriteLine($"element {FibonacchiCycleSLN(position)} on position {position} was found in {ticks} ticks");
        }

        static int FibonacchiRecursiveSLN(int position)
        {
            if (position == 0)
            {
                return 0;
            }
            else if (position == 1 || position == 2)
            {
                return 1;
            }
            else
            {
                return FibonacchiRecursiveSLN(position - 1) + FibonacchiRecursiveSLN(position - 2);
            }
        }

        static int FibonacchiCycleSLN(int position)
        {
            int positionValue = 0,
                storeValue,
                nextPositionValue = 1;
            for (int i = 0; i < position; i++)
            {
                storeValue = nextPositionValue;
                nextPositionValue += positionValue;
                positionValue = storeValue;
            }
            return positionValue;
        }

        static long MethodElapsedTime(Func<int> method)
        {
            Stopwatch sw = Stopwatch.StartNew();
            method();
            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}