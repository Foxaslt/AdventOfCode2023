namespace Day3
{
    internal class Point(int x, int y)
    {
        List<int> top = new List<int>();
        List<int> mid = new List<int>();
        List<int> bottom = new List<int>();

        internal int GetSum(string[] rawData)
        {
            var leftNumber = GetLeft(rawData);
            var rightNumber = GetRight(rawData);
            int topNumber = GetTopSum(rawData);
            int bottomNumber = GetBottomSum(rawData);

            return (leftNumber ?? 0) + (rightNumber ?? 0) + topNumber + bottomNumber;
        }

        private int GetBottomSum(string[] rawData)
        {
            return GetBottomAsList(rawData).Sum();
        }

        private int GetTopSum(string[] rawData)
        {
            return GetTopAsList(rawData).Sum();
        }

        private int[] GetBottomAsList(string[] rawData)
        {
            int z = x + 1;
            return GetNumbers(rawData, z);
        }

        private int[] GetTopAsList(string[] rawData)
        {
            int z = x - 1;
            return GetNumbers(rawData, z);
        }

        private int[] GetNumbers(string[] rawData, int z)
        {
            if (char.IsNumber(rawData[z][y]))
            {
                return GetSingleNumber(rawData, z);
            }

            int? topLeft = null; int? topRight = null;
            if (char.IsNumber(rawData[z][y - 1]))
            {
                topLeft = Left(rawData, z);
            }

            if (char.IsNumber(rawData[z][y + 1]))
            {
                topRight = Right(rawData, z);
            }

            var list = new List<int>();
            if (topLeft.HasValue) { list.Add(topLeft.Value); }
            if (topRight.HasValue) { list.Add(topRight.Value); }

            return list.ToArray();
        }

        private int[] GetSingleNumber(string[] rawData, int z)
        {
            List<char> chars = new List<char> { rawData[z][y] };

            int i = y + 1;
            while (i < rawData[z].Length && char.IsNumber(rawData[z][i]))
            {
                chars.Add(rawData[z][i]);
                i++;
            }

            i = y - 1;
            while (i > 0 && char.IsNumber(rawData[z][i]))
            {
                chars.Insert(0, rawData[z][i]);
                i--;
            }

            return chars.Count == 0 ? Array.Empty<int>() : new int[] { int.Parse(new string(chars.ToArray())) };
        }

        private int? GetRight(string[] rawData)
        {
            int z = x;
            return Right(rawData, z);
        }

        private int? Right(string[] rawData, int z)
        {
            List<char> charsRight = new List<char>();
            int i = y + 1;
            while (i < rawData[z].Length && char.IsNumber(rawData[z][i]))
            {
                charsRight.Add(rawData[z][i]);
                i++;
            }

            return charsRight.Count == 0 ? null : int.Parse(new string(charsRight.ToArray()));
        }

        private int? GetLeft(string[] rawData)
        {
            int z = x;
            return Left(rawData, z);
        }

        private int? Left(string[] rawData, int z)
        {
            List<char> charsLeft = new List<char>();
            int i = y - 1;
            while (i > 0 && char.IsNumber(rawData[z][i]))
            {
                charsLeft.Insert(0, rawData[z][i]);
                i--;
            }

            return charsLeft.Count == 0 ? null : int.Parse(new string(charsLeft.ToArray()));
        }

        internal bool IsGear(string[] rawData)
        {
            top.AddRange(GetTopAsList(rawData));
            var leftMid = GetLeft(rawData);
            if (leftMid != null) mid.Add(leftMid.Value);
            var rightMid = GetRight(rawData);
            if (rightMid != null) mid.Add(rightMid.Value);
            bottom.AddRange(GetBottomAsList(rawData));

            return top.Count + mid.Count + bottom.Count == 2;
        }

        internal int GetMultiply(string[] rawData)
        {
            var x = top.Concat(mid).Concat(bottom);
            return x.Aggregate((a, y) => a * y);
        }
    }
}
