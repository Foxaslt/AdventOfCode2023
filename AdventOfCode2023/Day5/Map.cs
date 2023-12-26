namespace Day5
{
    internal class Map
    {
        private string sourceCategory;
        private string destinationCategory;
        private List<Range> _ranges = new List<Range>();

        public Map(IList<string> data)
        {
            var categories = data[0].Split(' ')[0].Split("-to-");
            sourceCategory = categories[0];
            destinationCategory = categories[1];

            for (int i = 1; i < data.Count; i++)
            {
                var ranges = data[i].Split(' ');
                _ranges.Add(new Range(long.Parse(ranges[0]), long.Parse(ranges[1]), long.Parse(ranges[2])));
            }
        }

        public string SourceCategory => sourceCategory;

        public string DestinationCategory => destinationCategory;

        public long GetDestinationBySource(long source)
        {
            foreach (var range in _ranges)
            {
                var destination = range.GetDestinationBySource(source);
                if (destination != null)
                    return destination.Value;
            }

            return source;
        }
    }
}
