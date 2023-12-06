namespace Day2
{
    internal class GameSet
    {
        private int? redItem;
        private int? greenItem;
        private int? blueItem;

        public int? Red => redItem;
        public int? Green => greenItem;
        public int? Blue => blueItem;

        public GameSet(string gameSet)
        {
            var sets = gameSet.Split(',');
            foreach (var set in sets)
            {
                var color = set.Trim().Split(' ');
                AddColor(color);
            }
        }

        private void AddColor(string[] color)
        {
            int count = int.Parse(color[0].Trim());
            var c = color[1].Trim();
            switch (c)
            {
                case "red":
                    redItem = count;
                    break;
                case "green":
                    greenItem = count;
                    break;
                case "blue":
                    blueItem = count;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsValid(int red, int green, int blue)
        {
            if ((!redItem.HasValue || redItem.HasValue && redItem.Value <= red) &&
                (!greenItem.HasValue || greenItem.HasValue && greenItem.Value <= green) &&
                (!blueItem.HasValue || blueItem.HasValue && blueItem.Value <= blue))
            {
                return true;
            }
            return false;
        }
    }
}
