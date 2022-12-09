using System.Reflection;

var filePath = @"C:\Programování\Advent-of-Code-2022\AdventOfCode\AdventOfCode.Day1\input.txt";

var loadedFile = File.ReadLines(filePath);

int temporaryTotal = 0;
List<int> foodSuppliesPerElf = new();

foreach (var line in loadedFile)
{
    if (string.IsNullOrEmpty(line))
    {
        foodSuppliesPerElf.Add(temporaryTotal);
        temporaryTotal = 0;
    }
    else
    {
        temporaryTotal += int.Parse(line);
    }
}

Console.WriteLine("Highest value of food supplies:");
Console.WriteLine(foodSuppliesPerElf.Max());
Console.WriteLine("Top 3 values:");
var topThree = foodSuppliesPerElf.OrderDescending().Take(3);
Console.WriteLine(topThree.Sum());
Console.ReadLine();