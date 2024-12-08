using ReportLevels;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("/Users/patrickcandlin/AoC2024/AoCDay2/ReportRunner/input.txt");

var safeReports = 0;

foreach (var line in lines)
{
    var report = new Report(line);

    var isSafe = report.IsSafeWithLevelRemoved(report.Levels);

    if (isSafe)
    {
        ++safeReports;
    }
}

Console.WriteLine($"Number of Safe Reports: {safeReports}");