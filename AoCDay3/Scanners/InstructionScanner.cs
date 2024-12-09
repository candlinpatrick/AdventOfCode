using System.Runtime.CompilerServices;
using System.Text;

namespace Scanners;

public class InstructionScanner
{
    public string Instructions; 

    public InstructionScanner(string instructions)
    {
        Instructions = instructions;
    }

    public double ParseFromInstructions(string instructions)
    {
        if (string.IsNullOrEmpty(Instructions))
        {
            return 0;
        }

        var sum = 0d;
        var mul = "mul(";

        var command = (isSet: false, cmd: "");
        var num1 = (isSet: false, num: ""); 
        var num2 = (isSet: false, num: ""); 


        for (int i = 0; i < instructions.Length; i++)
        {
            var currentChar = instructions[i];

            if (!command.isSet && mul.Contains(currentChar))
            {
                var copyCommand = command.cmd;
                copyCommand += currentChar;
                if(mul.Contains(copyCommand))
                {
                    command.cmd += currentChar;

                    if (command.cmd == mul)
                    {
                        command.isSet = true;
                    }
                }
            }
            else if (command.cmd == mul && !num1.isSet && Char.IsDigit(currentChar))
            {
                num1.num += currentChar;
            }
            else if (command.cmd == mul && !num1.isSet && currentChar == ',')
            {
                num1.isSet = true;
            }
            else if (command.cmd == mul && num1.isSet && Char.IsDigit(currentChar))
            {
                num2.num += currentChar;
            } 
            else if (command.cmd == mul 
                && currentChar == ')' 
                && double.TryParse(num1.num, out double value1) 
                && double.TryParse(num2.num, out double value2))
            {
                var product = value1 * value2;
                sum += product;
            }
            else 
            {
                if (command.cmd != mul)
                {
                    command.cmd = "";
                    num1 = (isSet: false, num: "");
                    num2 = (isSet: false, num: "");
                }
            }
        }

        return sum;
    }
}