// See https://aka.ms/new-console-template for more information

var targetRow = GetRowSums(new[] { 1d, 2d, 3d, 4d, 5d, 9 });
Console.ReadLine();

IEnumerable<double> GetRowSums(IEnumerable<double> row)
{
    var rowCount = row.Count();
    var array = new double[rowCount];
    for (var i = 0; i < rowCount; i++)
    {
        array[i] = row.ElementAt(i);
        yield return array.Sum();
    }
}

