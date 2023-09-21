using System.Collections.Concurrent;

namespace Librarian
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new ConcurrentDictionary<string, int>();
            OnButtonPressing(dictionary);
        }

        static void OnButtonPressing(ConcurrentDictionary<string, int> dictionary)
        {
            bool threeIsPressed = false;
            do
            {
                Console.WriteLine("1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Введите название книги: ");
                        var bookName = Console.ReadLine();
                        var isSuccessfulAdded = dictionary.TryAdd(bookName, 0);
                        if (isSuccessfulAdded)
                        {
                            ReadBookAsync(dictionary, bookName);
                        }
                        break;
                    case "2":
                        foreach (var book in dictionary)
                        { Console.WriteLine($"{book.Key} - {book.Value}%"); }
                        break;
                    case "3":
                        threeIsPressed = true;
                        break;
                }
            }
            while (!threeIsPressed);
        }

        static async Task ReadBookAsync(ConcurrentDictionary<string, int> dictionary, string bookName)
        {
            await Task.Run(() =>
           {
               while (dictionary[bookName] != 100)
               {
                   dictionary[bookName] += 1;
                   Thread.Sleep(1000);
               }
               dictionary.Remove(bookName, out int s);
           });
        }
    }
}