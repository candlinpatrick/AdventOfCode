namespace XMASScannerTests;

using XMASScanner;
public class ScannerTests
{
    [Fact]
    public void GivenEmptyString_ShouldReturnZero()
    {
        var result = Scanner.FindAll("", "");

        Assert.Equal(0, result);
    }
}