using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal class CrateMover9001
    {
        public List<Stack<string>> CrateStacks { get; set; }

        public CrateMover9001(List<Stack<string>> stacks)
        {
            CrateStacks = stacks;
        }

        public void MoveStacks(OperatingInstruction instruction)
        {
            List<string> poppedCrates = new();
            for (int i = 0; i < instruction.NumberOfCrates; i++)
            {
                if (CrateStacks[instruction.FromStack - 1].TryPop(out string crate))
                {
                    poppedCrates.Add(crate);
                }
            }

            poppedCrates.Reverse();
            foreach (var crate in poppedCrates)
            {
                CrateStacks[instruction.ToStack - 1].Push(crate);
            }
        }
    }
}
