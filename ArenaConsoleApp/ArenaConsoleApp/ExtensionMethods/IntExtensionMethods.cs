namespace ArenaConsoleApp.ExtensionMethods
{
    internal static class IntExtensionMethods
    {
        public static bool IsOdd(this int value)
        {
            return !(value % 2 == 0);
        }
    }
}
