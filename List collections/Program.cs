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
            Console.Write("Enter a value of collections' dimension: ");
            int dimension = CorrectInputCheck();

            Console.Write("Enter a value of element's position to find: ");
            int elementPosition = CorrectInputCheck();

            Console.Write("Enter a value of divisor to find all collection's elements that can be divided without a remainder: ");
            int divisor = CorrectInputCheck();
            Console.WriteLine();

            List<string> report = new List<string>();
            var list = CreateListCollection(dimension, ref report);
            var listArray = CreateArrayListCollection(dimension, ref report);
            var linkedList = CreateLinkedListCollection(dimension, ref report);

            FindElement(elementPosition, list, ref report);
            FindElement(elementPosition, listArray, ref report);
            FindElement(elementPosition, linkedList, ref report);

            FindDividedWORemainder(divisor, list, ref report);
            FindDividedWORemainder(divisor, listArray, ref report);
            FindDividedWORemainder(divisor, linkedList, ref report);

            foreach (var item in report)
            {
                Console.WriteLine(item);
            }

        }
        /// <summary>
        /// Создает объект типа List задаваемого размера и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="dimension">
        /// Размер создаваемой коллекции
        /// </param>
        /// <param name="report"> Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        /// <returns> объект типа List </returns>
        static List<int> CreateListCollection(int dimension, ref List<string> report)
        {
            List<int> list = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                list.Add(i + 1);
            }

            stopwatch.Stop();
            report.Add($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return list;

        }

        /// <summary>
        /// Создает объект типа ArrayList задаваемого размера и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="dimension">
        /// Размер создаваемой коллекции
        /// </param>
        /// <param name="report"> Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        /// <returns> объект типа ArrayList </returns>
        static ArrayList CreateArrayListCollection(int dimension, ref List<string> report)
        {
            ArrayList arrayList = new ArrayList();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                arrayList.Add(i + 1);
            }

            stopwatch.Stop();
            report.Add($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return arrayList;
        }

        /// <summary>
        /// Создает объект типа LinkedList задаваемого размера и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="dimension">
        /// Размер создаваемой коллекции
        /// </param>
        /// <param name="report"> Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        /// <returns> объект типа LinkedList </returns>
        static LinkedList<int> CreateLinkedListCollection(int dimension, ref List<string> report)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < dimension; i++)
            {
                linkedList.AddLast(i + 1);
            }

            stopwatch.Stop();
            report.Add($"Method {MethodBase.GetCurrentMethod().Name} elapsed in {stopwatch.Elapsed}");

            return linkedList;
        }

        /// <summary>
        /// Находит задаваемый элемент в задаваемой коллекции и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="elementIndex">Элемент для поиска в коллекции</param>
        /// <param name="list">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindElement(int elementIndex, List<int> list, ref List<string> report)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var element = list[elementIndex];

            stopwatch.Stop();
            report.Add($"Element {element} in position {elementIndex} of {nameof(list)} with {list.Count} elements was found in {stopwatch.Elapsed}");
        }

        /// <summary>
        /// Находит задаваемый элемент в задаваемой коллекции и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="elementIndex">Элемент для поиска в коллекции</param>
        /// <param name="arrayList">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindElement(int elementIndex, ArrayList arrayList, ref List<string> report)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var element = arrayList[elementIndex];

            stopwatch.Stop();
            report.Add($"Element {element} in position {elementIndex} of {nameof(arrayList)} with {arrayList.Count} elements was found in {stopwatch.Elapsed}");
        }

        /// <summary>
        /// Находит задаваемый элемент в задаваемой коллекции и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="elementIndex">Элемент для поиска в коллекции</param>
        /// <param name="linkedList">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindElement(int elementIndex, LinkedList<int> linkedList, ref List<string> report, int variant = 1)
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
            report.Add($"Element {element} in position {elementIndex} of {nameof(linkedList)} with {linkedList.Count} elements was found in {stopwatch.Elapsed}");
        }

        /// <summary>
        /// Находит все элементы задаваемой коллекции, делимые без остатка на задаваемое число,
        /// выводит эти элементы на экран и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="divisor">Делитель</param>
        /// <param name="list">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindDividedWORemainder(int divisor, List<int> list, ref List<string> report)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> listModified = list.FindAll(element => element % divisor == 0);
            Console.WriteLine(String.Join(", ", listModified));

            stopwatch.Stop();
            report.Add($"{listModified.Count} elements divideble by {divisor} without a remainder were found in {nameof(list)} in {stopwatch.Elapsed}");
            Console.WriteLine(report.Last());
            Console.WriteLine();
        }

        /// <summary>
        /// Находит все элементы задаваемой коллекции, делимые без остатка на задаваемое число,
        /// выводит эти элементы на экран и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="divisor">Делитель</param>
        /// <param name="arrayList">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindDividedWORemainder(int divisor, ArrayList arrayList, ref List<string> report)
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
            report.Add($"{counter} elements divideble by {divisor} without a remainder were found in {nameof(arrayList)} in {stopwatch.Elapsed}");
            Console.WriteLine(report.Last());
            Console.WriteLine();
        }

        /// <summary>
        /// Находит все элементы задаваемой коллекции, делимые без остатка на задаваемое число,
        /// выводит эти элементы на экран и замеряет скорость выполнения этой операции
        /// </summary>
        /// <param name="divisor">Делитель</param>
        /// <param name="linkedList">Коллекция для обработки</param>
        /// <param name="report">Коллекция, куда передается отчет о замере скорорости выполнения операции</param>
        static void FindDividedWORemainder(int divisor, LinkedList<int> linkedList, ref List<string> report)
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
            report.Add($"{counter} elements divideble by {divisor} without a remainder were found in {nameof(linkedList)} in {stopwatch.Elapsed}");
            Console.WriteLine(report.Last());
            Console.WriteLine();
        }

        /// <summary>
        /// в цикле: читает ввод с консоли; выводит сообщение о корректности ввода; пытается спарсить
        /// </summary>
        /// <returns> Результат парсинга </returns>
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
