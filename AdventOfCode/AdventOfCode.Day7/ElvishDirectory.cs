using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
    internal class ElvishDirectory : ElvishObject
    {
        public ElvishDirectory ParentDirectory { get; private set; }

        public List<ElvishObject> DirectoryContent { get; private set; }


        public ElvishDirectory(string directoryName, ElvishDirectory parentDirectory) :
            base(directoryName)
        {
            ParentDirectory = parentDirectory;
            DirectoryContent = new();
        }

        public void AddDirectoryContent(ElvishObject content)
        {
            if (!DirectoryContent.Any(item => item.Name == content.Name))
            {
                DirectoryContent.Add(content);
            }
        }

        public int GetDirectoryContentSize()
        {
            int size = 0;

            foreach(ElvishObject content in DirectoryContent)
            {
                if (content is ElvishFile)
                {
                    size += ((ElvishFile)content).FileSize;
                }

                if (content is ElvishDirectory)
                {
                    size += ((ElvishDirectory)content).GetDirectoryContentSize();
                }
            }

            return size;
        }
    }
}
