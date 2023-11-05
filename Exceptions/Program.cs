using System.Runtime.InteropServices;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputHandling menu = new InputHandling();

            while (true)
            {
                string[] arrayOfInputsToParse = menu.ConstructMenu();

                long[] intermediateParse = new long[arrayOfInputsToParse.Length];
                int[] valuesToCalculate = new int[arrayOfInputsToParse.Length];

                try
                {
                    for (int i = 0; i < arrayOfInputsToParse.Length; i++)
                    {
                        intermediateParse[i] = long.Parse(arrayOfInputsToParse[i]);
                    }
                }
                catch
                {
                    IDictionary<string, string> unparsedValues = new Dictionary<string, string>();

                    for (int i = 0; i < arrayOfInputsToParse.Length; i++)
                    {
                        if (long.TryParse(arrayOfInputsToParse[i], out intermediateParse[i]) == false)
                        {
                            switch (i)
                            {
                                case 0: unparsedValues.Add("a", arrayOfInputsToParse[i]); break;
                                case 1: unparsedValues.Add("b", arrayOfInputsToParse[i]); break;
                                case 2: unparsedValues.Add("c", arrayOfInputsToParse[i]); break;
                            }

                        }
                    }

                    InputHandling.ClearRow(6, 6);

                    string message = "These values are not integer numbers";
                    FormatData(message, Severity.Error, unparsedValues);

                    continue;
                }

                try
                {
                    for (int i = 0; i < arrayOfInputsToParse.Length; i++)
                    {
                        valuesToCalculate[i] = int.Parse(arrayOfInputsToParse[i]);
                    }
                }
                catch
                {
                    IDictionary<string, string> unparsedValues = new Dictionary<string, string>();

                    for (int i = 0; i < arrayOfInputsToParse.Length; i++)
                    {
                        if (int.TryParse(arrayOfInputsToParse[i], out valuesToCalculate[i]) == false)
                        {
                            switch (i)
                            {
                                case 0: unparsedValues.Add("a", arrayOfInputsToParse[i]); break;
                                case 1: unparsedValues.Add("b", arrayOfInputsToParse[i]); break;
                                case 2: unparsedValues.Add("c", arrayOfInputsToParse[i]); break;
                            }

                        }
                    }

                    InputHandling.ClearRow(6, 6);

                    string message = $"These values are out of integer type range: {int.MinValue} to {int.MaxValue}";
                    FormatData(message, Severity.HalfErrorHalfWarning, unparsedValues);

                    continue;
                }

                InputHandling.ClearRow(6, 6);

                try
                {
                    QuadraticEquationSolution(valuesToCalculate);
                    break;
                }
                catch (NoRealRootsException e)
                {
                    var nullDictionary = new Dictionary<string, string>();
                    FormatData(e.Message, Severity.Warning, nullDictionary);
                    break;
                }
                catch (EquasionIsNotQuadraticException e) 
                {
                    var nullDictionary = new Dictionary<string, string>();
                    FormatData(e.Message, Severity.Warning, nullDictionary);
                    break;
                }

            }

        }

        static void QuadraticEquationSolution(int[] coefficients)
        {
            int coeficcientA = coefficients[0],
                coeficcientB = coefficients[1],
                coeficcientC = coefficients[2];

            if (coeficcientA == 0)
            {
                throw new EquasionIsNotQuadraticException("Coefficient a = 0, this equasion is not quadratic");
            }
            else
            {
                int discriminant = coeficcientB * coeficcientB - 4 * coeficcientA * coeficcientC;

                switch (discriminant)
                {
                    case int d when d > 0:
                        float firstSolution = (-coeficcientB - (float)Math.Sqrt(discriminant)) / 2 * coeficcientA,
                              secondSolution = (-coeficcientB + (float)Math.Sqrt(discriminant)) / 2 * coeficcientA;
                        Console.WriteLine($"This equasion has two solutions: \n x1 = {firstSolution}, x2 = {secondSolution}");
                        break;
                    case int d when d == 0:
                        float solution = -coeficcientB / 2 * coeficcientA;
                        Console.WriteLine($"This equasion has one solution: \n x = {solution}");
                        break;
                    case int d when d < 0:
                        throw new NoRealRootsException("This equasion has no real roots");

                }
            }
        }


        class NoRealRootsException : Exception
        {
            public NoRealRootsException(string? message) : base(message)
            {
            }
        }
        
        class EquasionIsNotQuadraticException : Exception
        {
            public EquasionIsNotQuadraticException(string? message) : base(message)
            {
            }
        }

        enum Severity { Warning, Error, HalfErrorHalfWarning }

        /// <summary>
        /// Выводит в консоли информацию об обработанном исключении, по возможности
        /// указывает параметры для исправления
        /// </summary>
        /// <param name="message">Описание исключения</param>
        /// <param name="severity">Степень важности исключения</param>
        /// <param name="data">Словарь параметров. вызвавших исключение</param>
        static void FormatData(string message, Severity severity, IDictionary<string, string> data)
        {
            switch (severity)
            {
                case Severity.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Severity.Warning:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Severity.HalfErrorHalfWarning:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            string border = new string('-', 50);
            Console.Write(border);
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine(border);

            if (severity != Severity.Warning)
            {
                foreach (KeyValuePair<string, string> kvp in data)
                {
                    Console.WriteLine($"{kvp.Key} = {kvp.Value}");
                }
            }

            Console.ResetColor();
        }
    }
}