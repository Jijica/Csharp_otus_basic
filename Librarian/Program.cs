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

        static async void OnButtonPressing(ConcurrentDictionary<string, int> dictionary)
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
                        bool isEmpty = !dictionary.Any();
                        bool isReadable = dictionary.TryAdd(bookName, 0) && isEmpty;
                        if (isReadable)
                        {
                            ReadBooksAsync(dictionary);
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

        static async Task ReadBooksAsync(ConcurrentDictionary<string, int> dictionary)
        {
            await Task.Run(() =>
            {
                while (dictionary.Any())
                {
                    Parallel.ForEach(dictionary, (book) =>
                    {
                        if (book.Value != 100)
                        {
                            dictionary[book.Key] += 1;
                        }
                        else
                        {
                            dictionary.Remove(book.Key, out int s);
                        }
                    });
                    Thread.Sleep(1000);
                }
            });
        }
    }
}