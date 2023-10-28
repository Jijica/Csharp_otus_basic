using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_usage
{
    internal class Products : IPrintable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price {get; set; }

        public string GetPrintableText()
        {
            return $"{Name}: \"{Description}\", {StockQuantity} items, {Price} $";
        }
    }
}
