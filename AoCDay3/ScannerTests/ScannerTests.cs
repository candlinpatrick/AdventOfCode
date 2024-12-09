namespace ScannerTests;
using Scanners;

public class InstructionsScannerTests
{
    [Theory]
    [InlineData("")]
    public void EmptyString_ShouldReturnZero(string instructions)
    {
        var instructionScanner = new InstructionScanner(instructions);
        var result = instructionScanner.ParseFromInstructions(instructionScanner.Instructions);

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("mul(2,4)", 8)]
    [InlineData("mul(2,4)mul(2,4)", 16)]
    public void ValidCommand_ShouldReturnMultipleOfNumbers(string instructions, double expected)
    {
        var instructionScanner = new InstructionScanner(instructions);
        var result = instructionScanner.ParseFromInstructions(instructionScanner.Instructions);
        
        Assert.Equal(expected, result);

    }
}
