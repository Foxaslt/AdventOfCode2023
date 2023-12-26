namespace Day5
{
    internal class Range (long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        public long? GetDestinationBySource(long source)
        {
            if (source >= sourceRangeStart && source <= sourceRangeStart + rangeLength - 1)
            {
                return destinationRangeStart + source - sourceRangeStart;
            }

            return null;
        }
    }
}
