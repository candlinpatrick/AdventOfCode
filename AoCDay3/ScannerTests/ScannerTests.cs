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

    [Theory]
    [InlineData("don't()mul(2,4)", 0d)]
    [InlineData("mul(2,4)don't()mul(2,4)", 8d)]
    [InlineData("mul(2,4)don't()mul(2,4)do()mul(2,4)", 16d)]
    [InlineData("muldon't()_mul(5,5)", 0)]
    [InlineData("mul(2,4)don't()do()don'tdo()mul(8,1)don't()mul(1,8)", 16)]
    [InlineData("mul(2,do()3)mul(4,5)don't()mul(6,7)",20d)]
    [InlineData("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48d)]
    public void GivenDontProcessCommand_ShouldReturnReturnExpected(string instruction, double expected)
    {
        var instructionScanner = new InstructionScanner(instruction, true);
        var result = instructionScanner.ParseFromInstructions(instructionScanner.Instructions);

        Assert.Equal(expected, result);
    }

}
