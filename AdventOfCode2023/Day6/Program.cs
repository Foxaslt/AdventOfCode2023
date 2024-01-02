namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Race> races = new List<Race>();
            var rawData = File.ReadAllLines("RawData.txt");
            var time = rawData[0].Split(':')[1].Trim().Split(' ').Where(m => !string.IsNullOrWhiteSpace(m));
            var distance = rawData[1].Split(':')[1].Trim().Split(' ').Where(m => !string.IsNullOrWhiteSpace(m));
        }
    }
}
