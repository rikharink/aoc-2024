namespace Aoc2024;

public class Day9(string? input = null) : Day(input)
{
    private readonly record struct DiskNode(long? Id, int Size);

    public long?[] Disk { get; set; } = null!;
    private static readonly long? NoId = null;
    private List<DiskNode> Nodes { get; set; } = null!;

    protected override void ParseInput()
    {
        Nodes = Input.Trim().ToCharArray().Select((c, i) =>
            new DiskNode(i % 2 == 0 ? i / 2 : NoId,
                int.Parse(c.ToString()))
        ).ToList();

        Disk = new long?[Nodes.Sum(d => d.Size)];
        var i = 0;
        foreach (var (id, size) in Nodes)
        {
            for (var ni = 0; ni < size; ni++)
            {
                Disk[i++] = id;
            }
        }
    }

    public static string DiskString(long?[] disk) => string.Join("", disk.Select(d => d.HasValue ? d.ToString() : "."));

    public long?[] Defragment()
    {
        var defragmented = Disk.Select(i => i).ToArray();
        for (var i = defragmented.Length - 1; i >= 0; i--)
        {
            if (defragmented[i] == NoId) continue;
            var freeSpaceIndex = FindFirstFreeSpace(defragmented);
            if (freeSpaceIndex > i) break;
            Helpers.Swap(defragmented, freeSpaceIndex, i);
        }

        return defragmented;
    }

    public long?[] DefragmentSmart()
    {
        var defragmented = Disk.Select(i => i).ToArray();
        var maxId = Nodes.Max(n => n.Id ?? long.MinValue);
        for (var id = maxId; id >= 0; id--)
        {
            var start = FindStartById(defragmented, id);
            var size = Nodes.First(n => n.Id == id).Size;
            var freeSpace = FindFirstFreeSpace(defragmented, size);
            if (freeSpace < 0 || freeSpace > start) continue;
            Helpers.Swap(defragmented, start, freeSpace, size);
        }

        return defragmented;
    }

    public override string Part1() => Defragment().Select((id, i) => (id ?? 0) * i).Sum().ToString();
    public override string Part2() => DefragmentSmart().Select((id, i) => (id ?? 0) * i).Sum().ToString();

    public static int FindFirstFreeSpace(long?[] disk, int size = 1) => disk.FindFirstRunOfSize((i) => i == NoId, size);

    private static int FindStartById(long?[] disk, long id) => Array.FindIndex(disk, d => d == id);
}