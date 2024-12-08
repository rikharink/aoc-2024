namespace Aoc2024.Lib;

public static class Helpers
{
    public static IEnumerable<List<T>> Combinations<T>(List<T> input, int length)
    {
        if (length < 0) throw new ArgumentException("Length must be greater than or equal to 0");
        if (length > input.Count) throw new ArgumentException("Length must be less than or equal to the input length");
        return CombinationsRecursive(input, length);
    }

    private static IEnumerable<List<T>> CombinationsRecursive<T>(List<T> list, int length)
    {
        if (length == 0)
        {
            yield return [];
            yield break;
        }

        if (list.Count == 0)
        {
            yield break;
        }

        var first = list[0];
        var remainingList = list.Skip(1).ToList();
        foreach (var combination in CombinationsRecursive(remainingList, length))
        {
            yield return combination;
        }

        foreach (var combination in CombinationsRecursive(remainingList, length - 1))
        {
            var newCombination = new List<T> { first };
            newCombination.AddRange(combination);
            yield return newCombination;
        }
    }
}