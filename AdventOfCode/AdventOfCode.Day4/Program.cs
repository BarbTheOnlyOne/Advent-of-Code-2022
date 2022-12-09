var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadLines(filePath);

var fullOverlapCounter = 0;
var partialOvarlapCounter = 0;

foreach (var line in loadedFile)
{
    string[] pairSections = line.Split(",");

    var firstSectionRange = pairSections[0].Split("-");
    var secondSectionRange = pairSections[1].Split("-");

    var firstSection = Enumerable.Range(int.Parse(firstSectionRange[0]),
                                        int.Parse(firstSectionRange[1]) - int.Parse(firstSectionRange[0]) + 1)
                                 .ToList();
    var secondSection = Enumerable.Range(int.Parse(secondSectionRange[0]),
                                         int.Parse(secondSectionRange[1]) - int.Parse(secondSectionRange[0]) + 1)
                                  .ToList();

    if (ContainsAllItems(firstSection, secondSection))
    {
        fullOverlapCounter++;
    }

    if (firstSection.Any(secondSection.Contains))
    {
        partialOvarlapCounter++;
    }
}

Console.WriteLine("Result of the first part:");
Console.WriteLine(fullOverlapCounter);
Console.WriteLine("Result of the second part:");
Console.WriteLine(partialOvarlapCounter);
Console.ReadLine();

static bool ContainsAllItems(List<int> a, List<int> b)
{
    return !b.Except(a).Any() || !a.Except(b).Any();
}