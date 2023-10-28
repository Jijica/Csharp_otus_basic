namespace ORM_usage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintItems<Customers>();
            Console.WriteLine($"Элементов в Products: {Dapper.CountItems<Products>()}");
            Dapper.InsertItem(new Products
            {
                Name = "Продукт",
                Description = "Описание",
                StockQuantity = 1,
                Price = 0.1M,
            });
            Console.WriteLine($"Элементов в Products: {Dapper.CountItems<Products>()}");
            PrintItems<Products>();
            PrintItem(Dapper.GetItemByID<Orders>(3));
        }

        private static void PrintItems<T>() where T : IPrintable
        {
            var collection = Dapper.GetItems<T>();
            foreach (var item in collection)
            {
                PrintItem(item);
            }
            Console.WriteLine("\n");
        }

        private static void PrintItem<T>(T element) where T : IPrintable
        {
            Type type = typeof(T);

            if (type == typeof(Customers) || type == typeof(Products) || type == typeof(Orders))
            {
                Console.WriteLine(element.GetPrintableText());
            }
            else
            {
                Console.WriteLine($"Unknown type: {type}");
            }
        }
    }
}