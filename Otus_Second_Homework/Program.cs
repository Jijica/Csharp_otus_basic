using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Otus_Second_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the value of collections' dimension: ");
            int dimension = CorrectInputCheck();

            Console.Write("Enter the value of element's position to find: ");
            int elementPosition = CorrectInputCheck();

            Console.Write("Enter the value of divisor to find all collection's elements that can be divided without a remainder: ");
            int divisor = CorrectInputCheck();
            Console.WriteLine();

            var list = CreateListCollection(dimension);
            var listArray = CreateArrayListCollection(dimension);
            var linkedList = CreateLinkedListCollection(dimension);
            Console.WriteLine();

            FindElement(elementPosition, list);
            FindElement(elementPosition, listArray);
            FindElement(elementPosition, linkedList);
            Console.WriteLine();

            FindDividedWORemainder(divisor, list);
            FindDividedWORemainder(divisor, listArray);
            FindDividedWORemainder(divisor, linkedList);
        }

        static List<int> CreateListCollection(int dimension)
        {
            List<int> list = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                list.Add(i + 1);
            }

            stopwatch.Stop();
            Console.WriteLine($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return list;

        }

        static ArrayList CreateArrayListCollection(int dimension)
        {
            ArrayList arrayList = new ArrayList();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                arrayList.Add(i + 1);
            }

            stopwatch.Stop();
            Console.WriteLine($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return arrayList;
        }

        static LinkedList<int> CreateLinkedListCollection(int dimension)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                linkedList.AddLast(i + 1);
            }

            stopwatch.Stop();
            Console.WriteLine($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return linkedList;
        }

        static void FindElement(int elementIndex, List<int> list)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var element = list[elementIndex];

            stopwatch.Stop();
            Console.WriteLine($"Element {element} in position {elementIndex} of {nameof(list)} with {list.Count} elements was found in {stopwatch.Elapsed}");
        }

        static void FindElement(int elementIndex, ArrayList arrayList)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var element = arrayList[elementIndex];

            stopwatch.Stop();
            Console.WriteLine($"Element {element} in position {elementIndex} of {nameof(arrayList)} with {arrayList.Count} elements was found in {stopwatch.Elapsed}");
        }

        static void FindElement(int elementIndex, LinkedList<int> linkedList, int variant = 1)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            LinkedListNode<int> node;
            var element = 0;

            switch (variant)
            {
                case 1:
                    bool closerToEnd = linkedList.Count / 2 > elementIndex;
                    if (closerToEnd)
                    {
                        node = linkedList.Last;

                        for (int i = 1; i < linkedList.Count - elementIndex; i++)
                        {
                            node = node.Previous;
                        }
                    }
                    else
                    {
                        node = linkedList.First;
                        for (int i = 1; i <= elementIndex; i++)
                        {
                            node = node.Next;
                        }
                    }
                    element = node.Value;
                    break;

                case 2:
                    element = linkedList.ElementAt(elementIndex);
                    break;

            }

            stopwatch.Stop();
            Console.WriteLine($"Element {element} in position {elementIndex} of {nameof(linkedList)} with {linkedList.Count} elements was found in {stopwatch.Elapsed}");
        }
        static void FindDividedWORemainder(int divisor, List<int> list)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> listModified = list.FindAll(element => element % divisor == 0);
            Console.WriteLine(String.Join(", ", listModified));

            stopwatch.Stop();
            Console.WriteLine($"{listModified.Count} elements divideble by {divisor} without a remainder were found in {nameof(list)} in {stopwatch.Elapsed}");
            Console.WriteLine();
        }

        static void FindDividedWORemainder(int divisor, ArrayList arrayList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int counter = 0;
            foreach (int element in arrayList)
            {
                if (element % divisor == 0)
                {
                    Console.Write(element + ", ");
                    counter++;
                }
            }
            Console.WriteLine();

            stopwatch.Stop();
            Console.WriteLine($"{counter} elements divideble by {divisor} without a remainder were found in {nameof(arrayList)} in {stopwatch.Elapsed}");
            Console.WriteLine();
        }

        static void FindDividedWORemainder(int divisor, LinkedList<int> linkedList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            LinkedListNode<int> node = linkedList.First;
            int counter = 0;

            while (node != null)
            {
                if (node.Value % divisor == 0)
                {
                    Console.Write(node.Value + ", ");
                    node = node.Next;
                    counter++;
                }
                else
                {
                    node = node.Next;
                }
            }
            Console.WriteLine();

            stopwatch.Stop();
            Console.WriteLine($"{counter} elements divideble by  {divisor}  without a remainder were found in {nameof(linkedList)} in {stopwatch.Elapsed}");
            Console.WriteLine();
        }

        static int CorrectInputCheck()
        {
            bool inputIsCorrect;
            int result;
            do
            {
                var input = Console.ReadLine();
                inputIsCorrect = int.TryParse(input, out result);
                if (!inputIsCorrect)
                    Console.WriteLine("Wrong input!");
            }
            while (!inputIsCorrect);
            return result;
        }
    }

}