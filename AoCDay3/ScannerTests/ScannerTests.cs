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
    [InlineData("mul(2, 4)mul(2,4)", 8)]
    public void ValidCommand_ShouldReturnMultipleOfNumbers(string instructions, double expected)
    {
        var instructionScanner = new InstructionScanner(instructions);
        var result = instructionScanner.ParseFromInstructions(instructionScanner.Instructions);
        
        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData("mul(32,64]then(mul(11,8)", 88)]
    [InlineData("(mul(11,8)", 88)]
    [InlineData("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161d)]
    public void ComplexCommand_ShouldReturnExpectedResult(string instructions, double expected)
    {
        var instructionScanner = new InstructionScanner(instructions);
        var result = instructionScanner.ParseFromInstructions(instructionScanner.Instructions);

        Assert.Equal(expected, result);
    }


}
