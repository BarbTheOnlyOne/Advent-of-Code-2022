namespace AdventOfCode.Day7
{
    internal class ElvishTerminal
    {
        private bool isListingContent;
        private List<ElvishObject> listedDirectoryContent;

        public ElvishDirectory RootDirectory { get; }

        public ElvishDirectory CurrentDirectory { get; set; }

        public ElvishTerminal()
        {
            RootDirectory = new("/", null); // Root directory cant have a parent
            CurrentDirectory = RootDirectory;
            listedDirectoryContent = new();
        }

        public void ReadInput(string input)
        {
            if (input == "$ cd /")
            {
                return;
            }

            string[] splitInput = input.Split(' ');

            if (input.StartsWith("$"))
            {
                if (isListingContent)
                {
                    isListingContent = false;
                    foreach (var item in listedDirectoryContent)
                    {
                        CurrentDirectory.AddDirectoryContent(item);
                    }

                    listedDirectoryContent.Clear();
                }

                if (splitInput[1] == "cd")
                {
                    if (splitInput[2] == "..")
                    {
                        CurrentDirectory = CurrentDirectory.ParentDirectory;
                    }
                    else
                    {
                        CurrentDirectory = CurrentDirectory.DirectoryContent.FirstOrDefault(dir => dir.Name == splitInput[2]) as ElvishDirectory;
                    }
                }
                else if (splitInput[1] == "ls")
                {
                    isListingContent = true;
                }
            }
            else
            {
                if (input.StartsWith("dir"))
                {
                    ElvishDirectory directory = new(splitInput[1], CurrentDirectory);
                    listedDirectoryContent.Add(directory);
                }
                else
                {
                    var nameWithExtension = splitInput[1].Split('.');
                    ElvishFile file = new(nameWithExtension[0], 
                                          nameWithExtension.Length == 1 ? null : nameWithExtension[1], 
                                          int.Parse(splitInput[0]));
                    listedDirectoryContent.Add(file);
                }
            }
        }

        /// <summary>
        ///     Last called command might be 'ls' which possibly could add some files or directories
        ///     into the current directory. This means all the listed directories wont be added since no forther iteration
        ///     is run after the last 'ls' command.
        /// </summary>
        public void EnsureAllContentIsAdded()
        {
            if (isListingContent)
            {
                isListingContent = false;
                foreach (var item in listedDirectoryContent)
                {
                    CurrentDirectory.AddDirectoryContent(item);
                }

                listedDirectoryContent.Clear();
            }
        }

        public List<int> ListAllContentDirSizesInDirectory(ElvishDirectory directory)
        {
            List<int> sizes = new();

            foreach (var item in directory.DirectoryContent)
            {
                if (item is ElvishDirectory)
                {
                    sizes.Add(((ElvishDirectory)item).GetDirectoryContentSize());
                    sizes.AddRange(ListAllContentDirSizesInDirectory((ElvishDirectory)item));
                }
            }

            return sizes;
        }
    }
}
