using AdventOfCode.Day8;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

var loadedFile = File.ReadLines(filePath).ToList();

// Create array with D1 the number of lines of trees, D2 number of trees in one line
Tree[,] treeMap = new Tree[loadedFile.Count(), loadedFile.First().Length];

for (int i = 0; i < loadedFile.Count(); i++)
{
    string treeLine = loadedFile[i];

	for (int j = 0; j < treeLine.Length; j++)
	{
		int treeHeight = treeLine[j];
		treeMap[i, j] = new Tree(treeHeight);
	}
}

