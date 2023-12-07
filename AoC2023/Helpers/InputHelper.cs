using System.Net;

namespace AoC2023.Helpers;

public static class InputHelper
{
    private static Uri GetUrl(string day) => new Uri($"https://adventofcode.com/2023/day/{day}/input");

    public static async Task<List<string>> GetDataLines(int day, string sessionId)
    {
        var text = await GetData(day, sessionId);
        return text.Split("\n").ToList();
    }

    public static async Task<string> GetData(int day, string sessionId)
    {
        var url = GetUrl(day.ToString());
        var cookieContainer = new CookieContainer();
        using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler);
        cookieContainer.Add(url, new Cookie("session", sessionId));
        return await client.GetStringAsync(url);
    }
    
}