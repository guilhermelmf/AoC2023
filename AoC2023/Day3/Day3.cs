using System.Text.RegularExpressions;

namespace AoC2023.Day3;

public class Day3
{
    private static readonly Regex RegNumber = new Regex("\\d{1,5}");

    public int ResolvePart1(List<string> lines)
    {
        lines.Insert(0, CreateEmptyLine(lines.First().Length));
        lines.Add(CreateEmptyLine(lines.First().Length));

        var validNumbers = new List<int>();
        //We should not check the artificial lines added.
        for (var i = 1; i < lines.Count - 1; i++)
        {
            var currentLine = lines[i];
            var previousLine = lines[i - 1];
            var nextLine = lines[i + 1];

            validNumbers.AddRange(GrabValidNumbers(currentLine, previousLine, nextLine));
        }

        return validNumbers.Sum();
    }

    private List<int> GrabValidNumbers(string currentLine, string previousLine, string nextLine)
    {
        var valid = new List<int>();
        var matches = RegNumber.Matches(currentLine);
        foreach (Match match in matches)
        {
            var initialPos = match.Index <= 0 ? match.Index : match.Index - 1;
            var length = (match.Index + match.Length + 2) > currentLine.Length ? match.Length : match.Length + 2;
            try
            {
                //check same line
                if (HasSymbol(currentLine.Substring(initialPos, length)))
                {
                    valid.Add(int.Parse(match.Value));
                    continue;
                }

                //check previous line region
                if (HasSymbol(previousLine.Substring(initialPos, length)))
                {
                    valid.Add(int.Parse(match.Value));
                    continue;
                }

                //check next line region
                if (HasSymbol(nextLine.Substring(initialPos, length)))
                {
                    valid.Add(int.Parse(match.Value));
                    continue;
                }

                Console.WriteLine($"out [{match.Value}] ({currentLine.Substring(initialPos, length)}) from line [{currentLine}]");
            }
            catch (Exception)
            {
                Console.WriteLine($"ops [{match.Value}] ({currentLine.Substring(initialPos, length)}) from line [{currentLine}]");
                throw;
            }
        }

        return valid;
    }

    private static string CreateEmptyLine(int length) => new('.', length);
    private static bool HasSymbol(string text) => text.Any(c => !char.IsNumber(c) && c != '.');
}
