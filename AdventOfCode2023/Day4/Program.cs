namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rawData = File.ReadAllLines("RawData.txt");

            List<Card> cards = rawData.Select(s => new Card(s)).ToList();

            //Console.WriteLine($"Part 1: {sum}");
            Console.ReadLine();
        }
    }
}
