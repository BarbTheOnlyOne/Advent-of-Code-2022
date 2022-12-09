using AdventOfCode.Day2;

var filePath = @"C:\Programování\Advent-of-Code-2022\AdventOfCode\AdventOfCode.Day2\input.txt";

var loadedFile = File.ReadLines(filePath);

var comparer = new RockPaperScissorsComparer(1, 2, 3, 6, 3, 0);
var totalScore = 0;

foreach (var line in loadedFile)
{
    var splitLine = line.Split(" ");
    var score = comparer.CompareFightPartTwo(splitLine[0], splitLine[1]);
    totalScore += score;
}

Console.WriteLine(totalScore);
Console.ReadLine();