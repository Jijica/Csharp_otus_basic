using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Regular_customer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            var shop = new Shop();
            shop.OnCollectionChanged += customer.OnItemChanged;
            OnButtonPressing(customer, shop);
        }

        static void OnButtonPressing(Customer customer, Shop shop)
        {
            var key = new ConsoleKeyInfo();
            Console.WriteLine("Нажмите клавишу \"A\" для добавления нового товара в магазин.\nНажмите клавишу \"D\" для удаления товара по id. \nНажмите клавишу \"X\" для выхода");
            bool xIsPressed = false;
            do
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        shop.Add();
                        break;
                    case ConsoleKey.D:
                        Console.Write("Введите id для удаления: ");
                        var id = Console.ReadLine();
                        shop.Remove(id);
                        break;
                    case ConsoleKey.X: 
                        xIsPressed = true; 
                        break;
                }
            }
            while (!xIsPressed);
        }
    }
}