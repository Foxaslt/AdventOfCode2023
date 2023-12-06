namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rawData = File.ReadAllLines("RawData.txt");

            List<Point> points = new List<Point>();
            for (int i = 0; i < rawData.Length; i++)
            {
                for (int j = 0; j < rawData[i].Length; j++)
                {
                    if (!char.IsNumber(rawData[i][j]) && rawData[i][j] != '.')
                    {
                        points.Add(new Point() { x = i, y = j });
                    }
                }
            }

            var sum = points.Sum(point => point.GetSum(rawData));
            Console.WriteLine($"Part 1: {sum}");
            Console.ReadLine();

            points = new List<Point>();
            for (int i = 0; i < rawData.Length; i++)
            {
                for (int j = 0; j < rawData[i].Length; j++)
                {
                    if (rawData[i][j] == '*' && IsGear(rawData, i, j))
                    {
                        points.Add(new Point() { x = i, y = j });
                    }
                }
            }
            Console.WriteLine($"Part 2: {sum}");
            Console.ReadLine();
        }

        private static bool IsGear(string[] rawData, int i, int j)
        {
            int count = 0;

            for (int z = 0; z < 3; z++)
            {
                for (int k = 0; k < 3; k++)
                {
                   
                }
            }

            if (count == 2) return true;
            return false;
        }
    }
}
