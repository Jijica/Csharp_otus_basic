using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Stack
    {
        private int _stackSize = 0;
        private StackItem _lastNode = new StackItem(null!);

        public Stack(params string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Add(input[i]);
            }
        }

        public int Size => _stackSize;

        public string Top => _lastNode.Data;

        public void Add(string item)
        {
            var node = new StackItem(item);
            node.Previous = _lastNode;
            _lastNode = node;
            _stackSize++;
        }

        public string Pop()
        {
            var poppedValue = _lastNode.Data;
            if (_lastNode.Data == null)
            {
                throw new InvalidOperationException("Stack is already empty");
            }
            else if (_lastNode.Previous == null)
            {
                _lastNode.Data = null!;
            }
            else
            {
                _lastNode = _lastNode.Previous;
            }
            _stackSize--;
            return poppedValue;
        }

        public static Stack Concat(params Stack[] stacksToConcat)
        {
            var stackToReturn = new Stack();
            foreach (var stack in stacksToConcat) 
            {
                while (stack.Top != null)
                {
                    stackToReturn.Add(stack.Top);
                    stack._lastNode = stack._lastNode.Previous!;
                }
            }
            return stackToReturn;
        }

        class StackItem
        {
            public StackItem(string item)
            {
                Data = item;
            }

            public string Data
            {
                get; set;
            }

            public StackItem? Previous
            {
                get; set;
            }
        }
    }
}
