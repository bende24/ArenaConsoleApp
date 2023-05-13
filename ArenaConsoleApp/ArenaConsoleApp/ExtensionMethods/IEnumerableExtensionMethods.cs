namespace ArenaConsoleApp.ExtensionMethods
{
    public static class IEnumerableExtensionMethods
    {
        public static bool IsNotEmpty<T>(this IEnumerable<T> data)
        {
            return data.Any();
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> data, Action<T> doAction)
        {
            foreach(var item in data)
            {
                doAction(item);
            }

            return data;
        }
    }
}
