using System.Text.RegularExpressions;

namespace AoC2023.Day2;

public class Day2
{
    //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    private record Game(int Match, int Reds, int Blues, int Greens);

    private static readonly Regex GameNumber = new Regex("(?<=Game\\s)\\d{1,5}");
    private static readonly Regex GameBlue = new Regex("\\d{1,5}(?=\\sblue)");
    private static readonly Regex GameRed = new Regex("\\d{1,5}(?=\\sred)");
    private static readonly Regex GameGreen = new Regex("\\d{1,5}(?=\\sgreen)");

    public int ResolvePart1(List<string> lines, int maxReds, int maxBlues, int maxGreens)
    {
        var games = lines.Where(x=> !string.IsNullOrEmpty(x)).Select(ParseGame).ToList();

        return games
            .Where(x => x.Blues <= maxBlues &&
                        x.Reds <= maxReds &&
                        x.Greens <= maxGreens)
            .Sum(x=> x.Match);
    }
    public int ResolvePart2(List<string> lines)
    {
        var games = lines.Where(x=> !string.IsNullOrEmpty(x)).Select(ParseGame).ToList();

        return games.Sum(x=> x.Reds * x.Blues * x.Greens);
    }

    private Game ParseGame(string line)
    {
        var match = int.Parse(GameNumber.Match(line).Value);
        var sets = line.Split(":").Last().Split(";");
        var redMax = 0;
        var greenMax = 0;
        var blueMax = 0;
        foreach (var set in sets)
        {
            var value =$"0{GameRed.Match(set).Value}";
            var reds = int.Parse(value);
            if (reds > redMax)
            {
                redMax = reds;
            }

            value =$"0{GameBlue.Match(set).Value}";
            var blues = int.Parse(value);
            if (blues > blueMax)
            {
                blueMax = blues;
            }

            value =$"0{GameGreen.Match(set).Value}";
            var greens = int.Parse(value);
            if (greens > greenMax)
            {
                greenMax = greens;
            }
        }

        return new Game(match, redMax, blueMax, greenMax);
    }
}
