using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Exceptions
{
    internal class InputHandling
    {
        private static string[] _variantsToChoose = { "a", "b", "c" };
        private static string _formula = "a * x^2 + b * x + c = 0";
        private StringBuilder[] _formulaModified = new StringBuilder[_formula.Length];
        private StringBuilder[] _arrayOfInputsPerVariant = new StringBuilder[3];
        private ConsoleKeyInfo _key;
        private int _selectedVariant = 0;

        public InputHandling()
        {
            for (int i = 0; i < _formula.Length; i++)
            {
                _formulaModified[i] = new StringBuilder(_formula[i].ToString());
            }

            StringBuilder variantA = new StringBuilder();
            StringBuilder variantB = new StringBuilder();
            StringBuilder variantC = new StringBuilder();
            _arrayOfInputsPerVariant = new StringBuilder[] { variantA, variantB, variantC };
        }

        private void ChooseVariantAbove()
        {
            if (_selectedVariant > 0)
            {
                _selectedVariant--;
            }
            else
            {
                _selectedVariant = _variantsToChoose.Length - 1;
            }
        }

        private void ChooseVariantBelow()
        {
            if (_selectedVariant < _variantsToChoose.Length - 1)
            {
                _selectedVariant++;
            }
            else
            {
                _selectedVariant = 0;
            }
        }

        /// <summary>
        /// Очищает консоль с задаваемой строки вниз на задаваемое количество строк
        /// </summary>
        /// <param name="startRowIndex">Индекс стартовой строки</param>
        /// <param name="rowsToClear">Количество строк для очистки</param>
        public static void ClearRow(int startRowIndex, int rowsToClear)
        {
            Console.CursorVisible = false;
            SetCursorPosition(Console.WindowWidth - 1, startRowIndex);

            for (int i = 0; i < rowsToClear; i++)
            {
                SetCursorPosition(Console.WindowWidth - 1, startRowIndex + i);
                do { Console.Write("\b \b"); } while (Console.CursorLeft > 0);
            }

            SetCursorPosition(0, startRowIndex);

            Console.CursorVisible = true;
        }

        /// <summary>
        /// Для выбранного параметра отображает: ввод с клавиатуры его значения и синхронное изменение выбранного параметра в формуле
        /// </summary>
        /// <param name="selectedVariant">Индекс изменяемого параметра</param>
        private void SelectedVariantModification(int selectedVariant)
        {
            StringBuilder input = _arrayOfInputsPerVariant[selectedVariant];
            int indexOfSelectedVariableInFormula = _formula.IndexOf(_variantsToChoose[selectedVariant]);

            const int INPUT_LIMIT = 18;
            string eraser = new string(' ', INPUT_LIMIT * 3 + _formula.Length);

            if (input.Length == 0)
            {
                _formulaModified[indexOfSelectedVariableInFormula].Clear();
            }

            bool anotherVariantIsChosen = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                SetCursorPosition(0, 1);

                if (input.Length == 0)
                {
                    _formulaModified[indexOfSelectedVariableInFormula] = new StringBuilder(_variantsToChoose[selectedVariant]);
                    foreach (var v in _formulaModified)
                    {
                        Write(v);
                    }
                    _formulaModified[indexOfSelectedVariableInFormula].Clear();
                }
                else
                {
                    Write(eraser);
                    SetCursorPosition(0, 1);

                    foreach (var v in _formulaModified)
                    {
                        Write(v);
                    }
                }

                switch (selectedVariant)
                {
                    case 0: SetCursorPosition(indexOfSelectedVariableInFormula, 1); break;
                    case 1: SetCursorPosition(indexOfSelectedVariableInFormula + _formulaModified[_formula.IndexOf("a")].Length - 1, 1); break;
                    case 2:
                        SetCursorPosition(indexOfSelectedVariableInFormula + _formulaModified[_formula.IndexOf("a")].Length +
                         _formulaModified[_formula.IndexOf("b")].Length - 2, 1); break;
                }
                Console.ForegroundColor = ConsoleColor.Green;

                if (input.Length == 0)
                {
                    Write(_variantsToChoose[selectedVariant]);
                }
                else if (input.Length > 0 && indexOfSelectedVariableInFormula != 0 && input[0] == '-')
                {
                    input.Remove(0, 1);
                    Write(input);
                    input.Insert(0, "-");

                    switch (selectedVariant)
                    {
                        case 0: SetCursorPosition(indexOfSelectedVariableInFormula, 1); break;
                        case 1: SetCursorPosition(indexOfSelectedVariableInFormula + _formulaModified[_formula.IndexOf("a")].Length - 1 - 2, 1); break;
                        case 2:
                            SetCursorPosition(indexOfSelectedVariableInFormula + _formulaModified[_formula.IndexOf("a")].Length +
                             _formulaModified[_formula.IndexOf("b")].Length - 2 - 2, 1); break;
                    }
                    Write("-");
                }
                else
                {
                    Write(input);
                }

                SetCursorPosition(0, selectedVariant + 2);
                Console.ForegroundColor = ConsoleColor.White;
                Write("> " + _variantsToChoose[selectedVariant] + ": ");
                Console.ForegroundColor = ConsoleColor.Green;
                Write(input);

                _key = ReadKey(true);
                anotherVariantIsChosen =
                    //_key.Key == ConsoleKey.Escape |
                    _key.Key == ConsoleKey.Enter |
                    _key.Key == ConsoleKey.DownArrow |
                    _key.Key == ConsoleKey.UpArrow;


                if (!anotherVariantIsChosen)
                {
                    _formulaModified[indexOfSelectedVariableInFormula].Clear();

                    switch (_key.Key)
                    {
                        case ConsoleKey.OemMinus:

                            if (input.Length < INPUT_LIMIT)
                            {
                                if (input.Length == 0 && indexOfSelectedVariableInFormula != 0)
                                {
                                    _formulaModified[indexOfSelectedVariableInFormula - 2] = new StringBuilder("-");
                                }
                                input.Append(_key.KeyChar);
                            }

                            break;
                        case ConsoleKey.Backspace:

                            if (input.Length > 0)
                            {
                                if (input.Length == 1 && indexOfSelectedVariableInFormula != 0)
                                {
                                    _formulaModified[indexOfSelectedVariableInFormula - 2] = new StringBuilder("+");
                                }
                                Write("\b \b");
                                input.Remove(input.Length - 1, 1);
                            }

                            break;
                        default:

                            if (input.Length < INPUT_LIMIT)
                            {
                                input.Append(_key.KeyChar);
                            }

                            break;
                    };

                    if (input.Length > 0 && indexOfSelectedVariableInFormula != 0 && input[0] == '-')
                    {
                        _formulaModified[indexOfSelectedVariableInFormula].Append(input.Remove(0, 1));
                        input.Insert(0, "-");
                    }
                    else
                    {
                        _formulaModified[indexOfSelectedVariableInFormula].Append(input);
                    }
                }

                if (anotherVariantIsChosen)
                {
                    if (input.Length == 0)
                    {
                        _formulaModified[indexOfSelectedVariableInFormula] = new StringBuilder(_variantsToChoose[selectedVariant]);
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    SetCursorPosition(0, 1);
                    Write(eraser);
                    SetCursorPosition(0, 1);

                    foreach (var v in _formulaModified)
                    {
                        Write(v);
                    }

                    SetCursorPosition(0, selectedVariant + 2);
                    Write(eraser);

                    SetCursorPosition(0, selectedVariant + 2);
                    Write(_variantsToChoose[selectedVariant] + ": " + input);

                    _arrayOfInputsPerVariant[selectedVariant] = input;

                    break;
                }
            }
            while (!anotherVariantIsChosen);
        }

        private void PrintMenu()
        {
            Console.WriteLine("Enter coefficients of the quadratic equation and press Enter to try to find solutions \n");

            foreach (var variant in _variantsToChoose)
            {
                Console.WriteLine(variant + ": ");
            }
        }

        public string[] ConstructMenu()
        {
            SetCursorPosition(0, 0);
            PrintMenu();

            bool enterIsPressedToProceed = false;
            do
            {
                SelectedVariantModification(_selectedVariant);
                switch (_key.Key)
                {
                    case ConsoleKey.UpArrow:
                        ChooseVariantAbove();
                        break;
                    case ConsoleKey.DownArrow:
                        ChooseVariantBelow();
                        break;
                    case ConsoleKey.Enter:
                        bool variantsAreNotEmpty = _arrayOfInputsPerVariant.All(input => input.Length > 0);
                        if (variantsAreNotEmpty)
                        {
                            enterIsPressedToProceed = true;
                        }
                        break;
                }

            } while (!enterIsPressedToProceed);

            string[] arrayOfInputsToReturn = new string[_arrayOfInputsPerVariant.Length];
            for (int i = 0; i < _arrayOfInputsPerVariant.Length; i++)
            {
                arrayOfInputsToReturn[i] = _arrayOfInputsPerVariant[i].ToString();
            }

            return arrayOfInputsToReturn;
        }
    }
}