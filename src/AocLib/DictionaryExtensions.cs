namespace AocLib;

public static class DictionaryExtensions
{
    public static void SetOrProcess<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value,
        Func<TValue, TValue, TValue> process) where TKey : notnull
    {
        if (dictionary.TryGetValue(key, out var current))
        {
            dictionary[key] = process(current, value);
        }
        else
        {
            dictionary[key] = value;
        }
    }
}