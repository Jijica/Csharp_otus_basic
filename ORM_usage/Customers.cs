using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_usage
{
    internal class Customers : IPrintable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string GetPrintableText()
        {
            return $"{FirstName} {LastName}, {Age} years";
        }
    }
}
