using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal static class StackExtensions
    {
        public static void Merge (this Stack stack, Stack stackToAdd)
        {
            while (stackToAdd.Top != null) 
            {
                stack.Add(stackToAdd.Top);
                stackToAdd.Pop();
            }
        }
    }
}
