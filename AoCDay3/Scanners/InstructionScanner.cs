using System.Text;

namespace Scanners;

public class InstructionScanner
{
    public string Instructions; 
    public List<string> Commands;

    public InstructionScanner(string instructions)
    {
        Instructions = instructions;
    }

    private double ParseValueFromInstructions(string instructions)
    {
        var sum = 0;
        

        return sum;
    }
}
// part 1 is mul(
// part 2 is number
// part 3 is ,
// part 4 is number
// part 5 is )