namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            StackElementsView(stack);
            StackReport(stack);
        }

        static void StackReport(Stack stack)
        {
            Console.WriteLine($"size = {stack.Size}, Top = {(stack.Top == null ? "null" : stack.Top)}");
        }

        static void StackElementsView(Stack stack)
        {
            foreach (var item in stack.StackToList(stack))
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}