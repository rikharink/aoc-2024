namespace Aoc2024.Lib;

public class AocClient
{
    private readonly HttpClient _httpClient = new();

    public string GetInput(int year, int day)
    {
        var path = Path.Combine("input", $"{day}.txt");
        if (File.Exists(path)) return File.ReadAllText(path);

        var input = DownloadInput(year, day);
        CacheInput(day, input);
        return input;
    }

    private static string GetSessionToken()
    {
        var token = Environment.GetEnvironmentVariable("AOC_SESSION_TOKEN");
        if (!string.IsNullOrWhiteSpace(token)) return token;

        if (!File.Exists(".token"))
        {
            throw new InvalidOperationException("Session token not found");
        }

        token = File.ReadAllText(".token");
        if (!string.IsNullOrWhiteSpace(token)) return token;
        throw new InvalidOperationException("Session token not found");
    }

    private string DownloadInput(int year, int day)
    {
        var url = $"https://adventofcode.com/{year}/day/{day}/input";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Cookie", $"session={GetSessionToken()}");
        var response = _httpClient.Send(request);
        using var reader = new StreamReader(response.Content.ReadAsStream());
        return reader.ReadToEnd();
    }

    private static void CacheInput(int day, string input)
    {
        Directory.CreateDirectory("input");
        var path = Path.Combine("input", $"{day}.txt");
        File.WriteAllText(path, input);
    }
}