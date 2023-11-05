﻿namespace Otus_First_Homework
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

            bool lessThenForty = tableInnerWidth + 2 < 40;

            if (lessThenForty)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(HorizontalBorder(tableInnerWidth));

                    switch (i)
                    {
                        case 0: TopTablePart(tableDimension, inputString, tableInnerWidth, tableInnerHight); break;
                        case 1: MiddleTablePart(tableInnerWidth, tableInnerHight); break;
                        case 2: BottomTablePart(tableInnerWidth); Console.WriteLine(HorizontalBorder(tableInnerWidth)); break;
                    }
                }
            }
            else { Console.WriteLine("Your table is too wide"); }

            Console.ReadKey();
        }

        static string HorizontalBorder(int tableInnerWidth) => new string('+', tableInnerWidth + 2);

        static void TopTablePart(int tableDimension, string inputString, int tableInnerWidth, int tableInnerHight)
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

        static void MiddleTablePart(int tableInnerWidth, int tableInnerHight)
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

        static void BottomTablePart(int tableInnerWidth)
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
    }
}