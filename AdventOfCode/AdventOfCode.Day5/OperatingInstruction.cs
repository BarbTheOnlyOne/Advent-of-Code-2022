using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal class OperatingInstruction
    {
        public int NumberOfCrates { get; set; }

        public int FromStack { get; set; }

        public int ToStack { get; set; }
    }
}
