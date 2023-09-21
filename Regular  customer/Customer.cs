using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regular_customer
{
    internal class Customer
    {
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var itemAdded = (Shop.Item)e.NewItems[0];                                       //Не придумал как здесь обойтись без явного каста
                    Console.WriteLine($"Добавлен товар: {itemAdded.Name}, id: {itemAdded.Id}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var itemRemoved = (Shop.Item)e.OldItems[0];
                    Console.WriteLine($"Удален товар: {itemRemoved.Name}, id: {itemRemoved.Id}");
                    break;
            }
        }
    }
}
