namespace Day5
{
    internal class Seed(long start, long range)
    {
        internal long Minimum(LinkedList<Map> maps)
        {
            var min = long.MaxValue;
            for (long i = start; i < start + range - 1; i++)
            {
                var current = maps.GetLocation(i);
                if (current < min)
                    min = current;
            }

            return min;
        }
    }
}
