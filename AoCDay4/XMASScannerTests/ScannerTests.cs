namespace XMASScannerTests;

using XMASScanner;
public class ScannerTests
{
    [Fact]
    public void GivenEmptyString_ShouldReturnZero()
    {
        var result = Scanner.FindAll(new string[] { }, "");

        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenSample_ShouldReturn18()
    {
        var sample = new string[]
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };

        var result = Scanner.FindAll(sample, "XMAS");

        Assert.Equal(18, result);
    }
}