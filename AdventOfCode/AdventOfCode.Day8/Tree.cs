using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal class Tree
    {
        public int TreeHeight { get; private set; }

        public Visibility TopVisibility { get; set; }

        public Visibility BottomVisibility { get; set; }

        public Visibility LeftVisibility { get; set; }

        public Visibility RightVisibility { get; set; }

        public Tree(int treeHeight)
        {
            TreeHeight = treeHeight;

            TopVisibility = Visibility.Unknown; 
            BottomVisibility = Visibility.Unknown;
            LeftVisibility = Visibility.Unknown;
            RightVisibility = Visibility.Unknown;
        }
    }
}
