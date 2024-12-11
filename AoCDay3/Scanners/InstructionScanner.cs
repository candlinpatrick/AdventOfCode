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

    private bool SkipprocessingEnabled;

    public InstructionScanner(string instructions, bool doProcess = false)
    {
        Instructions = instructions;
        SkipprocessingEnabled = doProcess;
    }

    public double ParseFromInstructions(string instructions)
    {
        if (string.IsNullOrEmpty(Instructions))
        {
            return 0;
        }

        var sum = 0d;

        var command = (isSet: false, cmd: "");
        var num1 = (isSet: false, num: ""); 
        var num2 = (isSet: false, num: ""); 

        for (int i = 0; i < instructions.Length; i++)
        {
            var currentChar = instructions[i];

            if (!command.isSet)
            {
                command = ParseCurrentCommand(command, currentChar);
            }
            else if (command.isSet && command.cmd == SkipProcessingCommand)
            {
                var continueIndex = instructions.IndexOf(ContinueProcessingCommand, i);
                if (continueIndex == -1)
                {
                    break;
                }
                else 
                {
                    i = continueIndex + ContinueProcessingCommand.Length - 1;
                    command = (isSet: false, cmd: "");
                    continue;
                }

            }
            else if (command.isSet && !num1.isSet && Char.IsDigit(currentChar))
            {
                num1.num += currentChar;
            }
            else if (command.isSet && !num1.isSet && currentChar == ',')
            {
                num1.isSet = true;
            }
            else if (command.isSet && num1.isSet && Char.IsDigit(currentChar))
            {
                num2.num += currentChar;
            } 
            else if (command.isSet 
                && currentChar == ')' 
                && double.TryParse(num1.num, out double value1) 
                && double.TryParse(num2.num, out double value2))
            {
                var product = value1 * value2;
                sum += product;

                command = (isSet: false, cmd: "");
                num1 = (isSet: false, num: "");
                num2 = (isSet: false, num: "");
            }
            else 
            {
                command = (isSet: false, cmd: "");
                num1 = (isSet: false, num: "");
                num2 = (isSet: false, num: "");
            }
        }

        return sum;
    }

    private (bool isSet, string cmd) ParseCurrentCommand((bool isSet, string cmd) partailCommand, char commandPart)
    {
        if (SkipprocessingEnabled)
        {
            var copyCommand = partailCommand.cmd;
            copyCommand += commandPart;

            if (SkipProcessingCommand.StartsWith(copyCommand))
            {
                partailCommand.cmd += commandPart;

                if (partailCommand.cmd == SkipProcessingCommand)
                {
                    partailCommand.isSet = true;
                }

                return partailCommand;
            }
            else if (SkipProcessingCommand.StartsWith(commandPart))
            {
                partailCommand.cmd = commandPart.ToString();
                return partailCommand;
            }
            

            return PaseMultiplyCommand(partailCommand, commandPart);

        }
        else
        {
            return PaseMultiplyCommand(partailCommand, commandPart);
        }
    }

    private (bool isSet, string cmd) ParseDoCommand((bool isSet, string cmd) partailCommand, char commandPart)
    {
        throw new NotImplementedException();
    }

    private (bool isSet, string cmd) PaseMultiplyCommand((bool isSet, string cmd) partailCommand, char commandPart)
    {
        if (!partailCommand.isSet && MultiplyCommand.Contains(commandPart))
        {
            var copyCommand = partailCommand.cmd;
            copyCommand += commandPart;
            if(MultiplyCommand.StartsWith(copyCommand))
            {
                partailCommand.cmd += commandPart;

                if (partailCommand.cmd == MultiplyCommand)
                {
                    partailCommand.isSet = true;
                }
            }
            else
            {
                partailCommand.cmd = "";
            }
        }
        else 
        {
            partailCommand.cmd = "";
        }

        return partailCommand;
    }
}