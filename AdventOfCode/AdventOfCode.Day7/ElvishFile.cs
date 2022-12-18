using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
    internal class ElvishFile : ElvishObject
    {
        public string FileExtension { get; private set; }

        public int FileSize { get; private set; }

        public ElvishFile(string fileName, string fileExtension, int fileSize) :
            base(fileName)
        {
            FileExtension = fileExtension;
            FileSize = fileSize;
        }
    }
}
