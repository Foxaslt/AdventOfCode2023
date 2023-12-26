namespace Day5
{
    internal static class LinkedListExtensions
    {
        public static long GetLocation(this LinkedList<Map> linkedList, long seed)
        {
            var map = linkedList.First;
            var last = linkedList.Last;
            var source = seed;
            do
            {
                source = map.Value.GetDestinationBySource(source);
                map = map.Next;
            } while (map != last.Next);

            return source;
        }
    }
}
