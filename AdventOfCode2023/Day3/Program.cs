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
                        points.Add(new Point(i, j));
                    }
                }
            }

            var sum = points.Sum(point => point.GetSum(rawData)); // 520019
            Console.WriteLine($"Part 1: {sum}");
            Console.ReadLine();

            points = new List<Point>();
            for (int i = 0; i < rawData.Length; i++)
            {
                for (int j = 0; j < rawData[i].Length; j++)
                {
                    if (rawData[i][j] == '*')
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }

            //var sum = points.Where(point => point.IsGear(rawData)).Sum(point => point.GetMultiply(rawData));
            Console.WriteLine($"Part 2: {sum}");
            Console.ReadLine();
        }
    }
}
