using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Scanners;

public class InstructionScanner
{
    public string Instructions; 

    private readonly string SkipProcessingCommand = "don't()";
    private readonly string ContinueProcessingCommand = "do()";

    private readonly string MultiplyCommand = "mul(";

    private bool SkipProcessingEnabled;

    public InstructionScanner(string instructions, bool doProcess = false)
    {
        Instructions = instructions;
        SkipProcessingEnabled = doProcess;
    }

    public double ParseFromInstructions(string instructions)
    {
        if (string.IsNullOrEmpty(Instructions))
        {
            return 0;
        }

        var sum = 0d;

        for (int i = 0; i < instructions.Length; i++)
        {
            var muliplylocation = instructions.IndexOf(MultiplyCommand, i);
            var skipProcessingLocation = SkipProcessingEnabled ? instructions.IndexOf(SkipProcessingCommand, i) : int.MaxValue;

            if (muliplylocation == -1)
            {
                break;
            }
            if (skipProcessingLocation == -1)
            {
                skipProcessingLocation = int.MaxValue;
            }

            if (skipProcessingLocation < muliplylocation)
            {
                var continueProcessingLocation = instructions.IndexOf(ContinueProcessingCommand, skipProcessingLocation + SkipProcessingCommand.Length -1 );
                if (continueProcessingLocation == -1)
                {
                    break;
                }
                i = continueProcessingLocation + (ContinueProcessingCommand.Length - 1);
                continue;
            }

            if (muliplylocation < skipProcessingLocation)
            {
                (bool isSet, string num) num1 = (isSet: false, num: ""), num2 = (isSet: false, num: "");
                for (int j = muliplylocation + (MultiplyCommand.Length); j < instructions.Length; j++)
                {
                    var currentChar = instructions[j];
                    if (Char.IsDigit(currentChar) && !num1.isSet)
                    {
                        num1.num += currentChar;
                    }
                    else if (currentChar == ',' && !num1.isSet)
                    {
                        num1.isSet = true;
                    }
                    else if (num1.isSet && Char.IsDigit(currentChar))
                    {
                        num2.num += currentChar;
                    }
                    else if (num1.isSet && currentChar == ')' && double.TryParse(num1.num, out double value1) && double.TryParse(num2.num, out double value2))
                    {
                        var product = value1 * value2;
                        sum += product;
                        i = j;
                        break;
                    }
                    else 
                    {
                        break;
                    }
                }
            }
        }

        return sum;
    }
}