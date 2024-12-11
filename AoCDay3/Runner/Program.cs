// See https://aka.ms/new-console-template for more information
using Scanners;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("/Users/patrickcandlin/AoC2024/AoCDay3/input.txt");
double sum = 0;

foreach (var line in lines)
{
    var instructionScanner = new InstructionScanner(line, true);
    sum += instructionScanner.ParseFromInstructions(instructionScanner.Instructions);
}

Console.WriteLine($"The total sum is {sum}");