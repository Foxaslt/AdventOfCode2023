namespace Day3
{
    internal class Point(int x, int y)
    {
        List<int> top = new List<int>();
        List<int> mid = new List<int>();
        List<int> bottom = new List<int>();

        internal decimal GetSum(string[] rawData)
        {
            var leftNumber = GetLeft(rawData);
            var rightNumber = GetRight(rawData);
            int topNumber = GetTopSum(rawData);
            int bottomNumber = GetBottomSum(rawData);

            return (leftNumber ?? 0) + (rightNumber ?? 0) + topNumber + bottomNumber;
        }

        private int GetBottomSum(string[] rawData)
        {
            int result = 0;
            foreach (var i in GetBottomAsList(rawData))
            {
                result += i;
            }

            return result;
        }

        private int GetTopSum(string[] rawData)
        {
            int result = 0;
            foreach (var i in GetTopAsList(rawData))
            {
                result += i;
            }

            return result;
        }

        private List<int> GetBottomAsList(string[] rawData)
        {
            if (char.IsNumber(rawData[x + 1][y]))
            {
                List<char> chars = new List<char> { rawData[x + 1][y] };

                int i = y + 1;
                while (i < rawData[x + 1].Length && char.IsNumber(rawData[x + 1][i]))
                {
                    chars.Add(rawData[x + 1][i]);
                    i++;
                }

                i = y - 1;
                while (i > 0 && char.IsNumber(rawData[x + 1][i]))
                {
                    chars.Insert(0, rawData[x + 1][i]);
                    i--;
                }

                return chars.Count == 0 ? new List<int>() : new List<int>() { int.Parse(new string(chars.ToArray())) };
            }

            int bottomLeft = 0; int bottomRight = 0;
            if (char.IsNumber(rawData[x + 1][y - 1]))
            {
                bottomLeft = GetBottomLeft(rawData);
            }

            if (char.IsNumber(rawData[x + 1][y + 1]))
            {
                bottomRight = GetBottomRight(rawData);
            }

            var list = new List<int>();
            if (bottomLeft != 0) { list.Add(bottomLeft); }
            if (bottomRight != 0) { list.Add(bottomRight); }

            return list;
        }

        private List<int> GetTopAsList(string[] rawData)
        {
            if (char.IsNumber(rawData[x - 1][y]))
            {
                List<char> chars = new List<char> { rawData[x - 1][y] };

                int i = y + 1;
                while (i < rawData[x - 1].Length && char.IsNumber(rawData[x - 1][i]))
                {
                    chars.Add(rawData[x - 1][i]);
                    i++;
                }

                i = y - 1;
                while (i > 0 && char.IsNumber(rawData[x - 1][i]))
                {
                    chars.Insert(0, rawData[x - 1][i]);
                    i--;
                }

                return chars.Count == 0 ? new List<int>() : new List<int>() { int.Parse(new string(chars.ToArray())) };
            }

            int topLeft = 0; int topRight = 0;
            if (char.IsNumber(rawData[x - 1][y - 1]))
            {
                topLeft = GetTopLeft(rawData);
            }

            if (char.IsNumber(rawData[x - 1][y + 1]))
            {
                topRight = GetTopRight(rawData);
            }

            var list = new List<int>();
            if (topLeft != 0) { list.Add(topLeft); }
            if (topRight != 0) { list.Add(topRight); }

            return list;
        }

        private int GetTopRight(string[] rawData)
        {
            List<char> charsRight = new List<char>();
            int i = y + 1;
            while (i < rawData[x - 1].Length && char.IsNumber(rawData[x - 1][i]))
            {
                charsRight.Add(rawData[x - 1][i]);
                i++;
            }

            var topRight = charsRight.Count == 0 ? 0 : int.Parse(new string(charsRight.ToArray()));
            return topRight;
        }

        private int? GetRight(string[] rawData)
        {
            List<char> chars = new List<char>();
            int i = y + 1;
            while (i < rawData[x].Length && char.IsNumber(rawData[x][i]))
            {
                chars.Add(rawData[x][i]);
                i++;
            }

            return chars.Count == 0 ? null : int.Parse(new string(chars.ToArray()));
        }

        private int GetTopLeft(string[] rawData)
        {
            List<char> charsLeft = new List<char>();
            int i = y - 1;
            while (i > 0 && char.IsNumber(rawData[x - 1][i]))
            {
                charsLeft.Insert(0, rawData[x - 1][i]);
                i--;
            }

            var topLeft = charsLeft.Count == 0 ? 0 : int.Parse(new string(charsLeft.ToArray()));
            return topLeft;
        }

        private int GetBottomRight(string[] rawData)
        {
            List<char> charsRight = new List<char>();
            int i = y + 1;
            while (i < rawData[x + 1].Length && char.IsNumber(rawData[x + 1][i]))
            {
                charsRight.Add(rawData[x + 1][i]);
                i++;
            }

            var bottomRight = charsRight.Count == 0 ? 0 : int.Parse(new string(charsRight.ToArray()));
            return bottomRight;
        }

        private int? GetLeft(string[] rawData)
        {
            List<char> chars = new List<char>();
            int i = y - 1;
            while (i > 0 && char.IsNumber(rawData[x][i]))
            {
                chars.Insert(0, rawData[x][i]);
                i--;
            }

            return chars.Count == 0 ? null : int.Parse(new string(chars.ToArray()));
        }

        private int GetBottomLeft(string[] rawData)
        {
            List<char> charsLeft = new List<char>();
            int i = y - 1;
            while (i > 0 && char.IsNumber(rawData[x + 1][i]))
            {
                charsLeft.Insert(0, rawData[x + 1][i]);
                i--;
            }

            var bottomLeft = charsLeft.Count == 0 ? 0 : int.Parse(new string(charsLeft.ToArray()));
            return bottomLeft;
        }

        public bool IsGear(string[] rawData)
        {
            top.AddRange(GetTopAsList(rawData));
            var leftMid = GetLeft(rawData);
            if (leftMid != null) mid.Add(leftMid.Value);
            var rightMid = GetRight(rawData);
            if (rightMid != null) mid.Add(rightMid.Value);
            bottom.AddRange(GetBottomAsList(rawData));

            return top.Count + mid.Count + bottom.Count == 2;
        }

        public int GetMultiply(string[] rawData)
        {
            var x = top.Concat(mid).Concat(bottom);
            return x.Aggregate((a, y) => a * y);
        }
    }
}
