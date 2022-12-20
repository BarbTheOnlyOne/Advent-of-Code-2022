using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal class TreeVisibilityClassifier
    {
        private readonly Tree[,] _treeMap;

        public int TreeMapRowCount { get; private set;}

        public int TreeMapColumnCount { get; private set;}

        public TreeVisibilityClassifier(Tree[,] treeMap)
        {
            _treeMap = treeMap;
            TreeMapRowCount = _treeMap.GetLength(0);
            TreeMapColumnCount = _treeMap.GetLength(1);
        }

        public void DoVisibilityClassification()
        {
            ClassifyMapFromTop();
            ClassifyMapFromBottom();
            ClassifyMapFromLeft();
            ClassifyMapFromRight();
        }

        private void ClassifyMapFromTop()
        {
            for (int i = 0; i < TreeMapColumnCount; i++)
            {
                // first classify the first two rows
                var firstRowTree = _treeMap[0, i];
                firstRowTree.TopVisibility = Visibility.Visible;

                var secondRowTree = _treeMap[1, i];
                secondRowTree.TopVisibility = firstRowTree.TreeHeight >= secondRowTree.TreeHeight ?
                    Visibility.Hidden : Visibility.Visible;

                int biggestHeightInRow = firstRowTree.TreeHeight > secondRowTree.TreeHeight ? firstRowTree.TreeHeight : secondRowTree.TreeHeight;

                // now the rest of the rows
                for (int j = 2; j < TreeMapRowCount; j++)
                {
                    var classifiedTree = _treeMap[j, i];
                    var treeInFront = _treeMap[j - 1, i];

                    ClassifyTree(classifiedTree, treeInFront, ref biggestHeightInRow);
                }
            }
        }

        private void ClassifyMapFromBottom()
        {
            for (int i = 0; i < TreeMapColumnCount; i++)
            {
                // first classify the first two rows
                var firstRowTree = _treeMap[TreeMapRowCount, i];
                firstRowTree.TopVisibility = Visibility.Visible;

                var secondRowTree = _treeMap[TreeMapRowCount - 1, i];
                secondRowTree.TopVisibility = firstRowTree.TreeHeight >= secondRowTree.TreeHeight ?
                    Visibility.Hidden : Visibility.Visible;

                int biggestHeightInRow = firstRowTree.TreeHeight > secondRowTree.TreeHeight ? firstRowTree.TreeHeight : secondRowTree.TreeHeight;
                
                // now the rest of the rows
                for (int j = TreeMapRowCount - 2; j > 0; j--)
                {
                    var classifiedTree = _treeMap[j, i];
                    var treeInFront = _treeMap[j + 1, i];

                    ClassifyTree(classifiedTree, treeInFront, ref biggestHeightInRow);
                }
            }
        }

        private void ClassifyMapFromLeft()
        {
            for (int i = 0; i < TreeMapRowCount; i++)
            {
                // first classify the first two rows
                var firstRowTree = _treeMap[i, 0];
                firstRowTree.TopVisibility = Visibility.Visible;

                var secondRowTree = _treeMap[i, 1];
                secondRowTree.TopVisibility = firstRowTree.TreeHeight >= secondRowTree.TreeHeight ?
                    Visibility.Hidden : Visibility.Visible;

                int biggestHeightInRow = firstRowTree.TreeHeight > secondRowTree.TreeHeight ? firstRowTree.TreeHeight : secondRowTree.TreeHeight;

                // now the rest of the rows
                for (int j = 2; j < TreeMapColumnCount; j++)
                {
                    var classifiedTree = _treeMap[i, j];
                    var treeInFront = _treeMap[i, j - 1];

                    ClassifyTree(classifiedTree, treeInFront, ref biggestHeightInRow);
                }
            }
        }

        private void ClassifyMapFromRight()
        {
            for (int i = 0; i < TreeMapRowCount; i++)
            {
                // first classify the first two rows
                var firstRowTree = _treeMap[i, TreeMapColumnCount];
                firstRowTree.TopVisibility = Visibility.Visible;

                var secondRowTree = _treeMap[i, TreeMapColumnCount - 1];
                secondRowTree.TopVisibility = firstRowTree.TreeHeight >= secondRowTree.TreeHeight ?
                    Visibility.Hidden : Visibility.Visible;

                int biggestHeightInRow = firstRowTree.TreeHeight > secondRowTree.TreeHeight ? firstRowTree.TreeHeight : secondRowTree.TreeHeight;

                // now the rest of the rows
                for (int j = TreeMapColumnCount - 2; j > 0; j--)
                {
                    var classifiedTree = _treeMap[i, j];
                    var treeInFront = _treeMap[i, j + 1];

                    ClassifyTree(classifiedTree, treeInFront, ref biggestHeightInRow);
                }
            }
        }

        private void ClassifyTree(Tree classifiedTree, Tree treeInFront, ref int biggestHeightInRow)
        {
            switch (treeInFront.TopVisibility)
            {
                case Visibility.Visible:
                    if (classifiedTree.TreeHeight > treeInFront.TreeHeight)
                    {
                        classifiedTree.TopVisibility = Visibility.Visible;
                        biggestHeightInRow = classifiedTree.TreeHeight;
                    }
                    else
                    {
                        classifiedTree.TopVisibility = Visibility.Hidden;
                    }

                    break;

                case Visibility.Hidden:
                    if (classifiedTree.TreeHeight > biggestHeightInRow)
                    {
                        classifiedTree.TopVisibility = Visibility.Visible;
                        biggestHeightInRow = classifiedTree.TreeHeight;
                    }
                    else
                    {
                        classifiedTree.TopVisibility = Visibility.Hidden;
                    }

                    break;
            }
        }
    }
}
