namespace LINQ_method
{
    internal static class MyExtensions
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percentage)
        {
            if (percentage < 1 || percentage > 100)
            {
                throw new ArgumentException($"Argument '{nameof(percentage)}' must be within the range 1 to 100");
            }
            int elementsToTake = (int)Math.Round(percentage / 100.0 * collection.Count());
            return (from el in collection
                    orderby el descending
                    select el).Take(elementsToTake);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percentage, Func<T, int> func)
        {
            if (percentage < 1 || percentage > 100)
            {
                throw new ArgumentException($"Argument '{nameof(percentage)}' must be within the range 1 to 100");
            }
            int elementsToTake = (int)Math.Round(percentage / 100.0 * collection.Count());
            return (IEnumerable<T>)collection
                .Take(elementsToTake)
                .Select(func)
                .OrderDescending();
        }
    }
}
