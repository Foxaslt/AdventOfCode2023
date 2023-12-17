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

    }
}
