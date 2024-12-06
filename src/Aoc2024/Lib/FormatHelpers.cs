namespace Aoc2024.Lib;

public static class FormatHelpers
{
    public static string Bytes(long bytes)
    {
        // Define size suffixes
        string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

        int suffixIndex = 0;
        double readableBytes = bytes;

        // Loop until the bytes fit into the current suffix
        while (readableBytes >= 1024 && suffixIndex < suffixes.Length - 1)
        {
            readableBytes /= 1024;
            suffixIndex++;
        }

        // Format to two decimal places for readability
        return $"{readableBytes:0.##} {suffixes[suffixIndex]}";
    }
    
    public static string Time(TimeSpan time)
    {
        return time.TotalMilliseconds switch
        {
            < 0.1 => $"{time.TotalNanoseconds:0.##} ns",
            < 1 => $"{time.TotalMicroseconds:0.##} μs",
            < 1000 => $"{time.TotalMilliseconds:0.##} ms",
            _ => $"{time.TotalSeconds:0.##} s"
        };
    }
    
}