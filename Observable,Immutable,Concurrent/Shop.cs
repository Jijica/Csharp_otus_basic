using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regular_customer
{
    internal class Shop
    {
        private ObservableCollection<Item> _shopItemsObservable;

        public Shop() { _shopItemsObservable = new ObservableCollection<Item>(); }

        public ObservableCollection<Item> ShopItems { get => _shopItemsObservable; set { } }

        public void Add()
        {
            _shopItemsObservable.Add(new Item { Name = $"Товар от <{DateTime.Now}>", Id = DateTime.Now.GetHashCode().ToString() });
        }

        public void Remove(string id)
        {
            bool itemIsFound = false;
            foreach (Item item in _shopItemsObservable)
            {
                if (item.Id == id)
                {
                    _shopItemsObservable.Remove(item);
                    itemIsFound = true;
                    break;
                }
            }
            if (!itemIsFound) 
            {
                Console.WriteLine("Товар не найден");
            }
        }

        public class Item
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
