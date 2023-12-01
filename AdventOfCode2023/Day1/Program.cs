using System.Globalization;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = File.ReadAllLines("RawData.txt");

            int sum = (from s in rawData
                select s.ToCharArray().Where(char.IsDigit).ToArray()
                into arr
                select LineSum(arr)
                ).Sum();

            Console.WriteLine($"Part 1: {sum}"); // 54605
            Console.ReadKey();

            sum = rawData.Sum(s => LineSum(GetChars(s)));

            Console.WriteLine($"Part 2: {sum}");
            Console.ReadKey();
        }

        private static char[] GetChars(string s)
        {
            int i = 0;
            List<char> arr = new List<char>();
            while (i < s.Length)
            {
                if (char.IsDigit(s[i]))
                {
                    arr.Add(s[i]);
                    i++;
                    continue;
                }

                if (HasAny(s.AsSpan(i), out string n, out char r))
                {
                    arr.Add(r);
                    i += n.Length;
                    continue;
                }

                i++;
            }

            return arr.ToArray();
        }

        private static int LineSum(char[] arr)
        {
            var first = First(arr);
            var last = Last(arr);
            return int.Parse(new string(new[] { first, last }));
        }

        private static bool HasAny(ReadOnlySpan<char> chars, out string number, out char r)
        {
            foreach (var n in numbers)
            {
                if (chars.StartsWith(n))
                {
                    if (Enum.TryParse(n, out Map result))
                    {
                        r = char.Parse(((int)result).ToString());
                        number = n;
                        return true;
                    }
                }
            }

            number = string.Empty;
            r = '0';
            return false;
        }


        private static char First(char[] chars)
        {
            return chars[0];
        }

        private static char Last(char[] chars)
        {
            return chars[chars.Length - 1];
        }

        private static readonly string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        private enum Map : int
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9
        }
    }
}
