namespace Caching
{
    public static class GlobalCounter
    {
        private static volatile int globalId = 0;

        public static int Next()
        {
            globalId++;
            return globalId;
        }
    }
}
