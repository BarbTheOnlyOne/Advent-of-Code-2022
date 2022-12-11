using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal class InputParser
    {
        public static List<Stack<string>> ParseCrateStacks(string[] inputData)
        {
            // First get the input data for crates only
            List<string> stacksInput = new();
            foreach (string line in inputData)
            {
                if (line.Contains("1"))
                {
                    stacksInput.Add(line);
                    break;
                }

                stacksInput.Add(line);
            }

            // Create number of stacks from the input
            List<Stack<string>> stacks = new();
            var test = stacksInput.Last().Split();

            foreach (var number in stacksInput.Last().Replace(" ", ""))
            {
                stacks.Add(new Stack<string>());
            }

            // Populate the stacks with initial crates
            stacksInput.Remove(stacksInput.Last()); // no need for stack numbers here
            stacksInput.Reverse();
            foreach (var line in stacksInput)
            {
                for (int i = 0; i < stacks.Count; i++)
                {
                    var cratePosition = (i * 4) + 1;
                    var crateChar = line[cratePosition];

                    if (char.IsLetter(crateChar))
                    {
                        stacks[i].Push(crateChar.ToString());
                    }
                    else if (char.IsWhiteSpace(crateChar))
                    {
                        continue;
                    }
                }
            }

            return stacks;
        }

        public static List<OperatingInstruction> ParseCrateMovementInstructions(string[] inputData) 
        {
            List<OperatingInstruction> instructions = new();

            foreach (var line in inputData)
            {
                if (!line.StartsWith("m"))
                {
                    continue;
                }

                var splitLine = line.Split(" ");
                List<string> digitsFromLine = new();

                foreach (var part in splitLine)
                {
                    if (part.All(char.IsDigit))
                    {
                        digitsFromLine.Add(part);
                    }
                }

                instructions.Add(new OperatingInstruction()
                {
                    NumberOfCrates = int.Parse(digitsFromLine[0].ToString()),
                    FromStack = int.Parse(digitsFromLine[1].ToString()),
                    ToStack = int.Parse(digitsFromLine[2].ToString())
                });
            }

            return instructions;
        }
    }
}
