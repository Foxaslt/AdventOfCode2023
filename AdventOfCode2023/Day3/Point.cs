namespace Day3
{
    internal class Point
    {
        public int x; public int y;

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

            List<char> charsLeft = new List<char>();
            List<char> charsRight = new List<char>();
            if (char.IsNumber(rawData[x + 1][y - 1]))
            {
                int i = y - 1;
                while (i > 0 && char.IsNumber(rawData[x + 1][i]))
                {
                    charsLeft.Insert(0, rawData[x + 1][i]);
                    i--;
                }
            }

            if (char.IsNumber(rawData[x + 1][y + 1]))
            {
                int i = y + 1;
                while (i < rawData[x + 1].Length && char.IsNumber(rawData[x + 1][i]))
                {
                    charsRight.Add(rawData[x + 1][i]);
                    i++;
                }
            }

            return (charsLeft.Count == 0 ? 0 : int.Parse(new string(charsLeft.ToArray()))) +
                (charsRight.Count == 0 ? 0 : int.Parse(new string(charsRight.ToArray())));
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

            List<char> charsLeft = new List<char>();
            List<char> charsRight = new List<char>();
            if (char.IsNumber(rawData[x - 1][y - 1]))
            {
                int i = y - 1;
                while (i > 0 && char.IsNumber(rawData[x - 1][i]))
                {
                    charsLeft.Insert(0, rawData[x - 1][i]);
                    i--;
                }
            }

            if (char.IsNumber(rawData[x - 1][y + 1]))
            {
                int i = y + 1;
                while (i < rawData[x - 1].Length && char.IsNumber(rawData[x - 1][i]))
                {
                    charsRight.Add(rawData[x - 1][i]);
                    i++;
                }
            }

            return (charsLeft.Count == 0 ? 0 : int.Parse(new string(charsLeft.ToArray()))) +
                (charsRight.Count == 0 ? 0 : int.Parse(new string(charsRight.ToArray())));
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
    }
}
