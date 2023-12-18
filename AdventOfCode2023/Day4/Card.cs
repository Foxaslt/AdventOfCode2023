namespace Day4
{
    internal class Card
    {
        private string name;
        List<int> winning = new List<int>();
        List<int> myNumbers = new List<int>();

        public Card(string s)
        {
            var data = s.Split(':');
            name = data[0].Trim();

            var numbers = data[1].Split('|');
            winning.AddRange(numbers[0].Trim().Split(' ').Where(n => !string.IsNullOrEmpty(n)).Select(int.Parse));
            myNumbers.AddRange(numbers[1].Trim().Split(' ').Where(n => !string.IsNullOrEmpty(n)).Select(int.Parse));
        }

        internal int GetSum()
        {
            var numbers = myNumbers.Intersect(winning).ToArray();
            int points = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    points = 1;
                    continue;
                }

                points *= 2;
            }
            return points;
        }
    }
}
