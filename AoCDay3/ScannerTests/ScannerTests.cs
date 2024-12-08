namespace ScannerTests;
using Scanners;

public class InstructionsScannerTests
{
    [Fact]
    public void EmptyString_ShouldReturnZero()
    {
        var scanner = new InstructionScanner("");


    }
}