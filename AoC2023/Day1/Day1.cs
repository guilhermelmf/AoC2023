using System.Text.RegularExpressions;

namespace AoC2023.Day1;

public class Day1
{
    private static readonly Dictionary<string, int> Words =
        new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
        };

    private static Regex _regex = new(@"\d{1}");

    public int ResolvePart1(List<string> lines)
    {
        return lines.Sum(GetPartialSum);
    }

    public int ResolvePart2(List<string> lines)
    {
        return lines.Sum(GetSumAllKindOfNumbers);
    }

    private static int GetPartialSum(string line)
    {
        var matches = _regex.Matches(line);
        return matches.Count switch
        {
            >= 2 => int.Parse(matches.First().Value + matches.Last().Value),
            1 => int.Parse(matches.First().Value + matches.First().Value),
            _ => 0
        };
    }

    private static int GetSumAllKindOfNumbers(string line)
    {
        var firstIndex = line.Length;
        var lastIndex = -1;
        var firstDigit = 0;
        var lastDigit = 0;
        foreach (var word in Words)
        {
            var index = line.IndexOf(word.Key, StringComparison.InvariantCultureIgnoreCase);
            if (index == -1)
            {
                continue;
            }

            if (index < firstIndex)
            {
                firstDigit = word.Value;
                firstIndex = index;
            }

            var indexLast = line.LastIndexOf(word.Key, StringComparison.InvariantCultureIgnoreCase);
            if (indexLast > lastIndex)
            {
                lastDigit = word.Value;
                lastIndex = indexLast;
            }
        }

        return firstDigit * 10 + lastDigit;
    }
}
