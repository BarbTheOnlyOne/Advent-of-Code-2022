using AdventOfCode.Day6;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadAllText(filePath);

var packetMarker = new PacketMarker(4);
int markerLocation = default;

foreach (var character in loadedFile)
{
    if (packetMarker.AddCharacterAndCheckForStart(char.ToString(character)))
    {
        markerLocation = packetMarker.GetMarkerLocation();
        break;
    }
}

var packetMarkerPartTwo = new PacketMarker(14);
int messageLocation = default;

foreach (var character in loadedFile)
{
    if (packetMarkerPartTwo.AddCharacterAndCheckForStart(char.ToString(character)))
    {
        messageLocation = packetMarkerPartTwo.GetMarkerLocation();
        break;
    }
}

Console.WriteLine("Result of the first part:");
Console.WriteLine(markerLocation);
Console.WriteLine("Result of the second part:");
Console.WriteLine(messageLocation);