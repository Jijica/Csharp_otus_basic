using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_usage
{
    internal class Dapper
    {
        internal static IEnumerable<T> GetItems<T>()
        {
            string query = null;
            Type type = typeof(T);

            if (type == typeof(Customers))
            {
                query = @"SELECT firstname, lastname, age FROM customers";
            }
            else if (type == typeof(Products))
            {
                query = @"SELECT name, description, stockquantity, price FROM products";
            }
            else if (type == typeof(Orders))
            {
                query = @"SELECT customerid, productid, quantity FROM orders";
            }

            using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
            {
                return connection.Query<T>(query);
            }
        }

        internal static T GetItemByID<T>(int id)
        {
            string query = null;
            Type type = typeof(T);

            if (type == typeof(Customers))
            {
                query = @"SELECT firstname, lastname, age FROM customers WHERE id = @id";
            }
            else if (type == typeof(Products))
            {
                query = @"SELECT name, description, stockquantity, price FROM products WHERE id = @id";
            }
            else if (type == typeof(Orders))
            {
                query = @"SELECT customerid, productid, quantity FROM orders WHERE id = @id";
            }

            if (query != null)
            {
                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    return connection.QueryFirstOrDefault<T>(query, new { id });
                }
            }
            else
            {
                return default(T);
            }
        }

        internal static int? CountItems<T>()
        {
            Type type = typeof(T);
            string query = null;

            if (type == typeof(Customers))
            {
                query = @"SELECT COUNT(*) FROM customers ";
            }
            else if (type == typeof(Products))
            {
                query = @"SELECT COUNT(*) FROM products ";
            }
            else if (type == typeof(Orders))
            {
                query = @"SELECT COUNT(*) FROM orders ";
            }
            else
            {
                Console.WriteLine($"Unknown type: {type}");
            }

            if (query != null)
            {
                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    return connection.ExecuteScalar<int>(query);
                }
            }
            else { return default(int?); }
        }

        internal static void InsertItem<T>(T item)
        {
            string query = null;
            Type type = typeof(T);

            if (type == typeof(Customers))
            {
                Customers customer = (Customers)(object)item;
                query = $"INSERT INTO customers (firstname, lastname, age) VALUES (@firstname, @lastname, @age)";
                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    connection.Execute(query, new { firstname = customer.FirstName, lastname = customer.LastName, age = customer.Age });
                }
                Console.WriteLine($"Элемент {typeof(T)} вставлен в таблицу customers");
            }
            else if (type == typeof(Products))
            {
                Products product = (Products)(object)item;
                query = $"INSERT INTO products (name, description, stockquantity, price) VALUES (@name, @description, @stockquantity, @price)";
                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    connection.Execute(query, new { name = product.Name, description = product.Description, stockquantity = product.StockQuantity, price = product.Price });
                }
                Console.WriteLine($"Элемент {typeof(T)} вставлен в таблицу products");
            }
            else if (type == typeof(Orders))
            {
                Orders order = (Orders)(object)item;
                query = $"INSERT INTO orders (customerid, productid, quantity) VALUES (@customerid, @productid, @quantity)";
                using (var connection = new NpgsqlConnection(Config.SqlConnectionString))
                {
                    connection.Execute(query, new { customerid = order.CustomerID, productid = order.ProductID, quantity = order.Quantity });
                }
                Console.WriteLine($"Элемент {typeof(T)} вставлен в таблицу orders");
            }
            else
            {
                Console.WriteLine($"Unknown type: {type}");
            }
        }
    }
}