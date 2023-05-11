namespace ArenaConsoleApp.ExtensionMethods
{
    public static class IEnumerableExtensionMethods
    {
        public static bool IsNotEmpty<T>(this IEnumerable<T> data)
        {
            return data.Any();
        }
    }
}
