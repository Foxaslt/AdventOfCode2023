namespace Day2
{
    internal class Game
    {
        private readonly int id;
        private readonly List<GameSet> gameSets = new List<GameSet>();

        public Game(string game, string data)
        {
            var gameData = game.Split(' ');
            id = int.Parse(gameData[1]);

            var sets = data.Split(';');
            foreach (var set in sets)
            {
                var gameSet = new GameSet(set.Trim());
                gameSets.Add(gameSet);  
            }
        }

        public int IsValid(int red, int green, int blue)
        {
            return gameSets.All(set => set.IsValid(red, green, blue)) ? id : 0;
        }

        public int Power()
        {
            int redPower = gameSets.Where(set => set.Red.HasValue).Max(set => set.Red.Value);
            int greenPower = gameSets.Where(set => set.Green.HasValue).Max(set => set.Green.Value);
            int bluePower = gameSets.Where(set => set.Blue.HasValue).Max(set => set.Blue.Value);
            return redPower * greenPower * bluePower;
        }
    }
}
