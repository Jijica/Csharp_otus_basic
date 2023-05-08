using System;

namespace Otus_First_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputDimension, inputString;
            bool inputDimensionIsCorrect, inputStringIsCorrect;
            int tableDimension;

            do
            {
                Console.WriteLine("Please enter integer table dimension from 1 to 6:");

                inputDimension = Console.ReadLine();
                inputDimensionIsCorrect = Int32.TryParse(inputDimension, out tableDimension) && tableDimension >= 1 && tableDimension <= 6;

                if (!inputDimensionIsCorrect) Console.WriteLine("Wrong input!");
            }
            while (!inputDimensionIsCorrect);

            do
            {
                Console.WriteLine("Please enter any non-empty string:");

                inputString = Console.ReadLine();
                inputStringIsCorrect = String.IsNullOrWhiteSpace(inputString);

                if (inputStringIsCorrect) Console.WriteLine("Wrong input!");

            }
            while (inputStringIsCorrect);

            int tableInnerWidth = (tableDimension - 1) * 2 + inputString.Length,
                tableInnerHight = (tableDimension - 1) * 2 + 1;

            string HorizontalBorder() => new string('+', tableInnerWidth + 2);

            void TopTablePart()
            {
                string middleString = "+" + new string(' ', tableDimension - 1) + inputString + new string(' ', tableDimension - 1) + "+",
                       whitespacedString = "+" + new string(' ', tableInnerWidth) + "+";

                for (int i = 0; i < tableInnerHight; i++)
                {
                    if (i == tableDimension - 1)
                    {
                        Console.WriteLine(middleString);
                    }
                    else
                    {
                        Console.WriteLine(whitespacedString);
                    }
                }
            }

            void MiddleTablePart()
            {
                string checkmatePatternString = "+",
                       checkmatePatternStringShifted = "+";

                for (int i = 0; i < tableInnerWidth; i++)
                {
                    if (i % 2 == 0)
                    {
                        checkmatePatternString += " ";
                        checkmatePatternStringShifted += "+";
                    }
                    else
                    {
                        checkmatePatternString += "+";
                        checkmatePatternStringShifted += " ";
                    }
                }
                checkmatePatternString += "+";
                checkmatePatternStringShifted += "+";

                for (int i = 0; i < tableInnerHight; ++i)
                {
                    if (i % 2 == 0)
                    { Console.WriteLine(checkmatePatternString); }
                    else
                    { Console.WriteLine(checkmatePatternStringShifted); }
                }
            }

            void BottomTablePart()
            {
                int padValue = 0,
                    insertValue = tableInnerWidth - 2;

                string crossedPatternStringModified;

                for (int i = 0; i < tableInnerWidth; ++i)
                {
                    if (tableInnerWidth % 2 == 1 && i == tableInnerWidth / 2)
                    {
                        crossedPatternStringModified = new string(' ', padValue) + "+" + new string(' ', padValue);
                        crossedPatternStringModified = "+" + crossedPatternStringModified + "+";
                        Console.WriteLine(crossedPatternStringModified);
                        padValue -= 1;
                        insertValue += 2;
                    }
                    else
                    {
                        crossedPatternStringModified = "+" + new string(' ', insertValue) + "+";
                        crossedPatternStringModified = new string(' ', padValue) + crossedPatternStringModified + new string(' ', padValue);
                        crossedPatternStringModified = "+" + crossedPatternStringModified + "+";
                        Console.WriteLine(crossedPatternStringModified);
                        if (i < tableInnerWidth / 2 - 1)
                        {
                            padValue += 1;
                            insertValue -= 2;
                        }
                        else if (i == tableInnerWidth / 2 - 1 && tableInnerWidth % 2 == 1)
                        {
                            padValue += 1;
                            insertValue -= 2;
                        }
                        else if (i == tableInnerWidth / 2 - 1) { }
                        else
                        {
                            padValue -= 1;
                            insertValue += 2;
                        }
                    }
                }
            }

            bool lessThenForty = tableInnerWidth + 2 < 40;

            if (lessThenForty)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(HorizontalBorder());

                    switch (i)
                    {
                        case 0: TopTablePart(); break;
                        case 1: MiddleTablePart(); break;
                        case 2: BottomTablePart(); Console.WriteLine(HorizontalBorder()); break;
                    }
                }
            }
            else { Console.WriteLine("Your table is too wide"); }

            Console.ReadKey();
        }
    }
}