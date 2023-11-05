using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_usage
{
    internal class Orders : IPrintable
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public string GetPrintableText()
        {
            return $"Customer: id {CustomerID} ordered {Quantity} items of product: id {ProductID}";
        }
    }
}
