// See https://aka.ms/new-console-template for more information

var officialReferencePairs = new Dictionary<int, int[]>
{
    { 2, new[] { 3, 4 } },
    { 1, new[] { 2 } },
    { 3, new[] { 5, 6 } },
};

var nonReferenceKey = 0;
foreach (var key in officialReferencePairs.Keys.Where(key => !IsKeyInValues(key)))
{
    nonReferenceKey = key;
}

ShowReference(officialReferencePairs.FirstOrDefault(pair => pair.Key == nonReferenceKey));
Console.WriteLine(nonReferenceKey);

void ShowReference(KeyValuePair<int, int[]> pairs)
{
    foreach (var value in pairs.Value)
    {
        if (officialReferencePairs.ContainsKey(value))
        {
            var pair = officialReferencePairs.FirstOrDefault(pair => pair.Key == value);
            ShowReference(pair);
        }
        
        Console.WriteLine(value);
    }
}

bool IsKeyInValues(int key)
{
    return officialReferencePairs!.Values.Any(value => value.Contains(key));
}

