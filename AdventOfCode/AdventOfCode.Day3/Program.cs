using AdventOfCode.Day3;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadLines(filePath).ToList();

var priorityCounter = 0;

// First part
foreach (var line in loadedFile)
{
    var firstHalf = line[..(line.Length / 2)];
    var secondHalf = line[(line.Length / 2)..];

    foreach (var letter in firstHalf)
    {
        // The culture here is important so that "CH" is classified as "C" and "H" separately
        if (secondHalf.Contains(letter, StringComparison.InvariantCulture)) 
        {
            var number = PriorityProvider.GetPriorityOfItem(letter);
            priorityCounter += number;
            break;
        }
    }
}

// Second part
var secondPriorityNumber = 0;

for (int i = 0; i < loadedFile.Count; i += 3)
{
    ElfGroup group = new();
    group.FirstRucksack = loadedFile[i];
    group.SecondRucksack = loadedFile[i + 1];
    group.ThirdRucksack = loadedFile[i + 2];

    foreach (var letter in group.FirstRucksack)
    {
        if (group.SecondRucksack.Contains(letter, StringComparison.InvariantCulture) &&
            group.ThirdRucksack.Contains(letter, StringComparison.InvariantCulture))
        {
            var number = PriorityProvider.GetPriorityOfItem(letter);
            secondPriorityNumber += number;
            break;
        }
    }
}

Console.WriteLine("Result of the first part:");
Console.WriteLine(priorityCounter);
Console.WriteLine("Reult of the second part:");
Console.WriteLine(secondPriorityNumber);
Console.ReadLine();