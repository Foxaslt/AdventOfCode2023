namespace Day3
{
    internal class Point(int x, int y)
    {
        List<int> top = new List<int>();
        List<int> mid = new List<int>();
        List<int> bottom = new List<int>();

        internal decimal GetSum(string[] rawData)
        {
            int leftNumber = GetLeft(rawData);
            int rightNumber = GetRight(rawData);
            int topNumber = GetTop(rawData);
            int bottomNumber = GetBottom(rawData);

            return leftNumber + rightNumber + topNumber + bottomNumber;
        }

        private int GetBottom(string[] rawData)
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

                return chars.Count == 0 ? 0 : int.Parse(new string(chars.ToArray()));
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

            return bottomLeft + bottomRight;
        }

        private int GetTop(string[] rawData)
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

                return chars.Count == 0 ? 0 : int.Parse(new string(chars.ToArray()));
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

            return topLeft + topRight;
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

        private int GetRight(string[] rawData)
        {
            List<char> chars = new List<char>();
            int i = y + 1;
            while (i < rawData[x].Length && char.IsNumber(rawData[x][i]))
            {
                chars.Add(rawData[x][i]);
                i++;
            }

            return chars.Count == 0 ? 0 : int.Parse(new string(chars.ToArray()));
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

        private int GetLeft(string[] rawData)
        {
            List<char> chars = new List<char>();
            int i = y - 1;
            while (i > 0 && char.IsNumber(rawData[x][i]))
            {
                chars.Insert(0, rawData[x][i]);
                i--;
            }

            return chars.Count == 0 ? 0 : int.Parse(new string(chars.ToArray()));
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
            mid.Add(GetLeft(rawData));
            mid.Add(GetRight(rawData));

            return top.Count + mid.Count + bottom.Count == 2;
        }

        //public int GetMultiply(string[] rawData)
        //{
        //    var top.Join()
        //}
    }
}
