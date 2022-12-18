using AdventOfCode.Day7;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadLines(filePath);

var terminal = new ElvishTerminal();

foreach (var line in loadedFile)
{
    terminal.ReadInput(line);
}

terminal.EnsureAllContentIsAdded();
var dirSizes = terminal.ListAllContentDirSizesInDirectory(terminal.RootDirectory);

PartOne(dirSizes);
PartTwo(terminal, dirSizes);

void PartOne(List<int> dirSizes)
{


    var sum = 0;
    foreach (var dirSize in dirSizes)
    {
        if (dirSize <= 100000)
        {
            sum += dirSize;
        }
    }

    Console.WriteLine("Part one result:");
    Console.WriteLine(sum);
}

void PartTwo(ElvishTerminal terminal, List<int> dirSizes)
{
    int maximumDiskSpace = 70000000;
    int updateSize = 30000000;
    int occupiedSpace = terminal.RootDirectory.GetDirectoryContentSize();
    int freeDiskSpace = maximumDiskSpace - occupiedSpace;
    int requiredSpaceToFree = updateSize - freeDiskSpace;

    int directoryToDeleteSize = dirSizes.Where(dirSize => dirSize >= requiredSpaceToFree).Min();

    Console.WriteLine("Result of part two:");
    Console.WriteLine(directoryToDeleteSize);
}