using AdventOfCode.Day5;
using System.Text;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadLines(filePath).ToArray();

var crateStacks = InputParser.ParseCrateStacks(loadedFile);
var operatingInstructions = InputParser.ParseCrateMovementInstructions(loadedFile);

var message = DoPartTwo(crateStacks, operatingInstructions);

Console.WriteLine(message);


string DoPartOne(List<Stack<string>> crateStacks, List<OperatingInstruction> instructions)
{
    var crane = new CrateMover9000(crateStacks);

    foreach (var operatingInstruction in operatingInstructions)
    {
        crane.MoveStacks(operatingInstruction);
    }

    var messageBuilder = new StringBuilder();

    foreach (var stack in crateStacks)
    {
        messageBuilder.Append(stack.First());
    }

    return messageBuilder.ToString();
}

string DoPartTwo(List<Stack<string>> crateStacks, List<OperatingInstruction> instructions)
{
    var crane = new CrateMover9001(crateStacks);

    foreach (var operatingInstruction in operatingInstructions)
    {
        crane.MoveStacks(operatingInstruction);
    }

    var messageBuilder = new StringBuilder();

    foreach (var stack in crateStacks)
    {
        messageBuilder.Append(stack.First());
    }

    return messageBuilder.ToString();
}