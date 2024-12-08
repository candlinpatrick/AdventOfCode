using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var leftCol = new List<int>();
var rightCol = new List<int>();

var lines  = File.ReadAllLines("/Users/patrickcandlin/AoC2024/AoCDay1/input.txt");

foreach (var line in lines)
{
    var row = line.Split("   ");
    
    leftCol.Add(int.Parse(row[0]));
    rightCol.Add(int.Parse(row[1]));
}

var leftSorted = leftCol.OrderBy(x => x).ToList();
var rightSorted = rightCol.OrderBy(x => x).ToList();

var similarityScore = leftSorted.Select(x => rightSorted.Where(y => x == y).Count() * x ).Sum();    

Console.WriteLine($"Smislarity Score: {similarityScore}");

var differences = 0;
for (int i = 0; i < leftSorted.Count; i++)
{
    var left = leftSorted[i];
    var right = rightSorted[i];
    differences += Math.Abs(left - right);
}

Console.WriteLine($"{differences}");