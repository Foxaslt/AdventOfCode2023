using System.Collections.ObjectModel;

namespace Day4
{
    internal class Card
    {
        private string name;
        List<int> winning = new List<int>();
        List<int> myNumbers = new List<int>();
        List<Card> cards = new List<Card>();

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

        internal void BuildTree(ref ReadOnlyCollection<Card> readonlyList)
        {
            var numbers = myNumbers.Intersect(winning).ToArray();
            var index = readonlyList.IndexOf(this) + 1;
            var winningCards = readonlyList.Skip(index).Take(numbers.Length).ToArray();
            cards.AddRange(winningCards);
            foreach (var winningCard in winningCards)
            {
                winningCard.BuildTree(ref readonlyList);
            }
        }

        internal int GetCount()
        {
            var count = cards.Sum(card => card.GetCount());

            return 1 + count;
        }
    }
}
