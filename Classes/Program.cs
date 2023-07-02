namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var stack = new Stack("a", "b", "c");
            //StackReport(stack);
            //var deleted = stack.Pop();
            //Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {stack.Size}");
            //stack.Add("d");
            //StackReport(stack);
            //stack.Pop();
            //StackReport(stack);

            //var stackToMerge = new Stack("a", "b", "c");
            //stackToMerge.Merge(new Stack("1", "2", "3"));
            //StackReport(stackToMerge);
            //stackToMerge.Pop();
            //StackReport(stackToMerge);

            //var stackToConcat = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            //StackReport(stackToConcat);
            //stackToConcat.Pop();
            //StackReport(stackToConcat);
        }

        static void StackReport(Stack stack)
        {
            Console.WriteLine($"size = {stack.Size}, Top = {(stack.Top == null ? "null" : stack.Top)}");
        }
    }
}