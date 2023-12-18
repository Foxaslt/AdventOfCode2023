namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rawData = File.ReadAllLines("RawData.txt");

            List<Card> cards = rawData.Select(s => new Card(s)).ToList();

            var sum = cards.Sum(c => c.GetSum());
            Console.WriteLine($"Part 1: {sum}");
            //Console.ReadLine();

            var readonlyList = cards.AsReadOnly();
            foreach (var card in cards)
            {
                card.BuildTree(ref readonlyList);
            }

            sum = cards.Sum(s => s.GetCount());
            Console.WriteLine($"Part 2: {sum}");
            Console.ReadLine();
        }
    }
}
