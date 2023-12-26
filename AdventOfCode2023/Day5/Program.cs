using System.Diagnostics;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> seeds = new List<long>();
            LinkedList<Map> maps = new LinkedList<Map>();
            var rawData = File.ReadAllLines("RawData.txt");

            var l = rawData[0].Split(':')[1].Trim().Split(' ').Select(long.Parse);
            seeds.AddRange(l);

            int i = 2;
            var d = rawData.Skip(i).TakeWhile((s, b) => !string.IsNullOrEmpty(s));
            while (d.Any())
            {
                if (maps.Count == 0)
                {
                    maps.AddFirst(new Map(d.ToList()));
                }
                else
                {
                    maps.AddLast(new Map(d.ToList()));
                }

                i += d.Count() + 1;
                d = rawData.Skip(i).TakeWhile((s, b) => !string.IsNullOrEmpty(s));
            }

            var clock = new Stopwatch();
            clock.Start();
            long min = seeds.Min(m => maps.GetLocation(m));
            clock.Stop();
            Console.WriteLine($"Part 1: {min}, ms: {clock.ElapsedMilliseconds}");

            var s = rawData[0].Split(':')[1].Trim().Split(' ');
            List<Seed> seeds2 = new List<Seed>();
            for (int j = 0; j < s.Length; j += 2)
            {
                seeds2.Add(new Seed(long.Parse(s[j]), long.Parse(s[j+1])));
            }

            clock.Start();
            min = seeds2.AsParallel().Min(s => s.Minimum(maps));
            clock.Stop();
            Console.WriteLine($"Part 2: {min}, ms: {clock.ElapsedMilliseconds}");
        }
    }
}
