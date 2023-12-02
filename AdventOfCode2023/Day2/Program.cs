namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int redCubes = 12;
            const int greenCubes = 13;
            const int blueCubes = 14;

            var rawData = File.ReadAllLines("RawData.txt");

            List<Game> games = new List<Game>();
            foreach (var s in rawData)
            {
                var data = s.Split(':');
                var game = new Game(data[0].Trim(), data[1].Trim());
                games.Add(game);
            }

            var sum = games.Sum(game => game.IsValid(redCubes, greenCubes, blueCubes));
            Console.WriteLine($"Part 1: {sum}");
            Console.ReadLine();

            sum = games.Sum(game => game.Power());
            Console.WriteLine($"Part 2: {sum}");
            Console.ReadLine();
        }
    }
}
