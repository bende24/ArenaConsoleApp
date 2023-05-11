namespace ArenaConsoleApp.InputValidations
{
    internal static class Precondition
    {
        /// <summary>
        /// Throws Exception if the requirement is false
        /// </summary>
        public static void Requires(bool requirement)
        {
            Requires<Exception>(requirement);
        }

        public static void Requires<TException>(bool requirement) where TException : Exception, new()
        {
            if (!requirement) { throw new TException(); }
        }
    }
}
